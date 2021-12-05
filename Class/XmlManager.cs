using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace NETime_WF_EF6
{
    class XmlManager
    {
        public String nameDoc;
        static XmlDocument doc = new XmlDocument();
        static XmlNode rootNode;

        public XmlManager(string nameDoc)
        {
            this.nameDoc = nameDoc;

            rootNode = doc.CreateElement("Usuarios");
            doc.AppendChild(rootNode);
        }

        public void UserXmlDocument(user usuario /*List<user> luser*/)
        {
                      
            XmlNode usuarioNode = doc.CreateElement("Usuario");
            XmlAttribute attribute = doc.CreateAttribute("name");
            attribute.Value = usuario.name;
            usuarioNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("email");
            attribute.Value = usuario.email;
            usuarioNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("surname");
            attribute.Value = usuario.surname;
            usuarioNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("address");
            attribute.Value = usuario.address;
            usuarioNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("phone");
            attribute.Value = usuario.phone;
            usuarioNode.Attributes.Append(attribute);

            /*
             * SALT & PASSOWRD type is byte[]. It is mandatory to use 
             * Convert.ToBase64String() function to get
             * a representable string.
            */

            attribute = doc.CreateAttribute("password");
            attribute.Value = Convert.ToBase64String(usuario.password);
            usuarioNode.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("salt");
            attribute.Value = Convert.ToBase64String(usuario.salt);
            usuarioNode.Attributes.Append(attribute);

            usuarioNode.InnerText = usuario.name;
            rootNode.AppendChild(usuarioNode);

            doc.Save(nameDoc);

        }      
    }
    public static class xml
    {        
        private static string nameFromType(string nombreTipo, bool rootElement)
        {
            string res = "";
            switch (nombreTipo)
            {
                case "user":
                    res = rootElement ? "Usuarios" : "Usuario";
                    break;
                case "activities":
                    res = rootElement ? "Actividades" : "Actividad";
                    break;
                case "balance":
                    res = rootElement ? "Balance" : "Entrada";
                    break;
                case "categories":
                    res = rootElement ? "Categorias" : "Categoria";
                    break;
                case "selected_activities":
                    res = rootElement ? "Actividades_Seleccionadas" : "Actividad";
                    break;
            }
            return res;
        }
        private static string getStringByType(PropertyInfo objInfo, object data)
        {
            Console.WriteLine(objInfo.Name + ": " + objInfo.PropertyType.Name);
            string res = "";
            switch (objInfo.PropertyType.Name)
            {
                case "Byte[]":                    
                    res = Convert.ToBase64String((byte[])objInfo.GetValue(data));
                    break;
                case "Int32":
                default:
                    res = objInfo.GetValue(data).ToString();
                    break;
            }
            return res;
        }
        private static XmlAttribute genXMLAttribute(string name, string value, XmlDocument doc)
        {            
            XmlAttribute attribute = doc.CreateAttribute(name);            
            attribute.Value = value;
            return attribute;
        }        
        private static XmlNode genXMLNode(string name, string value, XmlDocument doc)
        {            
            XmlNode node = doc.CreateElement(name);
            node.InnerText = value;
            return node;
        }
        public static void genXmlFromListOftEntities<T>(IEnumerable<T> lista) //nombre función <T> (IEnumerable<T> parámetro){}
        {
            //Generamos el documento XML
            XmlDocument doc = new XmlDocument();            
            XmlNode rootNode;
                        
            //Creamos un cursor de la lista que recibimos como parámetro.
            var data = lista.GetEnumerator();
            data.MoveNext(); //Avanzamos el cursor. Primer elemento de la lista.

            //Creamos el nodo raíz según el tipo de dato recibido en la lista. Utilizamos la función auxiliar nameFromType.
            rootNode = doc.CreateElement(nameFromType(data.Current.GetType().Name, true));
            //doc.AppendChild(rootNode);

            /*
            * Recorremos la lista mediante el cursor, creando un nodo para cada elemento de la lista.
            * Para cada propiedad del objeto de la lista creamos un atributo XML y le asignamos el valor de la propiedad que tiene el elemento de la lista.
            * Adapatmos la conversión a string según el tipo de la propiedad del objeto.
            */
            do
            {
                XmlNode node = doc.CreateNode(XmlNodeType.Element, nameFromType(data.Current.GetType().Name, false), "");

                //Determinamos el tipo de elemento recibido en la lista.
                Type propiedades = typeof(user);
                foreach (var propiedad in propiedades.GetProperties())
                {
                    string name = propiedad.Name; //El nombre de la propiedad será el nombre del atributo o del nodo hijo.
                    string value = getStringByType(propiedad, data.Current); //El valor de la propiedad.

                    //Almacenaremos como atributo del nodo los valores Id. El resto serán nodos hijos.
                    int len = propiedad.Name.Length;
                    string propName = propiedad.Name.Substring(len - 2, 2);
                    switch (propName)
                    {
                        case "Id": //Generamos un atributo y lo adjuntamos al nodo.
                            node.Attributes.Append(genXMLAttribute(name, value, doc));
                            break;
                        default: //Generamos un atributo y lo adjuntamos como child al nodo.
                            node.AppendChild(genXMLNode(name, value, doc));
                            break;
                    }
                }
                //Una vez generado el nodo con todas sus propiedades lo adjuntamos al nodo raíz y avanzamos el cursor.
                rootNode.AppendChild(node);
            } while (data.MoveNext());
            doc.AppendChild(rootNode);
            doc.Save(Console.Out);
        }
    }
}

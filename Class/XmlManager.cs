using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

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
        //Se puede especificar el nombre del nodo raíz o el de los nodos hijos en este método. Si no se hace se utilizará el nombre de la clase y sus propiedades respectivamente.
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
                default:
                    res = nombreTipo;
                    break;
            }
            return res;
        }
        private static string getStringByType(PropertyInfo objInfo, object data)
        {            
            string res = "";
            switch (objInfo.PropertyType.Name)
            {
                case "Byte[]":                    
                    res = Convert.ToBase64String((byte[])objInfo.GetValue(data, null));
                    break;
                case "Int32":
                default:
                    res = objInfo.GetValue(data,null).ToString();
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
        public static XmlDocument genXmlFromListOftEntities<T>(IEnumerable<T> lista) //nombre función <T> (IEnumerable<T> parámetro){}
        {
            //Generamos el documento XML
            XmlDocument doc = new XmlDocument();            
            XmlNode rootNode;
                        
            //Creamos un cursor de la lista que recibimos como parámetro.
            var data = lista.GetEnumerator();
            data.MoveNext(); //Avanzamos el cursor. Primer elemento de la lista.

            //Creamos el nodo raíz según el tipo de dato recibido en la lista. Utilizamos la función auxiliar nameFromType.
            rootNode = doc.CreateElement(nameFromType(data.Current.GetType().Name, true));

            /*
            * Recorremos la lista mediante el cursor, creando un nodo para cada elemento de la lista.
            * Para cada propiedad del objeto de la lista creamos un atributo XML y le asignamos el valor de la propiedad que tiene el elemento de la lista.
            * Adapatmos la conversión a string según el tipo de la propiedad del objeto.
            */
            do
            {
                XmlNode node = doc.CreateNode(XmlNodeType.Element, nameFromType(data.Current.GetType().Name, false), "");

                //Determinamos el tipo de elemento recibido en la lista y recorremos sus propiedades para generar el nuevo nodo.
                Type propiedades = Type.GetType(data.Current.GetType().FullName);                
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
            writeToFile(doc);
            return doc;
        }
        //Devuelve un List<categories> desde un documento XML
        public static List<categories> getCategoriesFromXml(XmlDocument document)
        {
            ///Basado en las categorias
            Console.WriteLine(document.FirstChild.LocalName);
            XmlNodeList nodeList = document.FirstChild.SelectNodes("Categoria");
            List<categories> listOfEntities = new List<categories>();            

            foreach (XmlNode node in nodeList)            
            {
                categories entity = new categories();                
                XmlNodeList childNodesList = node.ChildNodes;
                Type propiedades = entity.GetType();

                foreach (var prop in propiedades.GetProperties())
                {   
                  foreach(XmlNode childNode in childNodesList)
                    {
                        if (childNode.Name.Equals(prop.Name))
                        {
                            switch (prop.PropertyType.Name)
                            {
                                case "Byte[]":
                                    prop.SetValue(entity, Convert.FromBase64String(childNode.InnerText));
                                    break;
                                case "Int32":
                                    prop.SetValue(entity, Int32.Parse(childNode.InnerText));
                                    break;
                                default:
                                    prop.SetValue(entity, childNode.InnerText);
                                    break;
                            }
                        }
                    }
                }
                listOfEntities.Add(entity);
            }            
            return listOfEntities;
        }
        //Devuelve una List<user> desde un documento XML
        public static List<user> getUsersFromXml(XmlDocument document)
        {
            ///Basado en las usuarios            
            XmlNodeList nodeList = document.FirstChild.SelectNodes("Usuario"); //Obtiene una lista de los nodos "Usuario" del nodo raíz.            
            List<user> listOfEntities = new List<user>();

            foreach (XmlNode node in nodeList)  //Recorremos la lista de nodos anterior.
            {
                user entity = new user();       //Instanciamos un objeto user para almacenar los datos.
                XmlNodeList childNodesList = node.ChildNodes; //Obtenemos una lista de los nodos hijo de cada nodo usuario.
                Type propiedades = entity.GetType(); //Obtenemos un cursor de las propiedades de la clase user.

                foreach (var prop in propiedades.GetProperties()) //Recorremos las propiedades de la clase user para asociarle los valores obtenidos de los nodos.
                {
                    foreach (XmlNode childNode in childNodesList) //Recorremos los nodos child de usuario hasta encontrar el que tiene el valor de la propiedad seleccioanda.
                    {                        
                        if (childNode.Name.Equals(prop.Name))
                        {
                            switch (prop.PropertyType.Name) //Asignarmos el valor a el objeto user transformando el string en el tipo correspondiente a la propiedad.
                            {
                            case "Byte[]":                                    
                                    prop.SetValue(entity, Convert.FromBase64String(childNode.InnerText));
                                    break;                                
                            case "Int32":                                    
                                    prop.SetValue(entity, Int32.Parse(childNode.InnerText));
                                    break;
                            default:
                                    prop.SetValue(entity, childNode.InnerText);
                                    break;
                            }
                        }                        
                    }
                }
                listOfEntities.Add(entity); //Almacena el objeto user en una lista que finalmente devolverá.
            }
            return listOfEntities;
        }
        private static void writeToFile(XmlDocument document)
        {
            var filePath = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "XML Export File";
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = ".xml";
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.OverwritePrompt = true;
                //saveFileDialog.FileOk += SaveFileDialog_FileOk(object sender, CancelEventArgs e);
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != string.Empty)
                {
                    var fileStream = saveFileDialog.OpenFile();
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        document.Save(writer);
                    }
                }
            }
        }
    }
}

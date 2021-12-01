using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
}

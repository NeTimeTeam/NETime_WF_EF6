using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NETime_WF_EF6.Form1;

namespace NETime_WF_EF6
{
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
        }

        //CONTEXT CLASS
        private netimeContainer context = new netimeContainer();
       
      
        private void button1_Click(object sender, EventArgs e)
        {
            //Obtenemos el byte[] del password y el salt[] antes de almacenarlo en el DB.
            PasswordHash passGen = new PasswordHash(textBox_userPass.Text);

            //Creamos un objeto usuario con los datos del formulario
            user usuario = new user()
            {
                name = textBox_userName.Text,
                email = textBox_userEmail.Text,
                password = passGen.GenerateSaltedHash(),
                salt = passGen.Salt(),
                surname = textBox_userSurname.Text,
                phone = textBox_userPhone.Text,
                //Evalua la expresión "XXX.Length > 0" y asigna uno de los dos valores definidos a continuación
                address = textBox_userAddress.Text.Length > 0 ? textBox_userAddress.Text : "none"
            };

            int userExist = (from u in context.userSet where u.email.Equals(usuario.email) select u).Count();
            if (userExist > 0)
            {
                MessageBox.Show("El usuario ya existe");
                textBox_userEmail.ForeColor = Color.Red;
            }
            else
            {
                this.context.userSet.Add(usuario); //Le pasamos el objeto al context.
             
                // callback callback = clean_userTextBoxes;
                // saveChanges("CREATE USER", callback); //Solicitamos al context que guarde los cambios en la BD.                    
            }
        }
    }

    }


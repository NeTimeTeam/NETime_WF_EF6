using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        //DELEGATES
        public delegate void callback();
        public delegate void res(string msg, Color color);

        //VERIFIACIÓN DE LOS DATOS INTRODUCIDOS
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            isValidTextBox(textBox);
        }
        private void isValidTextBox(TextBox textBox)
        {
            switch (textBox.Name)
            {
                case "textBox_userEmail":
                    setTextBoxStatus(Utilities.emailValidation(textBox.Text), textBox);
                    break;
                case "textBox_userName":
                case "textBox_userSurname":
                    setTextBoxStatus(Utilities.nameValidation(textBox.Text), textBox);
                    break;
                case "textBox_userPhone":
                    setTextBoxStatus(Utilities.phoneValidation(textBox.Text), textBox);
                    break;
                case "textBox_userAddress":
                    setTextBoxStatus(Utilities.descriptionValidation(textBox.Text), textBox);
                    break;
                case "textBox_userPass":
                case "textBox_userPass2":
                    TextBox[] textBoxes = { textBox_userPass, textBox_userPass2 };
                    bool valid = Utilities.passwordValidation(textBox.Text) && textBox_userPass.Text.Equals(textBox_userPass2.Text);
                    setTextBoxStatus(valid, textBoxes);
                    break;
            }
        }
        private void setTextBoxStatus(bool valid, TextBox textbox)
        {
            Color color = valid ? Color.Black : Color.Red;
            textbox.ForeColor = color;
            textbox.CausesValidation = valid;
        }
        private void setTextBoxStatus(bool valid, TextBox[] textBoxes)
        {
            foreach(TextBox tb in textBoxes)
            {
                setTextBoxStatus(valid, tb);
            }
        }
        private void textBox_CausesValidationChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            switch (textBox.Name)
            {
                case "textBox_userName":
                case "textBox_userEmail":
                case "textBox_userSurname":
                case "textBox_userPass":
                case "textBox_userAddress":
                case "textBox_userPhone":
                    checkUserTextboxStatus();
                    break;
            }
        }               
        private void checkUserTextboxStatus()
        {
            button_AddUser.Enabled = (textBox_userAddress.CausesValidation & textBox_userEmail.CausesValidation & textBox_userName.CausesValidation & textBox_userPass.CausesValidation &
                    textBox_userPhone.CausesValidation & textBox_userSurname.CausesValidation);
        }

        //ACCiÖN DEL BOTÓN AÑADIR USUARIO.
        private void button_AddUser_Click(object sender, EventArgs e)
        {
            CreateUser();
        }
        private async void CreateUser()
        {
            using (netimeContainer context = new netimeContainer())
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
                    //MessageBox.Show("El usuario ya existe");
                    responseMsg($"Error: El email {usuario.email} ya existe en la base de datos.", Color.Red);
                    setTextBoxStatus(false, textBox_userEmail);
                }
                else
                {
                    //Le pasamos el objeto al context.
                    context.userSet.Add(usuario);
                    //Solicitamos al context que guarde los cambios en la BD.
                    //Context.saveChanges(this.context, this.label_msg, "CREATE USER",Exit);                
                    await Context.saveChanges(context, label_msg, "CREATE USER", Exit);
                }
            }
        }
        private bool Exit(bool valid)
        {            
            if (valid) { this.Close(); return valid; }
            responseMsg("Error insertando los datos", Color.Red);
            return valid;
        }
        private void Exit()
        {
            this.Close();
        }
        //RESPONSE
        private void responseMsg(string msg, Color color)
        {
            label_msg.Text = msg;
            label_msg.ForeColor = color;
            label_msg.Visible = true;
        }
    }

}
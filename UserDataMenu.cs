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

namespace NETime_WF_EF6
{
    public partial class UserDataMenu : UserControl
    {
        public UserDataMenu()
        {
            InitializeComponent();
        }
        public UserDataMenu(int userId)
        {
            InitializeComponent();
            this.user = updateUserData(userId);
            updateUserDataInTextBox();
            updateActivitiesCounter();
            updateHoursCounter();
            updateSelectedActivitiesCounter();
        }

        public void reLoad()
        {
            updateUserDataInTextBox();
            updateActivitiesCounter();
            updateHoursCounter();
            updateSelectedActivitiesCounter();
        }

        //User data
        private user user;

        //DELEGATES
        public delegate void callback();
        //CONTEXT CLASS
        private netimeContainer context = new netimeContainer();
        private void saveChanges(string fnDesc, callback callback)
        {
            if (!saveChanges(this.context, fnDesc))
            {
                callback();
            }
        }
        private void saveChanges(string fnDesc)
        {
            saveChanges(this.context, fnDesc);
        }
        private bool saveChanges(netimeContainer context, string fnDesc)
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (DBConcurrencyException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (DbEntityValidationException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (NotSupportedException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (ObjectDisposedException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            return false;
        }

        //UPDATES DEL CONTROL
        private user updateUserData(int id)
        {
            try
            {
                return context.userSet.Find(id);
            } catch (Exception e)
            {
                label_Msg.Text = "Error de acceso a la base de datos.";
                label_Msg.ForeColor = Color.Red;
                Console.WriteLine(e.Message);
                return new user() { };                
            }            
        }
        private void updateUserDataInTextBox()
        {
            updateUserDataInTextBox(this.user);
        }
        private void updateUserDataInTextBox(user user)
        {
            textBox_userName.Text = user.name;
            textBox_userAddress.Text = user.address;
            textBox_userPass.Text = "";
            textBox_userSurname.Text = user.surname;
            textBox_userTel.Text = user.phone;
            textBox_user_Email.Text = user.email;
        }
        private void updateUserMessage(string msg, bool type)
        {
            Color color = type ? Color.Black : Color.Red;            
            label_Msg.Text = msg;
            label_Msg.ForeColor = color;            
        }
        
        
        //EDITAR DATOS DE USUARIO
        private void updateUserAttribute(TextBox data)
        {            
            bool valid = false;                //Variable de control.
            var msg = string.Empty;            //Mensaje de información
            
            switch (data.Name)  //Determinamos que opración en función de la columna seleccionada.
            {
                case "textBox_userName":
                    valid = !user.name.Equals(data.Text);
                    this.user.name = data.Text;                    
                    break;
                case "textBox_user_Email":
                    if (!user.email.Equals(data.Text))
                    {
                        try
                        {
                            if ((from u in context.userSet where u.email.Equals(data.Text) select u).Count() < 1)
                            {
                                this.user.email = data.Text;
                                valid = true;
                            }
                            else
                            {
                                msg = $"Error: el email {data.Text} ya existe en la base de datos.";
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            msg = $"Error de acceso a la base de datos.";
                        }
                    }
                    else
                    {
                        valid = false;
                    }                    
                    break;
                case "textBox_userPass":
                    if(!data.Text.Equals(string.Empty)){
                        byte[] salt = user.salt;
                        PasswordHash ph = new PasswordHash(data.Text, salt); //Le pasamos la nueva password al objeto y el salt del usuario al objeto que la va a cifrar.                    
                        user.password = ph.GenerateSaltedHash();             //Llamamos a la función que nos devolverá el nuevo password cifrado mediante el SALT.
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }                    
                    break;
                case "textBox_userTel":
                    valid = !user.phone.Equals(data.Text);
                    this.user.phone = data.Text;
                    break;
                case "textBox_userAddress":
                    valid = !user.address.Equals(data.Text);
                    this.user.address = data.Text;
                    break;
            }
            if (valid)
            {
                this.context.Entry(user).CurrentValues.SetValues(user);
                updateUserMessage($"Se ha actualizado el dato: {data.Text}", true);
                saveChanges("UPDATE USER");
            }
            else
            {
                updateUserDataInTextBox();
                label_Msg.ForeColor = Color.Red;
            }
            updateUserDataInTextBox();
            label_Msg.Text = msg;
        }
        //EVENTO TEXTBOX LEAVE FOCUS. Al salir de la edidicón del campo textbox verifica si este cumple la condición "validado", actualizandolo en la DB si la cummple o devolviendolo a su valor origianl en caso contrario.
        private void userData_TextBoxLeave(object sender, EventArgs e)
        {
            TextBox data = sender as TextBox;
            if (textBoxIsValidForUpdate(data.CausesValidation))
            {                
                Console.WriteLine("CausesValidation");
                updateUserAttribute(data);
            }
            else
            {
                updateUserMessage($"El valor \"{data.Text}\" no cumple las condiciones del campo.", false);
                updateUserDataInTextBox();                
            }
        }
        //EVENTO TEXTBOX CHANGED: cuando detecta el cambio en uno de los textbox, verifica que el nuevo texto sea válido, impidiendo la validación en caso contrario.
        private void userData_TextBoxChanged(object sender, EventArgs e)
        {            
            TextBox data = sender as TextBox;
            switch (data.Name)
            {
                case "textBox_userName":
                    textBoxIsValidWhileChange(Utilites.nameValidation(data.Text), data);
                    break;
                case "textBox_user_Email":
                    textBoxIsValidWhileChange(Utilites.emailValidation(data.Text), data);
                    break;
                case "textBox_userPass":
                    textBoxIsValidWhileChange(Utilites.passwordValidation(data.Text), data);
                    break;
                case "textBox_userPass2":
                    textBoxIsValidWhileChange(textBox_userPass.Equals(data.Text), data);
                    break;
                case "textBox_userTel":
                    textBoxIsValidWhileChange(Utilites.phoneValidation(data.Text), data);
                    break;
                case "textBox_userAddress":
                    textBoxIsValidWhileChange(Utilites.descriptionValidation(data.Text), data);
                    break;
            }
            Console.WriteLine("TextBox {0} modificado.", data.Name);
        }
        private void textBoxIsValidWhileChange(bool valid, TextBox data)
        {            
            if (valid)
            {
                data.ForeColor = Color.Black;                
            }
            else
            {
                data.ForeColor = Color.Red;
            }
            data.CausesValidation = valid;
        }
        private bool textBoxIsValidForUpdate(bool valid)
        {
            if (!valid)
            {                
                updateUserDataInTextBox();
                return false;
            }
            return valid;
        }


        //CONTADORES        
        private void updateActivitiesCounter()
        {
            int value = 0;
            value = context.activitiesSet.Where(a => a.Id.Equals(user.Id)).Count();
            label_ActivitiesCounter.Text = value.ToString();
        }        
        private void updateSelectedActivitiesCounter()
        {
            int value = 0;
            value = context.selected_activitiesSet.Where(sa => sa.userId.Equals(user.Id)).Count();
            label_SelActivitiesCounter.Text = value.ToString();
        }        
        private void updateHoursCounter()
        {
            int value = 0;
            if(context.balanceSet.Any(b => b.userId.Equals(user.Id)))
            {
                value = context.balanceSet.Where(b => b.userId.Equals(user.Id)).Sum(sb => sb.qtty);
            }            
            label_HoursCounter.Text = value.ToString();
            label_HoursCounter.ForeColor = value < 0 ? Color.Red : Color.Black;
        }        
    }
}
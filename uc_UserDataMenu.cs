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
            ReLoad();
        }

        public void ReLoad()
        {
            updateUserDataInTextBox();
            updateActivitiesCounter();
            updateHoursCounter();
            updateSelectedActivitiesCounter();
        }

        //User data
        //private user user = CurrentUser.GetUser();
                
        //DELEGATES
        public delegate void callback();
        //CONTEXT CLASS
        //private netimeContainer context = new netimeContainer();
        /*
        private async void saveChanges(string fnDesc, callback callback)
        {
            if (await Context.saveChanges(fnDesc) > 0)
            {
                callback();
            }
        }
        private async void saveChanges(string fnDesc)
        {
           await Context.saveChanges(fnDesc);
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
        */

        //UPDATES DEL CONTROL
        private async Task<user> updateUserData(int id)
        {
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    return await context.userSet.FindAsync(id);
                }
                catch (Exception e)
                {
                    label_Msg.Text = "Error de acceso a la base de datos.";
                    label_Msg.ForeColor = Color.Red;
                    Console.WriteLine(e.Message);
                    return new user() { };
                }
            }
        }
        private async Task updateUserData()
        {
            using (netimeContainer context = new netimeContainer())
            {
                try
                {
                    CurrentUser.SetUser(await context.userSet.FindAsync(CurrentUser.Id));                    
                }
                catch (Exception e)
                {
                    label_Msg.Text = "Error de acceso a la base de datos.";
                    label_Msg.ForeColor = Color.Red;
                    Console.WriteLine(e.Message);
                }
            }
            updateUserDataInTextBox();
        }
        private void updateUserDataInTextBox()
        {
            updateUserDataInTextBox(CurrentUser.GetUser());
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
            label_Msg.Visible = true;
        }
        
        
        //EDITAR DATOS DE USUARIO
        private async Task updateUserAttribute(TextBox data)
        {            
            bool valid = false;                //Variable de control.
            var msg = string.Empty;            //Mensaje de información
            
            using (netimeContainer context = new netimeContainer())
            {
                user user =context.userSet.Find(CurrentUser.Id);
                switch (data.Name)  //Determinamos que opración en función de la columna seleccionada.
                {
                    case "textBox_userName":
                        valid = !user.name.Equals(data.Text);
                        user.name = data.Text;
                        break;
                    case "textBox_userSurname":
                        valid = !user.surname.Equals(data.Text);
                        user.surname = data.Text;
                        break;
                    case "textBox_user_Email":
                        if (!user.email.Equals(data.Text))
                        {
                            try
                            {
                                if ((from u in context.userSet where u.email.Equals(data.Text) select u).Count() < 1)
                                {
                                    user.email = data.Text;
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
                    case "textBox_userPass2":
                        if (!data.Text.Equals(string.Empty))
                        {
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
                        user.phone = data.Text;
                        break;
                    case "textBox_userAddress":
                        valid = !user.address.Equals(data.Text);
                        user.address = data.Text;
                        break;
                }

                if (valid)
                {                    
                    context.Entry(user).CurrentValues.SetValues(user);                    
                    if(await Context.saveChanges(context, label_Msg, "UPDATE USER", updateUserData))
                    {
                        updateUserMessage($"Se ha actualizado el dato: {data.Text}", true);
                    }                    
                }
                else
                {
                    updateUserDataInTextBox();
                    updateUserMessage(msg, valid);
                }                                
            }
        }
        //EVENTO TEXTBOX LEAVE FOCUS. Al salir de la edidicón del campo textbox verifica si este cumple la condición "validado", actualizandolo en la DB si la cummple o devolviendolo a su valor origianl en caso contrario.
        private async void userData_TextBoxLeave(object sender, EventArgs e)
        {
            TextBox data = sender as TextBox;
            switch (data.Name)
            {
                case "textBox_userPass":
                case "textBox_userPass2":
                    break;
                default:
                    if (data.CausesValidation)
                    {
                       await updateUserAttribute(data);
                    }
                    else
                    {
                        updateUserMessage($"El valor \"{data.Text}\" no cumple las condiciones del campo.", false);
                        updateUserDataInTextBox();
                    }
                    break;
            }
            
        }
        //EVENTO TEXTBOX CHANGED: cuando detecta el cambio en uno de los textbox, verifica que el nuevo texto sea válido, impidiendo la validación en caso contrario.
        private void userData_TextBoxChanged(object sender, EventArgs e)
        {            
            TextBox data = sender as TextBox;
            switch (data.Name)
            {
                case "textBox_userName":
                case "textBox_userSurname":
                    textBoxIsValidWhileChange(Utilities.nameValidation(data.Text), data);
                    break;
                case "textBox_user_Email":
                    textBoxIsValidWhileChange(Utilities.emailValidation(data.Text), data);
                    break;
                case "textBox_userPass":
                    textBoxIsValidWhileChange(Utilities.passwordValidation(data.Text), data);
                    break;
                case "textBox_userPass2":
                    textBoxIsValidWhileChange((textBox_userPass.Text == data.Text), data);
                    break;
                case "textBox_userTel":
                    textBoxIsValidWhileChange(Utilities.phoneValidation(data.Text), data);
                    break;
                case "textBox_userAddress":
                    textBoxIsValidWhileChange(Utilities.descriptionValidation(data.Text), data);
                    break;
            }
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
        private void textBox_pass_ChangeValidation(object sender, EventArgs e)
        {
            label_userPass2.Visible = textBox_userPass.CausesValidation;
            textBox_userPass2.Visible = textBox_userPass.CausesValidation;
            button_ChangePass.Visible = textBox_userPass2.Text.Equals(textBox_userPass.Text) & textBox_userPass2.Visible;
        }

        //CONTADORES        
        private void updateActivitiesCounter()
        {
            using (netimeContainer context = new netimeContainer())
            {
                int value = 0;
                value = context.activitiesSet.Where(a => a.userId.Equals(CurrentUser.Id)).Count();
                label_ActivitiesCounter.Text = value.ToString();
            }
        }        
        private void updateSelectedActivitiesCounter()
        {
            using (netimeContainer context = new netimeContainer())
            {
                int value = 0;
                value = context.selected_activitiesSet.Where(sa => sa.userId.Equals(CurrentUser.Id)).Count();
                label_SelActivitiesCounter.Text = value.ToString();
            }
        }        
        private void updateHoursCounter()
        {
            int value = 0;
            using (netimeContainer context = new netimeContainer())
            {
                if (context.balanceSet.Any(b => b.userId.Equals(CurrentUser.Id)))
                {
                    value = context.balanceSet.Where(b => b.userId.Equals(CurrentUser.Id)).Sum(sb => sb.qtty);
                }
                label_HoursCounter.Text = value.ToString();
                label_HoursCounter.ForeColor = value < 0 ? Color.Red : Color.Black;
            }
        }

        private async void button_ChangePass_Click(object sender, EventArgs e)
        {
            await updateUserAttribute(textBox_userPass);
        }
    }
}
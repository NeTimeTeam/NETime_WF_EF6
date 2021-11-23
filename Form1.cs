using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NETime_WF_EF6
{
    public partial class Form1 : Form
    {
                
        public Form1()
        {
            InitializeComponent();
            radioButtonUsers.Checked = true;
        }

        private void getUsers_Click(object sender, EventArgs e)
        {
            using (netimeContainer context = new netimeContainer())
            {
                //Usuarios
                if (radioButtonUsers.Checked)//¿RB Ususarios activo?
                {
                    var users = context.userSet; //Obtener todos los usuarios.
                    dtg1.DataSource = users.ToList<user>();//Enviar Lista<USUARIOS> a DataGridTable1
                }

                //Actividades
                if (radioButtonActivities.Checked) //RB Activities activo¿?
                {                    
                    var activities = context.activitiesSet; //Analogo a usuarios.
                    dtg1.DataSource = activities.ToList<activities>();
                }
                //Actividades seleccionadas
                if (radioButtonSel_Activities.Checked) //RB Sel_activities activo¿?
                {
                    var sel_activities = context.selected_activitiesSet; //Analogo a usuarios.
                    dtg1.DataSource = sel_activities.ToList<selected_activities>();
                }                
            }
        }

        private void button_addUser_Click(object sender, EventArgs e)
        {
            //Creamos un objeto usuario con los datos del formulario
            user usuario = new user()
            {
                name = textBox_userName.Text,
                email = textBox_userEmail.Text,
                password = textBox_userPass.Text,
                surname = textBox_userSurname.Text,
                phone = textBox_userPhone.Text,
                //Evalua la expresión "XXX.Length > 0" y asigna uno de los dos valores definidos a continuación
                address = textBox_userAddress.Text.Length > 0 ? textBox_userAddress.Text : "none"
            };

            //Creamos la conexión ORM
            netimeContainer context = new netimeContainer();
            context.userSet.Add(usuario);
            context.SaveChanges();            
        }

        //Eventos RadioButton
        private void radioButtonSel_Activities_CheckedChanged(object sender, EventArgs e)
        {
            //Implementar cambio Form1 a formulario Sel_activities
            userFormHide();
            dtg1.DataSource = "";
        }

        private void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            //Implementar cambio Form1 a formulario Sel_activities
            userFormShow();
            dtg1.DataSource = "";
        }

        private void radioButtonActivities_CheckedChanged(object sender, EventArgs e)
        {
            //Implementar cambio Form1 a formulario Sel_activities
            userFormHide();
            dtg1.DataSource = "";
        }

        //Eventos formularios
        private void userName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        
        }

        //Validación del campo nombre usuario al salir del textbox.
        private void userName_Validating(object sender, CancelEventArgs e)
        {   
            /*
            if (userName.Text != "something")
                e.Cancel = true;
            */
        }

        private void textBox_userEmail_TextChanged(object sender, EventArgs e)
        {
            if (utilites.emailValidation(textBox_userEmail.Text))
            {
                textBox_userEmail.ForeColor = Color.Black;
                textBox_userEmail.CausesValidation = true;
            }
            else
            {
                textBox_userEmail.ForeColor = Color.Red;
                textBox_userEmail.CausesValidation = false;
            }
        }
        //Verifica el formato del texto introducido y cambia de color si no es valido.
        private void textBox_userName_TextChanged(object sender, EventArgs e)
        {
            if (utilites.nameValidation(textBox_userName.Text))
            {
                textBox_userName.ForeColor = Color.Black;
                textBox_userName.CausesValidation = true;
            }
            else
            {
                textBox_userName.ForeColor = Color.Red;
                textBox_userName.CausesValidation = false;
            }
            if (utilites.nameValidation(textBox_userSurname.Text))
            {
                textBox_userSurname.ForeColor = Color.Black;
                textBox_userSurname.CausesValidation = true;
            }
            else
            {
                textBox_userSurname.ForeColor = Color.Red;
                textBox_userSurname.CausesValidation = false;
            }
        }
        //Verifica el formato del texto introducido y cambia de color si no es valido.
        private void textBox_userPhone_TextChanged(object sender, EventArgs e)
        {
            if(utilites.phoneValidation(textBox_userPhone.Text))
            {
                textBox_userPhone.ForeColor = Color.Black;
                textBox_userPhone.CausesValidation = true;
            }
            else
            {
                textBox_userPhone.ForeColor = Color.Red;
                textBox_userPhone.CausesValidation = false;
            }
        }
        //Cada vez q el estado de validación cambia Llama a la función verificar textbox user validados para activar/desactivar el botón create.
        private void textBox_user_CausesValidationChanged(object sender, EventArgs e)
        {            
            checkUserTextboxStatus();
        }
        
        //Verifica si los campos de texto para el usuario son validos y activa el botón crear.
        private void checkUserTextboxStatus()
        {
            button_addUser.Enabled = (textBox_userAddress.CausesValidation & textBox_userEmail.CausesValidation & textBox_userName.CausesValidation & textBox_userPass.CausesValidation &
                    textBox_userPhone.CausesValidation & textBox_userSurname.CausesValidation);            
        }

        //Muestra el formulario para el usuario.
        private void userFormShow()
        {
            //show textboxes
            textBox_userName.Show();            
            textBox_userEmail.Show();
            textBox_userSurname.Show();
            textBox_userPass.Show();

            //Button show
            button_addUser.Show();

            //show labels
            label_userName.Show();
            label_userEmail.Show();
            label_userSurname.Show();
            label_userPass.Show();
        }
        private void userFormHide()
        {
            //Hide textboxes
            textBox_userName.Hide();
            textBox_userEmail.Hide();
            textBox_userSurname.Hide();
            textBox_userPass.Hide();

            //Button hide
            button_addUser.Hide();

            //hide lables
            label_userName.Hide();
            label_userEmail.Hide();
            label_userSurname.Hide();
            label_userPass.Hide();
        }        
    }
}

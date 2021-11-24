﻿using System;
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

        //Variable para almacenar el valor inicial de la celda q se va a editar.
        private string cellValue_before_edit = null;

        //Evento click en botón getUsers
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
                context.Dispose();
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
            context.userSet.Add(usuario); //Le pasamos el objeto al context.
            context.SaveChanges(); //Solicitamos al context que guarde los cambios en la BD.

            clean_userTextBoxes();
            update_userGrid();            
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
        //Vacia el texto de los bloques de texto del formulario user.
        private void clean_userTextBoxes()
        {
            textBox_userAddress.Text = "";
            textBox_userEmail.Text = "";
            textBox_userName.Text = "";
            textBox_userPass.Text = "";
            textBox_userPhone.Text = "";
            textBox_userSurname.Text = "";
        }
        //Actualiza el GridTable de los usuarios.
        private void update_userGrid()
        {
            //Creamos la conexión ORM
            netimeContainer context = new netimeContainer();
            var users = context.userSet; //Obtener todos los usuarios.
            dtg1.DataSource = users.ToList<user>();//Enviar Lista<USUARIOS> a DataGridTable1
            context.Dispose();
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

        private void dtg1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var context = new netimeContainer();                    //Conexión            
            var new_value = dtg1.CurrentCell.Value.ToString();      //Nuevo valor en la celda
            var user = context.userSet.Find(dtg1[0, e.RowIndex].Value);   //Obtenemos la entidad usuario por el ID
            bool valid = false;                                         //Variable de control.

            switch (e.ColumnIndex)  //Determinamos que la opración en función de la columna seleccionada.
            {
                case 1:
                    if (utilites.nameValidation(new_value))
                    {
                        user.name = new_value;
                        valid = true;
                    }
                    break;                    
                case 2:
                    if (utilites.nameValidation(new_value))
                    {
                        user.surname = new_value;
                        valid = true;
                    }
                    break;
                case 3:
                    if (utilites.emailValidation(new_value))
                    {
                        user.email = new_value;
                        valid = true;
                    }                    
                    break;
                case 4:
                    if (utilites.phoneValidation(new_value))
                    {
                        user.phone = new_value;
                        valid = true;
                    }                    
                    break;
                case 5:
                    //TODO: password data control
                    //user.address = new_value;
                    break;
                case 6:
                    //TODO: address data control
                    //user.password = new_value;
                    break;
                default:
                    break;
            }

            if (valid)
            {
                context.Entry(user).CurrentValues.SetValues(user);
                context.SaveChanges();
            }
            else
            {
                //TODO: Valorar alternativa al cambio de color
                dtg1.CurrentCell.Style.ForeColor = Color.Red;
                dtg1.CurrentCell.Value = this.cellValue_before_edit;
            }
        }
        
        
        private void dtg1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.cellValue_before_edit = dtg1.CurrentCell.Value.ToString();            
        }
    }
}

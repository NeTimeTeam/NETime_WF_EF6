using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;


namespace NETime_WF_EF6
{
    public partial class Form1 : Form
    {
                
        public Form1()
        {
            InitializeComponent();
            radioButtonUsers.Checked = true;           
        }

        private netimeContainer context;

        #region GET METHODS
        //Evento click en botón getUsers
        private void getUsers_Click(object sender, EventArgs e)
        {
            using (this.context = new netimeContainer())
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
                    var stored_activities = context.activitiesSet; //Analogo a usuarios.
                    dtg1.DataSource = stored_activities.ToList<activities>();
                }
                //Actividades seleccionadas
                if (radioButtonSel_Activities.Checked) //RB Sel_activities activo¿?
                {
                    var sel_activities = context.selected_activitiesSet; //Analogo a usuarios.
                    dtg1.DataSource = sel_activities.ToList<selected_activities>();
                }
            }
        }
        #endregion


        //Actualiza el GridTable de los usuarios.
        private void update_userGrid()
        {
            using (this.context = new netimeContainer())
            {
                var users = context.userSet; //Obtener todos los usuarios.
                dtg1.DataSource = users.ToList<user>();//Enviar Lista<USUARIOS> a DataGridTable1
            }
        }
        private void update_userGrid(netimeContainer context)
        {
            using (context)
            {
                var users = context.userSet; //Obtener todos los usuarios.
                dtg1.DataSource = users.ToList<user>();//Enviar Lista<USUARIOS> a DataGridTable1
            }
        }

        #region EVENTOS RADIOBUTTONS
        //Eventos RadioButton
        private void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            using (this.context = new netimeContainer())
            {
                //Implementar cambio Form1 a formulario Sel_activities
                userFormShow();
                dtg1.DataSource = this.context.userSet.ToList<user>();
            }

        }
        private void radioButtonSel_Activities_CheckedChanged(object sender, EventArgs e)
        {
            using (this.context = new netimeContainer())
            {
                userFormHide();
                dtg1.DataSource = this.context.selected_activitiesSet.ToList<selected_activities>();
            }
        }
        private void radioButtonActivities_CheckedChanged(object sender, EventArgs e)
        {
            using(this.context = new netimeContainer())
            {
                //Implementar cambio Form1 a formulario Sel_activities
                userFormHide();
                dtg1.DataSource = this.context.activitiesSet.ToList<activities>();
            }
            
        }
        #endregion

        #region CREATE USER
        private void button_addUser_Click(object sender, EventArgs e)
        {
            using(this.context = new netimeContainer())
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
                try
                {

                    int userExist = (from u in context.userSet where u.email.Equals(usuario.email) select u).Count();
                    if (userExist > 0)
                    {
                        MessageBox.Show("El usuario ya existe");
                        textBox_userEmail.ForeColor = Color.Red;
                    }
                    else
                    {
                        context.userSet.Add(usuario); //Le pasamos el objeto al context.            
                        context.SaveChanges(); //Solicitamos al context que guarde los cambios en la BD.
                        clean_userTextBoxes();
                    }
                }
                catch (DbUpdateException err)
                {
                    string errMsg = err.InnerException.InnerException.Message;
                    MessageBox.Show(errMsg);
                }
                update_userGrid(context);
            }            
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
        //Cada vez q el estado de validación cambia, llama a la función verificar textbox user validados para activar/desactivar el botón create.
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

        //Verifica si los campos de texto para el usuario son validos y activa el botón crear.
        private void checkUserTextboxStatus()
        {
            button_addUser.Enabled = (textBox_userAddress.CausesValidation & textBox_userEmail.CausesValidation & textBox_userName.CausesValidation & textBox_userPass.CausesValidation &
                    textBox_userPhone.CausesValidation & textBox_userSurname.CausesValidation);            
        }
        #endregion

        #region SHOW / HIDE USER FROM
        //Muestra el formulario para el usuario.
        private void userFormShow()
        {
            //show textboxes
            textBox_userName.Show();            
            textBox_userEmail.Show();
            textBox_userSurname.Show();
            textBox_userPass.Show();
            textBox_userAddress.Show();
            textBox_userPhone.Show();

            //Button show
            button_addUser.Show();

            //show labels
            label_userName.Show();
            label_userEmail.Show();
            label_userSurname.Show();
            label_userPass.Show();
            label_userAddress.Show();
            label_userPhone.Show();
        }
        private void userFormHide()
        {
            //Hide textboxes
            textBox_userName.Hide();
            textBox_userEmail.Hide();
            textBox_userSurname.Hide();
            textBox_userPass.Hide();
            textBox_userAddress.Hide();
            textBox_userPhone.Hide();

            //Button hide
            button_addUser.Hide();

            //hide lables
            label_userName.Hide();
            label_userEmail.Hide();
            label_userSurname.Hide();
            label_userPass.Hide();
            label_userAddress.Hide();
            label_userPhone.Hide();

        }
        #endregion

        #region UPDATE USER
        //Variable para almacenar el valor inicial de la celda q se va a editar.
        private string cellValue_before_edit = null;

        //Evento editar. Modifica el contenido en la base de datos.
        private void dtg1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (this.context = new netimeContainer())                    //Conexión
            {
                var new_value = dtg1.CurrentCell.Value.ToString();      //Nuevo valor en la celda
                var user = context.userSet.Find(dtg1[0, e.RowIndex].Value);   //Obtenemos la entidad usuario por el ID
                bool valid = false;                                         //Variable de control.

                switch (e.ColumnIndex)  //Determinamos que opración en función de la columna seleccionada.
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
                            try
                            {
                                valid = (from u in this.context.userSet where u.email.Equals(new_value) select u).Count() < 1;
                            }
                            catch
                            {
                                valid = false;
                                MessageBox.Show("El email ya existe en la DB");
                            }                             
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
                    try
                    {
                        context.SaveChanges();

                    }
                    catch (DbUpdateException err)
                    {
                        MessageBox.Show(err.InnerException.InnerException.Message);
                    }
                    update_userGrid(this.context);
                }
                else
                {
                    //TODO: Valorar alternativa al cambio de color
                    dtg1.CurrentCell.Style.ForeColor = Color.Red;
                    dtg1.CurrentCell.Value = this.cellValue_before_edit;
                }
            }
        }
        
        //Detecta el comienzo de edición de una celda y guarda su valor original.
        private void dtg1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.cellValue_before_edit = dtg1.CurrentCell.Value.ToString();            
        }
        #endregion

        #region DELETE USER
        //Habilitar el botón borrar cuando se selecciona una celda.
        private int selected_row = -1; //almacenará el valor de fila seleccionada.
        private void dtg1_RowSelect(object sender, DataGridViewCellEventArgs e)
        {
            if(int.TryParse(dtg1[0, e.RowIndex].Value.ToString(), out selected_row))
            {
                button_del.Enabled = true;
            }
        }
        private void button_del_Click(object sender, EventArgs e)
        {
            using(this.context = new netimeContainer())
            {
                user userToDelete = context.userSet.Find(selected_row);
                context.userSet.Remove(userToDelete);
                try
                {
                    context.SaveChanges();
                }catch(DbUpdateException err)
                {
                    MessageBox.Show(err.InnerException.InnerException.Message);
                }                
                update_userGrid(this.context);
            }
            
            selected_row = -1;
            button_del.Enabled = false;
            //MessageBox.Show(selected_row.ToString());
            
        }

        #endregion

        #region DEPRECTEd METHODS AND VARIABLES
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
        #endregion

        
    }
}

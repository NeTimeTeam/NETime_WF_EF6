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
            foreach(Control i in this.Controls)
            {
                Console.WriteLine(i.GetType().Name);
            }
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
                    update_userGrid(this.context);
                }

                //Actividades
                if (radioButtonActivities.Checked) //RB Activities activo¿?
                {
                    update_ActivitiesData(this.context);
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

        //Actualizar el DataGridTable de las actividades y los combobox
        private void update_ActivitiesData()
        {
            using (this.context = new netimeContainer())
            {
                update_ActivitiesData(this.context);
            }
        }
        private void update_ActivitiesData(netimeContainer context)
        {
            using (context)
            {              
                //Actualizar el combobox con los usuarios.
                comboBox_Activities_User.DataSource = context.userSet.ToList<user>();
                comboBox_Activities_User.ValueMember = "Id"; //atributo del datasource q devolverá al seleccionarlo
                comboBox_Activities_User.DisplayMember = "email"; //atributo del datasource q mostrará en la lista

                //Actualizar el combobox con las categorias
                comboBox_Activities_Categories.DataSource = context.categoriesSet.ToList<categories>();
                comboBox_Activities_Categories.ValueMember = "Id"; //atributo del datasource q devolverá al seleccionarlo
                comboBox_Activities_Categories.DisplayMember = "name"; //atributo del datasource q mostrará en la lista

                //Actualizar la datagridtable con las actividades.
                dtg1.DataSource = context.activitiesSet.ToList<activities>();
            }
        }

        //Actualiza el GridTable de los usuarios.
        private void update_userGrid()
        {
            using (this.context = new netimeContainer())
            {
                update_userGrid(this.context);
            }
        }
        private void update_userGrid(netimeContainer context)
        {            
            using (context)
            {
                //Obtenemos solo los datos del usuario q nos interesan                
                //var users = context.userSet.Select(u => new Usuario(u.Id, u.email, u.name, u.surname, u.phone, u.address, Convert.ToBase64String(u.password), Convert.ToBase64String(u.salt))).ToList<Usuario>(); //Obtener todos los usuarios.                
                List<Usuario> usuarioList = new List<Usuario>();
                var users = context.userSet;
                foreach(user u in users)
                {                    
                    usuarioList.Add(new Usuario(u));
                }
                //dtg1.DataSource = users.ToArray<Usuario>();//Enviar Lista<USUARIOS> a DataGridTable1
                dtg1.DataSource = usuarioList;
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
                update_userGrid(this.context);
            }
            DoColumnsReadOnly();
        }
        private void radioButtonSel_Activities_CheckedChanged(object sender, EventArgs e)
        {
            using (this.context = new netimeContainer())
            {
                activitiesFormSet();
                dtg1.DataSource = this.context.selected_activitiesSet.ToList<selected_activities>();
            }
        }
        private void radioButtonActivities_CheckedChanged(object sender, EventArgs e)
        {
            using(this.context = new netimeContainer())
            {
                //Implementar cambio Form1 a formulario Sel_activities
                activitiesFormSet();
                update_ActivitiesData(this.context);
                //dtg1.DataSource = this.context.activitiesSet.ToList<activities>();
            }
            
        }
        #endregion

        #region CREATE USER
        private void button_addUser_Click(object sender, EventArgs e)
        {
            using(this.context = new netimeContainer())
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
            if (Utilites.emailValidation(textBox_userEmail.Text))
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
            if (Utilites.nameValidation(textBox_userName.Text))
            {
                textBox_userName.ForeColor = Color.Black;
                textBox_userName.CausesValidation = true;
            }
            else
            {
                textBox_userName.ForeColor = Color.Red;
                textBox_userName.CausesValidation = false;
            }
            if (Utilites.nameValidation(textBox_userSurname.Text))
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
            if(Utilites.phoneValidation(textBox_userPhone.Text))
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

        #region SHOW / HIDE FROMS
        //Muestra el formulario para el usuario.
        private void userFormShow()
        {  
            Control.ControlCollection controlList = this.Controls;
            foreach (Control ctrl in this.Controls)
            {
                switch (ctrl.Name)
                {
                    case "label_userName":
                        ctrl.Show(); ctrl.Text = "Nombre";
                        break;
                    case "label_userEmail":
                        ctrl.Show(); ctrl.Text = "Email (unique)";
                        break;
                    case "label_userSurname":
                        ctrl.Show(); ctrl.Text = "Apellidos";
                        break;
                    case "label_userPass":
                        ctrl.Show(); ctrl.Text = "Contraseña";
                        break;
                    case "label_userAddress":
                        ctrl.Show(); ctrl.Text = "Dirección";
                        break;
                    case "label_userPhone":
                        ctrl.Show(); ctrl.Text = "Teléfono (+34555123456)";
                        break;
                    case "textBox_userName":
                    case "textBox_userEmail":
                    case "textBox_userSurname":
                    case "textBox_userPass":
                    case "textBox_userAddress":
                    case "textBox_userPhone":
                        ctrl.Show();
                        break;
                    default:
                        switch (ctrl.GetType().Name)
                        {
                            case "TextBox":
                            case "MaskedTextBox":
                            case "Label":
                            case "ComboBox":
                                ctrl.Hide();
                                break;
                        }
                        break;
                }
                button_addUser.Show();
            }
        }
        private void activitiesFormSet()
        {
            Control.ControlCollection controlList = this.Controls;
            foreach(Control ctrl in this.Controls)
            {
                switch (ctrl.Name)
                {
                    case "label_userName":
                        ctrl.Show(); ctrl.Text = "Usuario";
                        break;
                    case "label_userEmail":
                        ctrl.Show(); ctrl.Text = "Nombre";
                        break;
                    case "label_userSurname":
                        ctrl.Show(); ctrl.Text = "Categoría";
                        break;
                    case "label_userPass":
                        ctrl.Show(); ctrl.Text = "Descripción";
                        break;
                    case "textBox_Activities_Desc":
                    case "textBox_Activities_Nombre":
                    case "comboBox_Activities_Categories":
                    case "comboBox_Activities_User":
                        ctrl.Show();
                        break;
                    default:
                        switch (ctrl.GetType().Name) {
                            case "TextBox":
                            case "MaskedTextBox":
                            case "Label":
                            case "ComboBox":
                                ctrl.Hide();
                                break;
                        }
                            break;
                }
                button_addUser.Show();
            }
        }
        #endregion

        #region UPDATE USER
        //Variable para almacenar el valor inicial de la celda q se va a editar.
        private string cellValue_before_edit = null;

        //Función editar usuario
        private void updateUserAttribute(int col, int row)
        {
            var new_value = dtg1.CurrentCell.Value.ToString();      //Nuevo valor en la celda
            var user = context.userSet.Find(Int32.Parse(dtg1[0, row].Value.ToString()));   //Obtenemos la entidad usuario por el ID (el id ahora es un string)
            bool valid = false;                                         //Variable de control.
            string propertyName = dtg1.Columns[col].HeaderText;

            switch (propertyName)  //Determinamos que opración en función de la columna seleccionada.
            {
                case "name":
                    if (Utilites.nameValidation(new_value))
                    {
                        user.name = new_value;
                        valid = true;
                    }
                    break;
                case "surname":
                    if (Utilites.nameValidation(new_value))
                    {
                        user.surname = new_value;
                        valid = true;
                    }
                    break;
                case "email":
                    if (Utilites.emailValidation(new_value))
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
                case "phone":
                    if (Utilites.phoneValidation(new_value))
                    {
                        user.phone = new_value;
                        valid = true;
                    }
                    break;
                case "password":
                    //TODO: password data control
                    //user.address = new_value;
                    break;
                case "salt":
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
                update_userGrid();
            }
            else
            {
                //TODO: Valorar alternativa al cambio de color
                update_userGrid();
                dtg1[col, row].Style.ForeColor = Color.Red;
                //dtg1.CurrentCell.Value = this.cellValue_before_edit;                    
            }
        }
        //Evento editar. Modifica el contenido en la base de datos.
        private void dtg1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (this.context = new netimeContainer())                    //Conexión
            {
                if (radioButtonUsers.Checked) { updateUserAttribute(e.ColumnIndex, e.RowIndex); }
                if (radioButtonActivities.Checked) { }
                if (radioButtonSel_Activities.Checked) { }
            }
        }
        
        //Bloquear la edición de ciertas columnas
        private void DoColumnsReadOnly()
        {            
            for (int i=0; i < dtg1.Columns.Count; i++)
            {
                switch (dtg1.Columns[i].HeaderText)
                {
                    case "Id":
                    case "salt":
                    case "userId":
                        dtg1.Columns[i].ReadOnly = true;
                        break;
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
            if(e.RowIndex >= 0)
            {
                if (int.TryParse(dtg1[0, e.RowIndex].Value.ToString(), out selected_row))
                {                    
                    button_del.Enabled = true;
                }
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

        #region DEPRECTED METHODS AND VARIABLES
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

        private void userBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {

        }

        private void userBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

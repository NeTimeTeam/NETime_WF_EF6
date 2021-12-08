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
using System.Data.SqlClient;
using System.IO;

namespace NETime_WF_EF6
{
    public partial class Form1 : Form
    {
                
        public Form1()
        {
            InitializeComponent();
            radioButtonUsers.Checked = true;
            //foreach(Control i in this.Controls){Console.WriteLine(i.GetType().Name);}
            //test();
        }
        
        private netimeContainer context = new netimeContainer();
     

        #region GET METHODS
        //Evento click en botón getUsers
        private void getUsers_Click(object sender, EventArgs e)
        {
            //Usuarios
            if (radioButtonUsers.Checked)//¿RB Ususarios activo?
            {
                update_userGrid(this.context);
            }

            //Actividades
            if (radioButtonActivities.Checked) //RB Activities activo¿?
            {
                update_ActivitiesCombos();
                //update_ActivitiesData(this.context);
            }
            //Actividades seleccionadas
            if (radioButtonSel_Activities.Checked) //RB Sel_activities activo¿?
            {
                update_SelActCombo();
                //var sel_activities = context.selected_activitiesSet; //Analogo a usuarios.
                //dtg1.DataSource = sel_activities.ToList<selected_activities>();
            }
        }
        #endregion

        #region UPDATES METHODS
        //Actualizar el DataGridTable de las actividades
        private void update_ActivitiesData()
        {
                update_ActivitiesData(this.context);         
        }
        private void update_ActivitiesData(netimeContainer context)
        {
            //Actualizar la datagridtable con las actividades.
            int userId = Int32.Parse(comboBox_Activities_User.SelectedValue.ToString());
            //dtg1.DataSource = context.activitiesSet.ToList<activities>();                
            dtg1.DataSource = context.activitiesSet.Where(a => a.userId.Equals(userId)).ToList<activities>();            
        }
        //Actualizar los comobox de las actividades
        private void update_ActivitiesCombos()
        {
            update_ActivitiesCombos(context);        
        }
        private void update_ActivitiesCombos(netimeContainer context)
        {
            //Actualizar el combobox con los usuarios.
            comboBox_Activities_User.DataSource = context.userSet.ToList<user>();
            comboBox_Activities_User.ValueMember = "Id"; //atributo del datasource q devolverá al seleccionarlo
            comboBox_Activities_User.DisplayMember = "email"; //atributo del datasource q mostrará en la lista

            //Actualizar el combobox con las categorias
            comboBox_Activities_Categories.DataSource = context.categoriesSet.ToList<categories>();
            comboBox_Activities_Categories.ValueMember = "Id"; //atributo del datasource q devolverá al seleccionarlo
            comboBox_Activities_Categories.DisplayMember = "name"; //atributo del datasource q mostrará en la lista
        }

        //Actualiza el GridTable de los usuarios.
        private void update_userGrid()
        {
            update_userGrid(this.context);            
        }
        private void update_userGrid(netimeContainer context)
        {
            //TODO: modificar la clase usuario de manera análoga a actividades. Sin contructor.
            //Obtenemos solo los datos del usuario q nos interesan                
            //var users = context.userSet.Select(u => new Usuario(u.Id, u.email, u.name, u.surname, u.phone, u.address, Convert.ToBase64String(u.password), Convert.ToBase64String(u.salt))).ToList<Usuario>(); //Obtener todos los usuarios.                
            List<Usuario> usuarioList = new List<Usuario>();
            var users = this.context.userSet;
            foreach(user u in users)
            {                    
                usuarioList.Add(new Usuario(u));
            }
            //dtg1.DataSource = users.ToArray<Usuario>();//Enviar Lista<USUARIOS> a DataGridTable1
            dtg1.DataSource = usuarioList;        
        }
        
        //Actualiza el comobox de las actividades seleccionadas.
        private void update_SelActCombo()
        {
            update_SelActCombo(this.context);
        }
        private void update_SelActCombo(netimeContainer context)
        {
            List<user> usersList = context.userSet.ToList<user>();
            comboBox_SelAct_users.DataSource = usersList;
            comboBox_SelAct_users.ValueMember = "Id";
            comboBox_SelAct_users.DisplayMember = "email";
        }
        //actualiza los datagrid de las actividades seleccionadas.
        private void update_SelActGrids()
        {
            update_SelActGrids(this.context);
        }
        private void update_SelActGrids(netimeContainer context)
        {
            /*
            * https://www.entityframeworktutorial.net/EntityFramework4.3/raw-sql-query-in-entity-framework.aspx
            */
            try
            {
                //int currentUser = Int32.Parse(comboBox_SelAct_users.SelectedValue.ToString());
                //dtg_SelAct_Act.DataSource = context.activitiesSet.Where(A => A.userId != currentUser).ToList<activities>();
                    
                //Esta consulta devuelve las actividades que no son del usuario.
                dtg_SelAct_Act.DataSource = context.Database.SqlQuery<Actividades>(
                        "Select A.Id, A.name, A.description, U.email, C.name as category from activitiesSet as A " +
                        "inner join userSet as U on U.Id = A.userId " +
                        "inner join categoriesSet as C on C.Id = A.categoriesId " +                        
                        "where A.Id not in (select activitiesId from selected_activitiesSet where userId = @Id) and " +
                        "A.userId != @Id", new SqlParameter("@id", comboBox_SelAct_users.SelectedValue)).ToList<Actividades>();
                    

                //Esta consulta devuelve el ID de selected_Activities, el nobre de la actividad, el email del creador y el nombre de la categoria de las actividades seleccionadas por un usuario.
                var selectedActivitiesList = context.Database.SqlQuery<Actividades>(
                    "Select S.Id, A.name, A.description, U.email, C.name as category from activitiesSet as A inner join selected_activitiesSet as S on A.Id = S.activitiesId " +
                    "inner join userSet as U on U.Id = A.userId " +
                    "inner join categoriesSet as C on C.Id = A.categoriesId " +
                    "where S.userId = @Id", new SqlParameter("@id", comboBox_SelAct_users.SelectedValue)).ToList<Actividades>();

                dtg_SelAct_Selct.DataSource = selectedActivitiesList;
                    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }            
        }
        #endregion

        #region EVENTOS RADIOBUTTONS
        //TODO: Refactorizar los radiobuttons.
        //Eventos RadioButton
        private void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked)
            {
                //Implementar cambio Form1 a formulario Sel_activities
                userFormSet();
                update_userGrid(this.context);             
                DoColumnsReadOnly();
            }            
        }
        private void radioButtonSel_Activities_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSel_Activities.Checked)
            {
                selActivitiesFormSet();
                //dtg1.DataSource = this.context.selected_activitiesSet.ToList<selected_activities>();               
                update_SelActCombo(this.context);
                DoColumnsReadOnly();
            }
        }
        private void radioButtonActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonActivities.Checked)
            {
                //Implementar cambio Form1 a formulario Sel_activities
                activitiesFormSet();
                update_ActivitiesCombos(this.context);
                //dtg1.DataSource = this.context.activitiesSet.ToList<activities>();
                DoColumnsReadOnly();
            }
        }
        private void radioButton_Balance_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Balance.Checked)
            {
                BalanceForm bf = new BalanceForm();
                bf.ShowDialog();
            }
        }
        #endregion


        private void button_addUser_Click(object sender, EventArgs e)
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
                    this.context.userSet.Add(usuario); //Le pasamos el objeto al context.
                    this.context.SaveChanges(); //Solicitamos al context que guarde los cambios en la BD.
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
        //Verificar que la password introducida cumple los requisitos.
        private void textBox_userPass_TextChanged(object sender, EventArgs e)
        {
            textBox_userPass.CausesValidation = Utilites.passwordValidation(((TextBox)sender).Text);
            if (textBox_userPass.CausesValidation)
            {
                textBox_userPass.ForeColor = Color.Black;                
            }
            else
            {
                textBox_userPass.ForeColor = Color.Red;                
            }
        }
        private void textBox_userAddress_TextChanged(object sender, EventArgs e)
        {
            textBox_userAddress.CausesValidation = Utilites.descriptionValidation(((TextBox)sender).Text);
            if (textBox_userAddress.CausesValidation)
            {
                textBox_userAddress.ForeColor = Color.Black;
            }
            else
            {
                textBox_userAddress.ForeColor = Color.Red;
            }
        }
        //Cada vez q el estado de validación cambia, llama a la función verificar los textbox para activar/desactivar el botón create.       
        private void textBox_CausesValidationChanged(object sender, EventArgs e)
        {
            var obj = (TextBox)sender;
            switch (obj.Name)
            {
                case "textBox_userName":
                case "textBox_userEmail":
                case "textBox_userSurname":
                case "textBox_userPass":
                case "textBox_userAddress":
                case "textBox_userPhone":
                    checkUserTextboxStatus();
                    break;
                case "textBox_Activities_Desc":
                case "textBox_Activities_Nombre":
                    checkActivitiesTextboxStatus();
                    break;
            }            
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
               

        #region SHOW / HIDE FROMS
        //Estos métodos activan o desactivan los elementos control de la pantalla según el interfaz seleccionado.
        private void userFormSet()
        {  
            //Recorre los elementos (controles) del FORM y activa aquellos propios del interfaz usuario. Los demás interfaces disponen de un método análogo.
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
                    case "button_addUser":
                    case "getUsers":
                    case "button_del":
                    case "dtg1":
                    case "button_Import":
                    case "button_Export":
                        ctrl.Show();
                        break;
                    default:
                        switch (ctrl.GetType().Name)
                        {
                            case "TextBox":
                            case "MaskedTextBox":
                            case "Label":
                            case "ComboBox":
                            case "DataGridView":
                            case "Button":
                                ctrl.Hide();
                                break;
                        }
                        break;
                }                
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
                    case "button_Act_create":
                    case "getUsers":
                    case "button_del":
                    case "dtg1":
                    case "button_Import":
                    case "button_Export":
                        ctrl.Show();
                        break;
                    default:
                        switch (ctrl.GetType().Name) {
                            case "TextBox":
                            case "MaskedTextBox":
                            case "Label":
                            case "ComboBox":
                            case "DataGridView":
                            case "Button":
                                ctrl.Hide();
                                break;
                        }
                            break;
                }                
            }
        }
        private void selActivitiesFormSet()
        {
            Control.ControlCollection controlList = this.Controls;
            foreach (Control ctrl in this.Controls)
            {
                switch (ctrl.Name)
                {
                    case "label_SelAct_Sel":
                    case "label_SelAct_Act":
                    case "comboBox_SelAct_users":                    
                    case "dtg_SelAct_Selct":                        
                    case "dtg_SelAct_Act":
                    case "button_SelAct_SelectDismiss":                    
                    case "button_Export":
                        ctrl.Show();
                        break;
                    default:
                        switch (ctrl.GetType().Name)
                        {
                            case "TextBox":
                            case "MaskedTextBox":
                            case "Label":
                            case "ComboBox":
                            case "DataGridView":
                            case "Button":
                                ctrl.Hide();
                                break;
                        }
                        break;
                }                
            }
        }
        #endregion

        #region UPDATE USER
        //Variable para almacenar el valor inicial de la celda q se va a editar.
        private string cellValue_before_edit = null;
        //Función editar actividad
        private void updateActivityAttribute(int col, int row)
        {            
            bool valid = false;                                         //Variable de control.
            var userId = Int32.Parse(comboBox_Activities_User.SelectedValue.ToString());
            var new_value = dtg1.CurrentCell.Value.ToString();      //Nuevo valor en la celda
            var Id = Int32.Parse(dtg1[0, row].Value.ToString());    //Obtenemos el Id de la fila.            
            var entity = context.activitiesSet.Find(Id);   //Obtenemos la entidad actividad por el ID (el id ahora es un string)

            string propertyName = dtg1.Columns[col].HeaderText;
            switch (propertyName)  //Determinamos que opración en función de la columna seleccionada.
            {
                case "name":
                    if (checkIfActivityNameExist(userId, new_value))
                    {                        
                        entity.name = new_value;
                        valid = true;
                    }
                    break;
                case "description":
                    if (Utilites.descriptionValidation(new_value))
                    {
                        entity.description = new_value;
                        valid = true;
                    }
                    break;                
            }
            if (valid)
            {
                this.context.Entry(entity).CurrentValues.SetValues(entity);
                try
                {
                    this.context.SaveChanges();
                }
                catch (DbUpdateException err)
                {
                    MessageBox.Show(err.InnerException.InnerException.Message);
                }
                update_ActivitiesData();
            }
            else
            {                
                update_ActivitiesData();
                //TODO: Valorar alternativa al cambio de color
                dtg1[col, row].Style.ForeColor = Color.Red;
            }
        }
        //Función editar usuario
        private void updateUserAttribute(int col, int row)
        {            
            bool valid = false;                                         //Variable de control.
            var new_value = dtg1.CurrentCell.Value.ToString();      //Nuevo valor en la celda
            var Id = Int32.Parse(dtg1[0, row].Value.ToString());    //Obtenemos el Id de la fila.            
            
            var entity = context.userSet.Find(Id);   //Obtenemos la entidad usuario por el ID (el id ahora es un string)

            string propertyName = dtg1.Columns[col].HeaderText;
            switch (propertyName)  //Determinamos que opración en función de la columna seleccionada.
            {
                case "name":
                    if (Utilites.nameValidation(new_value))
                    {
                        entity.name = new_value;
                        valid = true;
                    }
                    break;
                case "surname":
                    if (Utilites.nameValidation(new_value))
                    {
                        entity.surname = new_value;
                        valid = true;
                    }
                    break;
                case "email":
                    if (Utilites.emailValidation(new_value))
                    {
                        entity.email = new_value;
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
                        entity.phone = new_value;
                        valid = true;
                    }
                    break;
                case "password":
                    if (Utilites.passwordValidation(new_value))
                    {
                        byte[] salt = entity.salt;
                        byte[] newPass;
                        //public PasswordHash(string pass, byte[] salt, int saltLengthLimit = 32)
                        PasswordHash ph = new PasswordHash(new_value, salt); //Le pasamos la nueva password al objeto y el salt del usuario al objeto que la va a cifrar.
                        newPass = ph.GenerateSaltedHash(); //Llamamos a la función que nos devolverá el nuevo password cifrado mediante el SALT.
                        entity.password = newPass;
                        valid = true;
                    }                    
                    break;
                case "address":
                    if (Utilites.descriptionValidation(new_value))
                    {
                        entity.address = new_value;
                        valid = true;
                    }                    
                    break;
                default:
                    break;
            }

            if (valid)
            {
                this.context.Entry(entity).CurrentValues.SetValues(entity);
                try
                {
                    this.context.SaveChanges();

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
        //Evento editar. Cuando detecta el cambio del contenido de un celda, llama a la función que actualiza el contenido en la base de datos.
        private void dtg1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButtonUsers.Checked) { updateUserAttribute(e.ColumnIndex, e.RowIndex); }
            if (radioButtonActivities.Checked) { updateActivityAttribute(e.ColumnIndex, e.RowIndex); }
            if (radioButtonSel_Activities.Checked) { }
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
                    case "categoriesId":
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
        //TODO: añadir borrar en cascada.
        //Habilitar el botón borrar cuando se selecciona una celda.
        private int selectedRowId = -1; //almacenará el valor de fila seleccionada.
        //Activa el botón borrar cuando se seleciona un celda de la tabla.
        private void dtg1_RowSelect(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //Console.WriteLine(dgv.CurrentRow.Cells[0].Value);
            if (e.RowIndex >= 0)
            {
                Int32.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out this.selectedRowId);
                button_del.Enabled = true;
            }            
        }
        //Borrará el contenido de la fila seleccionada en la tabla para actividades y usuarios.
        private void button_del_Click(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked)
            {
                //TODO: borrar las actividades y actividades seleccionadas asociadas al usuario.
                user userToDelete = this.context.userSet.Find(selectedRowId);
                this.context.userSet.Remove(userToDelete);
                try
                {
                    this.context.SaveChanges();
                }
                catch (DbUpdateException err)
                {
                    MessageBox.Show(err.InnerException.InnerException.Message);
                }
                update_userGrid(this.context);
            }
            if (radioButtonActivities.Checked)
            {                    
                activities activityToDelete = this.context.activitiesSet.Find(selectedRowId);
                context.activitiesSet.Remove(activityToDelete);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException err)
                {
                    MessageBox.Show(err.InnerException.InnerException.Message);
                }
                update_ActivitiesData(this.context);
            }            
            selectedRowId = -1;
            button_del.Enabled = false;
            //MessageBox.Show(selected_row.ToString());            
        }
        #endregion
        /*
         * 
         * ACTIVIDADES SELECCIONADAS
         * 
         */
        //Esta función captura la selección del usuario en el interfaz de selección.
        private void comboBox_SelAct_users_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (comboBox_SelAct_users.SelectedValue.GetType().Name.Equals("Int32") && radioButtonSel_Activities.Checked)
            {
                //MessageBox.Show(comboBox_SelAct_users.Text + " " + comboBox_SelAct_users.SelectedValue + " " + comboBox_SelAct_users.SelectedText);
                //update_SelActCombo();
                update_SelActGrids();
            }
        }        
        //Botón para seleccionar o cancelar la selección de las actividades.
        private void button_SelAct_SelectDismiss_Click(object sender, EventArgs e)
        {
            string action = ((Button)sender).Tag.ToString(); //Determina la acción a realizar mediante la etiqueta del botón.
            switch (action)
            {
                case "SELECT":
                    selectActivity();
                    break;
                case "DIMISS":
                    dimissActivity();
                    break;
            }            
            try
            {
                this.context.SaveChanges();     //Escribimos en la base de datos.
            }catch (DbUpdateException err)
            {
                MessageBox.Show(err.InnerException.InnerException.Message);
            }
            update_SelActGrids();
        }
        //ELIMINA UNA ACTIVIDAD DE LA SELECCIÖN DEL USUARIO.
        private void dimissActivity()
        {
            //Console.WriteLine("DISMISS ACTIVITY");
            int selectedActivityId = Int32.Parse(dtg_SelAct_Selct.CurrentRow.Cells[0].Value.ToString());          //Id de la actividad seleccionada que queremos eliminar.
            selected_activities selActivity = this.context.selected_activitiesSet.Find(selectedActivityId); //Recuperamos la entidad desde el context
            this.context.selected_activitiesSet.Remove(selActivity);                                        //Le pasamos la orden de borrado a la clase context.            
        }
        //AÑADE UNA ACTIVIDAD A LA SELECCIÖN DEL USUARIO.
        private void selectActivity()
        {            
            //Seleccionar actividad.
            //Console.WriteLine("ADD ACTIVITY");
            int userId = Int32.Parse(comboBox_SelAct_users.SelectedValue.ToString());        //Id usuario que se apunta a la actividad.
            int activityId = Int32.Parse(dtg_SelAct_Act.CurrentRow.Cells[0].Value.ToString());    //Id actividad a la que se apunta el usuairo.
            selected_activities newSelActivity = new selected_activities                       //Creamos la entidad actividad con los datos de usuario y actividad.
            {
                userId = userId,
                activitiesId = activityId
            };
            this.context.selected_activitiesSet.Add(newSelActivity);                           //Añadimos la actividad a traves de la clase context.            
        }
        /*
         * 
         * ACTIVIDADES
         * 
         */
        //TODO: Hacer un refactor de la verificación de los textbox
        private void textBox_Activities_Desc_TextChanged(object sender, EventArgs e)
        {
            if (Utilites.descriptionValidation(textBox_Activities_Desc.Text))
            {
                textBox_Activities_Desc.ForeColor = Color.Black;
                textBox_Activities_Desc.CausesValidation = true;
            }
            else
            {
                textBox_Activities_Desc.ForeColor = Color.Red;
                textBox_Activities_Desc.CausesValidation = false;
            }
        }
        private void textBox_Activities_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (Utilites.nameValidation(textBox_Activities_Nombre.Text))
            {
                textBox_Activities_Nombre.ForeColor = Color.Black;
                textBox_Activities_Nombre.CausesValidation = true;
            }
            else
            {
                textBox_Activities_Nombre.ForeColor = Color.Red;
                textBox_Activities_Nombre.CausesValidation = false;
            }
        }
        private void clean_activitiesTextBoxes()
        {
            textBox_Activities_Nombre.Text = "";
            textBox_Activities_Desc.Text = "";
        }
        private void checkActivitiesTextboxStatus()
        {
            button_Act_create.Enabled = (textBox_Activities_Desc.CausesValidation & textBox_Activities_Nombre.CausesValidation);
        }
        //Acción para crear una actividad 
        private void button_Act_create_Click(object sender, EventArgs e)
        {
            /*
            Console.WriteLine(comboBox_Activities_User.SelectedValue +"\n"+
                comboBox_Activities_Categories.SelectedValue + "\n"+
                textBox_Activities_Nombre.Text + "\n"+
                textBox_Activities_Desc.Text);
            */
            int userId = (int)comboBox_Activities_User.SelectedValue;
            int categoriesId = (int)comboBox_Activities_Categories.SelectedValue;
            string name = textBox_Activities_Nombre.Text;
            string description = textBox_Activities_Desc.Text;

            if(checkIfActivityNameExist(userId, name))
            {
                activities activity = new activities
                {
                    userId = userId,
                    categoriesId = categoriesId,
                    name = name,
                    description = description
                };
                
                this.context.activitiesSet.Add(activity);
                try
                {
                    context.SaveChanges();
                    clean_activitiesTextBoxes();
                }
                catch (DbUpdateException err)
                {
                    MessageBox.Show(err.InnerException.InnerException.Message);
                }
                update_ActivitiesData(this.context);
            }
            else
            {
                MessageBox.Show("El nombre ya ha sido usado.");
            }            
        }
        //Verifica si el nombre de la actividad ya ha sido usado por el usuario.
        private bool checkIfActivityNameExist(int userId, string name)
        {            
            try
            {
                var names = this.context.activitiesSet.Where(a => a.userId.Equals(userId)).Select(a => a.name).ToArray<string>();                    
                return !(names.Contains(name));
            }catch(Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }            
        }
        private void comboBox_Activities_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Activities_User.SelectedValue.GetType().Name.Equals("Int32") && radioButtonActivities.Checked)
            {                
                update_ActivitiesData();
            }
        }

        //AÑADEN O ELIMINAN ACTIVIDADES EN EL PREFIL DEL USUARIO
        private void dtg_SelAct_Selct_CellEnter(object sender, DataGridViewCellEventArgs e)
        {            
            //Console.WriteLine("ACTIVIDADES SELECCIONADAS: "+((DataGridView)sender).AccessibleName + " / " + e.ToString());
            button_SelAct_SelectDismiss.Enabled = true;
            button_SelAct_SelectDismiss.Text = "";
            var icon = Properties.Resources.Arrows_Right_Arrow.ToBitmap();
            button_SelAct_SelectDismiss.BackgroundImage = Properties.Resources.Arrows_Right_Arrow.ToBitmap();
            button_SelAct_SelectDismiss.Size = icon.Size;
            button_SelAct_SelectDismiss.Tag = "DIMISS";
        }
        private void dtg_SelAct_Act_CellEnter(object sender, DataGridViewCellEventArgs e)
        {            
            //Console.WriteLine("ACTIVIDADES: "+((DataGridView)sender).AccessibleName + " / " + e.ToString());
            button_SelAct_SelectDismiss.Enabled = true;
            button_SelAct_SelectDismiss.Text = "";
            var icon = Properties.Resources.Arrows_Left_Arrow.ToBitmap();
            button_SelAct_SelectDismiss.BackgroundImage = icon;
            button_SelAct_SelectDismiss.Size = icon.Size;
            button_SelAct_SelectDismiss.Tag = "SELECT";
        }
        
        //XML IMPORT-EXPORT DATA
        private void button_Import_Click(object sender, EventArgs e)
        {
            if (radioButtonActivities.Checked)
            {
                var data = xmlTool.importFromFile<categories>();
                if(data.Count() > 0)
                {
                    insertListOfData<categories>(data);
                }
                update_ActivitiesCombos();
            }
            if (radioButtonUsers.Checked)
            {
                var data = xmlTool.importFromFile<user>();
                if (data.Count() > 0)
                {
                    insertListOfData<user>(data);
                }
                update_userGrid();
            }
        }
        private void insertListOfData<T>(IEnumerable<T> data)
        {            
            IEnumerator <T> dataEnum = data.GetEnumerator();            
            while (dataEnum.MoveNext())
            {                
                switch (dataEnum.Current.GetType().Name){
                    case "user":
                        user nuser = dataEnum.Current as user;
                        if (verifyUserImportData(nuser))
                        {
                            this.context.userSet.Add(nuser);
                        }
                        break;
                    case "categories":
                        categories nCategory = dataEnum.Current as categories;
                        if (verifyCategoryImportData(nCategory))
                        {
                            this.context.categoriesSet.Add(nCategory);
                        }
                        break;
                }                
            }
            try
            {
                this.context.SaveChanges();
            }catch(DbUpdateException err)
            {
                MessageBox.Show("Error importando usuarios.\n" + err.InnerException.Message);
            }            
        }
        private bool verifyCategoryImportData(categories entity)
        {
            if (!Utilites.nameValidation(entity.name))
            {
                Console.WriteLine("Error importando categorías. {0} no es un nombre válido.", entity.name);
                return false;
            }
            if (!Utilites.descriptionValidation(entity.family))
            {
                Console.WriteLine("Error importando categorías. {0} no es un nombre de famila válido.", entity.family);
                return false;
            }
            if (this.context.categoriesSet.Where(c => c.name.Equals(entity.name)).Count() > 0)
            {
                Console.WriteLine("Error importando categorías. El nombre {0} ya existe en la base de datos.", entity.name);
                return false;
            }
            Console.WriteLine("Categoría {0} - {1} importada.", entity.name, entity.family);
            return true;
        }
        private bool verifyUserImportData(user entity)
        {            
            if (!Utilites.nameValidation(entity.name))
            {
                Console.WriteLine("Error importando usuarios. {0} no es un nombre válido.", entity.name);
                return false;
            }
            if (!Utilites.descriptionValidation(entity.address)) {
                Console.WriteLine("Error importando usuarios. {0} no es una dirección válida.", entity.address);
                return false;
            }
            if (!Utilites.emailValidation(entity.email)) {
                Console.WriteLine("Error importando usuarios. {0} no es un email válido.", entity.email);
                return false;
            }
            if (!Utilites.phoneValidation(entity.phone)) {
                Console.WriteLine("Error importando usuarios. {0} no es un teléfono válido.", entity.phone);
                return false; }
            if(this.context.userSet.Where(u => u.email.Equals(entity.email)).Count() > 0) {
                Console.WriteLine("Error importando usuarios. El email {0} ya existe en la base de datos.", entity.email);
                return false;
            }
            Console.WriteLine("Usuario {0} importado.", entity.email);
            return true;
        }
        private void button_Export_Click(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked)
            {
                xmlTool.genXmlFromListOftEntities(this.context.userSet.ToList<user>());
            }
            if (radioButtonActivities.Checked)
            {
                xmlTool.genXmlFromListOftEntities(this.context.activitiesSet.ToList<activities>());
            }
            if (radioButtonSel_Activities.Checked)
            {
                xmlTool.genXmlFromListOftEntities(this.context.selected_activitiesSet.ToList<selected_activities>());
            }            
        }

        private void test()
        {
            List<user> users = this.context.userSet.ToList<user>();
            List<categories> categories = this.context.categoriesSet.ToList<categories>();
            //List<activities> activities = this.context.activitiesSet.ToList<activities>();

            Type data = typeof(categories);
            foreach (var d in data.GetProperties())
            {
                Console.WriteLine(d.Name + ": " + d.PropertyType.Name);
            }
            List<user> userList = xmlTool.getUsersFromXml(xmlTool.genXmlFromListOftEntities(users));
            foreach (user u in userList)
            {
                Console.WriteLine("{0}, {1}, {2}", u.email, u.name, u.surname);
            }
            List<categories> categoryList = xmlTool.getCategoriesFromXml(xmlTool.genXmlFromListOftEntities(categories));
            foreach (categories c in categoryList)
            {
                Console.WriteLine("{0}, {1}", c.family, c.name);
            }
        }
    }    
}
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

namespace NETime_WF_EF6
{
    public partial class Form1 : Form
    {
                
        public Form1()
        {
            InitializeComponent();
            radioButtonUsers.Checked = true;           
            //foreach(Control i in this.Controls){Console.WriteLine(i.GetType().Name);}
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

        #region UPDATES METHODS
        //Actualizar el DataGridTable de las actividades
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
                //Actualizar la datagridtable con las actividades.
                int userId = Int32.Parse(comboBox_Activities_User.SelectedValue.ToString());
                //dtg1.DataSource = context.activitiesSet.ToList<activities>();                
                dtg1.DataSource = context.activitiesSet.Where(a => a.userId.Equals(userId)).ToList<activities>();
            }
        }
        //Actualizar los comobox de las actividades
        private void update_ActivitiesCombos()
        {
            using(this.context = new netimeContainer())
            {
                update_ActivitiesCombos(context);
            }
        }
        private void update_ActivitiesCombos(netimeContainer context)
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
        
        //Actualiza el comobox de las actividades seleccionadas.
        private void update_SelActCombo()
        {
            using(this.context = new netimeContainer())
            {
                update_SelActCombo(this.context);                
            }
        }
        private void update_SelActCombo(netimeContainer context)
        {
            using (context)
            {
                List<user> usersList = context.userSet.ToList<user>();
                comboBox_SelAct_users.DataSource = usersList;
                comboBox_SelAct_users.ValueMember = "Id";
                comboBox_SelAct_users.DisplayMember = "email";                                
            }
        }
        //actualiza los datagrid de las actividades seleccionadas.
        private void update_SelActGrids()
        {            
            using (this.context = new netimeContainer())
            {
                update_SelActGrids(this.context);
            }
        }
        private void update_SelActGrids(netimeContainer context)
        {
            using (context)
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
                            "where A.userId != @Id", new SqlParameter("@id", comboBox_SelAct_users.SelectedValue)).ToList<Actividades>();
                    

                    //Esta consulta devuelve el ID de selected_Activities, el nobre de la actividad, el email del creador y el nombre de la categoria.
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
        }
        #endregion

        #region EVENTOS RADIOBUTTONS
        //TODO: Refactorizar los radiobuttons.
        //Eventos RadioButton
        private void radioButtonUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUsers.Checked)
            {                
                using (this.context = new netimeContainer())
                {
                    //Implementar cambio Form1 a formulario Sel_activities
                    userFormSet();
                    update_userGrid(this.context);
                }
                DoColumnsReadOnly();
            }            
        }
        private void radioButtonSel_Activities_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSel_Activities.Checked)
            {             
                using (this.context = new netimeContainer())
                {
                    selActivitiesFormSet();
                    //dtg1.DataSource = this.context.selected_activitiesSet.ToList<selected_activities>();               
                    update_SelActCombo(this.context);
                }
                DoColumnsReadOnly();
            }            
        }
        private void radioButtonActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonActivities.Checked)
            {             
                using (this.context = new netimeContainer())
                {
                    //Implementar cambio Form1 a formulario Sel_activities
                    activitiesFormSet();
                    update_ActivitiesCombos(this.context);
                    //dtg1.DataSource = this.context.activitiesSet.ToList<activities>();
                }
                DoColumnsReadOnly();
            }            
        }
        #endregion

        
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
                context.Entry(entity).CurrentValues.SetValues(entity);
                try
                {
                    context.SaveChanges();
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
                context.Entry(entity).CurrentValues.SetValues(entity);
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
                if (radioButtonActivities.Checked) { updateActivityAttribute(e.ColumnIndex, e.RowIndex); }
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
        //Habilitar el botón borrar cuando se selecciona una celda.
        private int selectedRowId = -1; //almacenará el valor de fila seleccionada.
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
        //Borrará el contenido de la fila seleccionada.
        private void button_del_Click(object sender, EventArgs e)
        {
            using (this.context = new netimeContainer())
            {
                if (radioButtonUsers.Checked)
                {
                    //TODO: borrar las actividades y actividades seleccionadas asociadas al usuario.
                    user userToDelete = context.userSet.Find(selectedRowId);
                    context.userSet.Remove(userToDelete);
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
                if (radioButtonActivities.Checked)
                {                    
                    activities activityToDelete = context.activitiesSet.Find(selectedRowId);
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
            //TODO: Acción cuando se presiona el botón.
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
                
                using (this.context = new netimeContainer())
                {
                    context.activitiesSet.Add(activity);
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
    }
}
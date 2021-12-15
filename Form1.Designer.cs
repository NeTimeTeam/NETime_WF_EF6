
namespace NETime_WF_EF6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dtg1 = new System.Windows.Forms.DataGridView();
            this.getUsers = new System.Windows.Forms.Button();
            this.radioButtonUsers = new System.Windows.Forms.RadioButton();
            this.radioButtonActivities = new System.Windows.Forms.RadioButton();
            this.radioButtonSel_Activities = new System.Windows.Forms.RadioButton();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.textBox_userSurname = new System.Windows.Forms.TextBox();
            this.label_userName = new System.Windows.Forms.Label();
            this.label_userEmail = new System.Windows.Forms.Label();
            this.textBox_userEmail = new System.Windows.Forms.TextBox();
            this.label_userSurname = new System.Windows.Forms.Label();
            this.label_userPass = new System.Windows.Forms.Label();
            this.textBox_userPass = new System.Windows.Forms.TextBox();
            this.button_addUser = new System.Windows.Forms.Button();
            this.textBox_userPhone = new System.Windows.Forms.TextBox();
            this.textBox_userAddress = new System.Windows.Forms.TextBox();
            this.label_userPhone = new System.Windows.Forms.Label();
            this.label_userAddress = new System.Windows.Forms.Label();
            this.button_del = new System.Windows.Forms.Button();
            this.comboBox_Activities_User = new System.Windows.Forms.ComboBox();
            this.comboBox_Activities_Categories = new System.Windows.Forms.ComboBox();
            this.textBox_Activities_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Activities_Desc = new System.Windows.Forms.TextBox();
            this.button_Act_create = new System.Windows.Forms.Button();
            this.comboBox_SelAct_users = new System.Windows.Forms.ComboBox();
            this.dtg_SelAct_Selct = new System.Windows.Forms.DataGridView();
            this.dtg_SelAct_Act = new System.Windows.Forms.DataGridView();
            this.label_SelAct_Sel = new System.Windows.Forms.Label();
            this.label_SelAct_Act = new System.Windows.Forms.Label();
            this.button_SelAct_SelectDismiss = new System.Windows.Forms.Button();
            this.radioButton_Balance = new System.Windows.Forms.RadioButton();
            this.button_Import = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SelAct_Selct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SelAct_Act)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg1
            // 
            this.dtg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg1.Location = new System.Drawing.Point(566, 23);
            this.dtg1.Margin = new System.Windows.Forms.Padding(6);
            this.dtg1.MultiSelect = false;
            this.dtg1.Name = "dtg1";
            this.dtg1.RowHeadersWidth = 82;
            this.dtg1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtg1.Size = new System.Drawing.Size(1328, 598);
            this.dtg1.TabIndex = 0;
            this.dtg1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtg1_CellBeginEdit);
            this.dtg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg1_RowSelect);
            this.dtg1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg1_CellValueChanged);
            // 
            // getUsers
            // 
            this.getUsers.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.getUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.getUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.getUsers.Location = new System.Drawing.Point(984, 658);
            this.getUsers.Margin = new System.Windows.Forms.Padding(6);
            this.getUsers.Name = "getUsers";
            this.getUsers.Size = new System.Drawing.Size(194, 90);
            this.getUsers.TabIndex = 1;
            this.getUsers.Text = "Actualizar";
            this.getUsers.UseVisualStyleBackColor = true;
            this.getUsers.Click += new System.EventHandler(this.getUsers_Click);
            // 
            // radioButtonUsers
            // 
            this.radioButtonUsers.AutoSize = true;
            this.radioButtonUsers.Location = new System.Drawing.Point(58, 38);
            this.radioButtonUsers.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonUsers.Name = "radioButtonUsers";
            this.radioButtonUsers.Size = new System.Drawing.Size(128, 29);
            this.radioButtonUsers.TabIndex = 2;
            this.radioButtonUsers.TabStop = true;
            this.radioButtonUsers.Text = "Usuarios";
            this.radioButtonUsers.UseVisualStyleBackColor = true;
            this.radioButtonUsers.CheckedChanged += new System.EventHandler(this.radioButtonUsers_CheckedChanged);
            // 
            // radioButtonActivities
            // 
            this.radioButtonActivities.AutoSize = true;
            this.radioButtonActivities.Location = new System.Drawing.Point(58, 83);
            this.radioButtonActivities.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonActivities.Name = "radioButtonActivities";
            this.radioButtonActivities.Size = new System.Drawing.Size(154, 29);
            this.radioButtonActivities.TabIndex = 3;
            this.radioButtonActivities.TabStop = true;
            this.radioButtonActivities.Text = "Actividades";
            this.radioButtonActivities.UseVisualStyleBackColor = true;
            this.radioButtonActivities.CheckedChanged += new System.EventHandler(this.radioButtonActivities_CheckedChanged);
            // 
            // radioButtonSel_Activities
            // 
            this.radioButtonSel_Activities.AutoSize = true;
            this.radioButtonSel_Activities.Location = new System.Drawing.Point(58, 127);
            this.radioButtonSel_Activities.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonSel_Activities.Name = "radioButtonSel_Activities";
            this.radioButtonSel_Activities.Size = new System.Drawing.Size(301, 29);
            this.radioButtonSel_Activities.TabIndex = 4;
            this.radioButtonSel_Activities.TabStop = true;
            this.radioButtonSel_Activities.Text = "Actividades Seleccionadas";
            this.radioButtonSel_Activities.UseVisualStyleBackColor = true;
            this.radioButtonSel_Activities.CheckedChanged += new System.EventHandler(this.radioButtonSel_Activities_CheckedChanged);
            // 
            // textBox_userName
            // 
            this.textBox_userName.AccessibleDescription = "Nombre de usuario";
            this.textBox_userName.Location = new System.Drawing.Point(98, 310);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(364, 31);
            this.textBox_userName.TabIndex = 5;
            this.textBox_userName.Tag = "Nombre";
            this.textBox_userName.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // textBox_userSurname
            // 
            this.textBox_userSurname.Location = new System.Drawing.Point(98, 385);
            this.textBox_userSurname.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_userSurname.Name = "textBox_userSurname";
            this.textBox_userSurname.Size = new System.Drawing.Size(364, 31);
            this.textBox_userSurname.TabIndex = 6;
            this.textBox_userSurname.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userSurname.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(92, 279);
            this.label_userName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(87, 25);
            this.label_userName.TabIndex = 7;
            this.label_userName.Text = "Nombre";
            // 
            // label_userEmail
            // 
            this.label_userEmail.AutoSize = true;
            this.label_userEmail.Location = new System.Drawing.Point(92, 429);
            this.label_userEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_userEmail.Name = "label_userEmail";
            this.label_userEmail.Size = new System.Drawing.Size(153, 25);
            this.label_userEmail.TabIndex = 8;
            this.label_userEmail.Text = "Email (Unique)";
            // 
            // textBox_userEmail
            // 
            this.textBox_userEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_userEmail.Location = new System.Drawing.Point(98, 460);
            this.textBox_userEmail.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_userEmail.Name = "textBox_userEmail";
            this.textBox_userEmail.Size = new System.Drawing.Size(364, 31);
            this.textBox_userEmail.TabIndex = 9;
            this.textBox_userEmail.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userEmail.TextChanged += new System.EventHandler(this.textBox_userEmail_TextChanged);
            // 
            // label_userSurname
            // 
            this.label_userSurname.AutoSize = true;
            this.label_userSurname.Location = new System.Drawing.Point(92, 354);
            this.label_userSurname.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_userSurname.Name = "label_userSurname";
            this.label_userSurname.Size = new System.Drawing.Size(100, 25);
            this.label_userSurname.TabIndex = 10;
            this.label_userSurname.Text = "Apellidos";
            // 
            // label_userPass
            // 
            this.label_userPass.AutoSize = true;
            this.label_userPass.Location = new System.Drawing.Point(92, 504);
            this.label_userPass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_userPass.Name = "label_userPass";
            this.label_userPass.Size = new System.Drawing.Size(123, 25);
            this.label_userPass.TabIndex = 11;
            this.label_userPass.Text = "Contraseña";
            // 
            // textBox_userPass
            // 
            this.textBox_userPass.CausesValidation = false;
            this.textBox_userPass.Location = new System.Drawing.Point(98, 535);
            this.textBox_userPass.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_userPass.MaxLength = 16;
            this.textBox_userPass.Name = "textBox_userPass";
            this.textBox_userPass.PasswordChar = '*';
            this.textBox_userPass.Size = new System.Drawing.Size(364, 31);
            this.textBox_userPass.TabIndex = 12;
            this.textBox_userPass.UseSystemPasswordChar = true;
            this.textBox_userPass.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userPass.TextChanged += new System.EventHandler(this.textBox_userPass_TextChanged);
            // 
            // button_addUser
            // 
            this.button_addUser.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_addUser.Enabled = false;
            this.button_addUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_addUser.Location = new System.Drawing.Point(98, 765);
            this.button_addUser.Margin = new System.Windows.Forms.Padding(6);
            this.button_addUser.Name = "button_addUser";
            this.button_addUser.Size = new System.Drawing.Size(150, 44);
            this.button_addUser.TabIndex = 13;
            this.button_addUser.Text = "Crear usuario";
            this.button_addUser.UseVisualStyleBackColor = true;
            this.button_addUser.Click += new System.EventHandler(this.button_addUser_Click);
            // 
            // textBox_userPhone
            // 
            this.textBox_userPhone.CausesValidation = false;
            this.textBox_userPhone.Location = new System.Drawing.Point(98, 608);
            this.textBox_userPhone.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_userPhone.Name = "textBox_userPhone";
            this.textBox_userPhone.Size = new System.Drawing.Size(364, 31);
            this.textBox_userPhone.TabIndex = 14;
            this.textBox_userPhone.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userPhone.TextChanged += new System.EventHandler(this.textBox_userPhone_TextChanged);
            // 
            // textBox_userAddress
            // 
            this.textBox_userAddress.CausesValidation = false;
            this.textBox_userAddress.Location = new System.Drawing.Point(98, 685);
            this.textBox_userAddress.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_userAddress.Name = "textBox_userAddress";
            this.textBox_userAddress.Size = new System.Drawing.Size(364, 31);
            this.textBox_userAddress.TabIndex = 15;
            this.textBox_userAddress.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userAddress.TextChanged += new System.EventHandler(this.textBox_userAddress_TextChanged);
            // 
            // label_userPhone
            // 
            this.label_userPhone.AutoSize = true;
            this.label_userPhone.Location = new System.Drawing.Point(92, 579);
            this.label_userPhone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_userPhone.Name = "label_userPhone";
            this.label_userPhone.Size = new System.Drawing.Size(96, 25);
            this.label_userPhone.TabIndex = 16;
            this.label_userPhone.Text = "Teléfono";
            // 
            // label_userAddress
            // 
            this.label_userAddress.AutoSize = true;
            this.label_userAddress.Location = new System.Drawing.Point(92, 658);
            this.label_userAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_userAddress.Name = "label_userAddress";
            this.label_userAddress.Size = new System.Drawing.Size(102, 25);
            this.label_userAddress.TabIndex = 17;
            this.label_userAddress.Text = "Dirección";
            // 
            // button_del
            // 
            this.button_del.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_del.Enabled = false;
            this.button_del.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_del.Location = new System.Drawing.Point(1744, 704);
            this.button_del.Margin = new System.Windows.Forms.Padding(6);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(150, 44);
            this.button_del.TabIndex = 18;
            this.button_del.Text = "Borrar";
            this.button_del.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_del.UseMnemonic = false;
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // comboBox_Activities_User
            // 
            this.comboBox_Activities_User.FormattingEnabled = true;
            this.comboBox_Activities_User.Location = new System.Drawing.Point(98, 308);
            this.comboBox_Activities_User.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_Activities_User.Name = "comboBox_Activities_User";
            this.comboBox_Activities_User.Size = new System.Drawing.Size(344, 33);
            this.comboBox_Activities_User.TabIndex = 19;
            this.comboBox_Activities_User.Visible = false;
            this.comboBox_Activities_User.SelectedIndexChanged += new System.EventHandler(this.comboBox_Activities_Users_SelectedIndexChanged);
            // 
            // comboBox_Activities_Categories
            // 
            this.comboBox_Activities_Categories.FormattingEnabled = true;
            this.comboBox_Activities_Categories.Location = new System.Drawing.Point(98, 383);
            this.comboBox_Activities_Categories.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_Activities_Categories.Name = "comboBox_Activities_Categories";
            this.comboBox_Activities_Categories.Size = new System.Drawing.Size(344, 33);
            this.comboBox_Activities_Categories.TabIndex = 20;
            this.comboBox_Activities_Categories.Visible = false;
            // 
            // textBox_Activities_Nombre
            // 
            this.textBox_Activities_Nombre.Location = new System.Drawing.Point(98, 460);
            this.textBox_Activities_Nombre.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Activities_Nombre.Name = "textBox_Activities_Nombre";
            this.textBox_Activities_Nombre.Size = new System.Drawing.Size(344, 31);
            this.textBox_Activities_Nombre.TabIndex = 21;
            this.textBox_Activities_Nombre.Visible = false;
            this.textBox_Activities_Nombre.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_Activities_Nombre.TextChanged += new System.EventHandler(this.textBox_Activities_Nombre_TextChanged);
            // 
            // textBox_Activities_Desc
            // 
            this.textBox_Activities_Desc.Location = new System.Drawing.Point(98, 535);
            this.textBox_Activities_Desc.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Activities_Desc.Multiline = true;
            this.textBox_Activities_Desc.Name = "textBox_Activities_Desc";
            this.textBox_Activities_Desc.Size = new System.Drawing.Size(344, 152);
            this.textBox_Activities_Desc.TabIndex = 22;
            this.textBox_Activities_Desc.Visible = false;
            this.textBox_Activities_Desc.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_Activities_Desc.TextChanged += new System.EventHandler(this.textBox_Activities_Desc_TextChanged);
            // 
            // button_Act_create
            // 
            this.button_Act_create.BackColor = System.Drawing.SystemColors.Control;
            this.button_Act_create.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_Act_create.Enabled = false;
            this.button_Act_create.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Act_create.Location = new System.Drawing.Point(168, 765);
            this.button_Act_create.Margin = new System.Windows.Forms.Padding(6);
            this.button_Act_create.Name = "button_Act_create";
            this.button_Act_create.Size = new System.Drawing.Size(150, 44);
            this.button_Act_create.TabIndex = 23;
            this.button_Act_create.Text = "Crear";
            this.button_Act_create.UseVisualStyleBackColor = false;
            this.button_Act_create.Click += new System.EventHandler(this.button_Act_create_Click);
            // 
            // comboBox_SelAct_users
            // 
            this.comboBox_SelAct_users.FormattingEnabled = true;
            this.comboBox_SelAct_users.Location = new System.Drawing.Point(506, 258);
            this.comboBox_SelAct_users.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_SelAct_users.Name = "comboBox_SelAct_users";
            this.comboBox_SelAct_users.Size = new System.Drawing.Size(238, 33);
            this.comboBox_SelAct_users.TabIndex = 19;
            this.comboBox_SelAct_users.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelAct_users_SelectedIndexChanged);
            // 
            // dtg_SelAct_Selct
            // 
            this.dtg_SelAct_Selct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SelAct_Selct.Location = new System.Drawing.Point(42, 310);
            this.dtg_SelAct_Selct.Margin = new System.Windows.Forms.Padding(6);
            this.dtg_SelAct_Selct.Name = "dtg_SelAct_Selct";
            this.dtg_SelAct_Selct.RowHeadersWidth = 82;
            this.dtg_SelAct_Selct.Size = new System.Drawing.Size(706, 413);
            this.dtg_SelAct_Selct.TabIndex = 20;
            this.dtg_SelAct_Selct.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_SelAct_Selct_CellEnter);
            // 
            // dtg_SelAct_Act
            // 
            this.dtg_SelAct_Act.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SelAct_Act.Location = new System.Drawing.Point(984, 73);
            this.dtg_SelAct_Act.Margin = new System.Windows.Forms.Padding(6);
            this.dtg_SelAct_Act.Name = "dtg_SelAct_Act";
            this.dtg_SelAct_Act.RowHeadersWidth = 82;
            this.dtg_SelAct_Act.Size = new System.Drawing.Size(896, 650);
            this.dtg_SelAct_Act.TabIndex = 21;
            this.dtg_SelAct_Act.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_SelAct_Act_CellEnter);
            // 
            // label_SelAct_Sel
            // 
            this.label_SelAct_Sel.AutoSize = true;
            this.label_SelAct_Sel.BackColor = System.Drawing.Color.Transparent;
            this.label_SelAct_Sel.Location = new System.Drawing.Point(36, 277);
            this.label_SelAct_Sel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_SelAct_Sel.Name = "label_SelAct_Sel";
            this.label_SelAct_Sel.Size = new System.Drawing.Size(267, 25);
            this.label_SelAct_Sel.TabIndex = 22;
            this.label_SelAct_Sel.Text = "Actividades seleccionadas";
            // 
            // label_SelAct_Act
            // 
            this.label_SelAct_Act.AutoSize = true;
            this.label_SelAct_Act.BackColor = System.Drawing.Color.Transparent;
            this.label_SelAct_Act.Location = new System.Drawing.Point(978, 42);
            this.label_SelAct_Act.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_SelAct_Act.Name = "label_SelAct_Act";
            this.label_SelAct_Act.Size = new System.Drawing.Size(238, 25);
            this.label_SelAct_Act.TabIndex = 23;
            this.label_SelAct_Act.Text = "Actividades disponibles";
            // 
            // button_SelAct_SelectDismiss
            // 
            this.button_SelAct_SelectDismiss.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_SelAct_SelectDismiss.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_SelAct_SelectDismiss.Location = new System.Drawing.Point(778, 419);
            this.button_SelAct_SelectDismiss.Margin = new System.Windows.Forms.Padding(6);
            this.button_SelAct_SelectDismiss.Name = "button_SelAct_SelectDismiss";
            this.button_SelAct_SelectDismiss.Size = new System.Drawing.Size(158, 42);
            this.button_SelAct_SelectDismiss.TabIndex = 24;
            this.button_SelAct_SelectDismiss.Text = "Select/Dismiss";
            this.button_SelAct_SelectDismiss.UseVisualStyleBackColor = true;
            this.button_SelAct_SelectDismiss.Click += new System.EventHandler(this.button_SelAct_SelectDismiss_Click);
            // 
            // radioButton_Balance
            // 
            this.radioButton_Balance.AutoSize = true;
            this.radioButton_Balance.Location = new System.Drawing.Point(58, 171);
            this.radioButton_Balance.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton_Balance.Name = "radioButton_Balance";
            this.radioButton_Balance.Size = new System.Drawing.Size(184, 29);
            this.radioButton_Balance.TabIndex = 25;
            this.radioButton_Balance.TabStop = true;
            this.radioButton_Balance.Tag = "balance";
            this.radioButton_Balance.Text = "Transacciones";
            this.radioButton_Balance.UseVisualStyleBackColor = true;
            this.radioButton_Balance.CheckedChanged += new System.EventHandler(this.radioButton_Balance_CheckedChanged);
            // 
            // button_Import
            // 
            this.button_Import.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_Import.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Import.Location = new System.Drawing.Point(1730, 802);
            this.button_Import.Margin = new System.Windows.Forms.Padding(6);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(164, 44);
            this.button_Import.TabIndex = 26;
            this.button_Import.Text = "Importar";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // button_Export
            // 
            this.button_Export.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_Export.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Export.Location = new System.Drawing.Point(1568, 802);
            this.button_Export.Margin = new System.Windows.Forms.Padding(6);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(150, 44);
            this.button_Export.TabIndex = 27;
            this.button_Export.Text = "Exportar";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1918, 869);
            this.Controls.Add(this.button_Export);
            this.Controls.Add(this.button_Import);
            this.Controls.Add(this.radioButton_Balance);
            this.Controls.Add(this.button_SelAct_SelectDismiss);
            this.Controls.Add(this.label_SelAct_Act);
            this.Controls.Add(this.label_SelAct_Sel);
            this.Controls.Add(this.comboBox_SelAct_users);
            this.Controls.Add(this.button_Act_create);
            this.Controls.Add(this.textBox_Activities_Desc);
            this.Controls.Add(this.textBox_Activities_Nombre);
            this.Controls.Add(this.comboBox_Activities_Categories);
            this.Controls.Add(this.comboBox_Activities_User);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.label_userAddress);
            this.Controls.Add(this.label_userPhone);
            this.Controls.Add(this.textBox_userAddress);
            this.Controls.Add(this.textBox_userPhone);
            this.Controls.Add(this.button_addUser);
            this.Controls.Add(this.textBox_userPass);
            this.Controls.Add(this.label_userPass);
            this.Controls.Add(this.label_userSurname);
            this.Controls.Add(this.textBox_userEmail);
            this.Controls.Add(this.label_userEmail);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.textBox_userSurname);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.radioButtonSel_Activities);
            this.Controls.Add(this.radioButtonActivities);
            this.Controls.Add(this.radioButtonUsers);
            this.Controls.Add(this.getUsers);
            this.Controls.Add(this.dtg1);
            this.Controls.Add(this.dtg_SelAct_Selct);
            this.Controls.Add(this.dtg_SelAct_Act);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Interfaz CRUD";
            ((System.ComponentModel.ISupportInitialize)(this.dtg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SelAct_Selct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SelAct_Act)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dtg1;
        private System.Windows.Forms.Button getUsers;
        private System.Windows.Forms.RadioButton radioButtonUsers;
        private System.Windows.Forms.RadioButton radioButtonActivities;
        private System.Windows.Forms.RadioButton radioButtonSel_Activities;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.TextBox textBox_userSurname;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label_userEmail;
        private System.Windows.Forms.TextBox textBox_userEmail;
        private System.Windows.Forms.Label label_userSurname;
        private System.Windows.Forms.Label label_userPass;
        private System.Windows.Forms.TextBox textBox_userPass;
        private System.Windows.Forms.Button button_addUser;
        private System.Windows.Forms.TextBox textBox_userPhone;
        private System.Windows.Forms.TextBox textBox_userAddress;
        private System.Windows.Forms.Label label_userPhone;
        private System.Windows.Forms.Label label_userAddress;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.ComboBox comboBox_Activities_User;
        private System.Windows.Forms.ComboBox comboBox_Activities_Categories;
        private System.Windows.Forms.TextBox textBox_Activities_Nombre;
        private System.Windows.Forms.TextBox textBox_Activities_Desc;
        private System.Windows.Forms.Button button_Act_create;
        private System.Windows.Forms.ComboBox comboBox_SelAct_users;
        private System.Windows.Forms.DataGridView dtg_SelAct_Selct;
        private System.Windows.Forms.DataGridView dtg_SelAct_Act;
        private System.Windows.Forms.Label label_SelAct_Sel;
        private System.Windows.Forms.Label label_SelAct_Act;
        private System.Windows.Forms.Button button_SelAct_SelectDismiss;
        private System.Windows.Forms.RadioButton radioButton_Balance;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.Button button_Export;
    }
}


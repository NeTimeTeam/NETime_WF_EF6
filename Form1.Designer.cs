﻿
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
            this.dtg1 = new System.Windows.Forms.DataGridView();
            this.getUsers = new System.Windows.Forms.Button();
            this.radioButtonUsers = new System.Windows.Forms.RadioButton();
            this.radioButtonActivities = new System.Windows.Forms.RadioButton();
            this.radioButtonSel_Activities = new System.Windows.Forms.RadioButton();
            this.textBox_userName = new System.Windows.Forms.MaskedTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SelAct_Selct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SelAct_Act)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg1
            // 
            this.dtg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg1.Location = new System.Drawing.Point(283, 12);
            this.dtg1.MultiSelect = false;
            this.dtg1.Name = "dtg1";
            this.dtg1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtg1.Size = new System.Drawing.Size(664, 311);
            this.dtg1.TabIndex = 0;
            this.dtg1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtg1_CellBeginEdit);
            this.dtg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg1_RowSelect);
            this.dtg1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg1_CellValueChanged);
            // 
            // getUsers
            // 
            this.getUsers.Location = new System.Drawing.Point(492, 342);
            this.getUsers.Name = "getUsers";
            this.getUsers.Size = new System.Drawing.Size(97, 47);
            this.getUsers.TabIndex = 1;
            this.getUsers.Text = "Actualizar";
            this.getUsers.UseVisualStyleBackColor = true;
            this.getUsers.Click += new System.EventHandler(this.getUsers_Click);
            // 
            // radioButtonUsers
            // 
            this.radioButtonUsers.AutoSize = true;
            this.radioButtonUsers.Location = new System.Drawing.Point(49, 54);
            this.radioButtonUsers.Name = "radioButtonUsers";
            this.radioButtonUsers.Size = new System.Drawing.Size(66, 17);
            this.radioButtonUsers.TabIndex = 2;
            this.radioButtonUsers.TabStop = true;
            this.radioButtonUsers.Text = "Usuarios";
            this.radioButtonUsers.UseVisualStyleBackColor = true;
            this.radioButtonUsers.CheckedChanged += new System.EventHandler(this.radioButtonUsers_CheckedChanged);
            // 
            // radioButtonActivities
            // 
            this.radioButtonActivities.AutoSize = true;
            this.radioButtonActivities.Location = new System.Drawing.Point(49, 77);
            this.radioButtonActivities.Name = "radioButtonActivities";
            this.radioButtonActivities.Size = new System.Drawing.Size(80, 17);
            this.radioButtonActivities.TabIndex = 3;
            this.radioButtonActivities.TabStop = true;
            this.radioButtonActivities.Text = "Actividades";
            this.radioButtonActivities.UseVisualStyleBackColor = true;
            this.radioButtonActivities.CheckedChanged += new System.EventHandler(this.radioButtonActivities_CheckedChanged);
            // 
            // radioButtonSel_Activities
            // 
            this.radioButtonSel_Activities.AutoSize = true;
            this.radioButtonSel_Activities.Location = new System.Drawing.Point(49, 100);
            this.radioButtonSel_Activities.Name = "radioButtonSel_Activities";
            this.radioButtonSel_Activities.Size = new System.Drawing.Size(153, 17);
            this.radioButtonSel_Activities.TabIndex = 4;
            this.radioButtonSel_Activities.TabStop = true;
            this.radioButtonSel_Activities.Text = "Actividades Seleccionadas";
            this.radioButtonSel_Activities.UseVisualStyleBackColor = true;
            this.radioButtonSel_Activities.CheckedChanged += new System.EventHandler(this.radioButtonSel_Activities_CheckedChanged);
            // 
            // textBox_userName
            // 
            this.textBox_userName.AccessibleDescription = "Nombre de usuario";
            this.textBox_userName.CausesValidation = false;
            this.textBox_userName.Location = new System.Drawing.Point(49, 161);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(184, 20);
            this.textBox_userName.TabIndex = 5;
            this.textBox_userName.Tag = "Nombre";            
            this.textBox_userName.CausesValidationChanged += new System.EventHandler(this.textBox_user_CausesValidationChanged);
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);            
            // 
            // textBox_userSurname
            // 
            this.textBox_userSurname.Location = new System.Drawing.Point(49, 200);
            this.textBox_userSurname.Name = "textBox_userSurname";
            this.textBox_userSurname.Size = new System.Drawing.Size(184, 20);
            this.textBox_userSurname.TabIndex = 6;
            this.textBox_userSurname.CausesValidationChanged += new System.EventHandler(this.textBox_user_CausesValidationChanged);
            this.textBox_userSurname.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(46, 145);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(44, 13);
            this.label_userName.TabIndex = 7;
            this.label_userName.Text = "Nombre";
            // 
            // label_userEmail
            // 
            this.label_userEmail.AutoSize = true;
            this.label_userEmail.Location = new System.Drawing.Point(46, 223);
            this.label_userEmail.Name = "label_userEmail";
            this.label_userEmail.Size = new System.Drawing.Size(75, 13);
            this.label_userEmail.TabIndex = 8;
            this.label_userEmail.Text = "Email (Unique)";
            // 
            // textBox_userEmail
            // 
            this.textBox_userEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_userEmail.Location = new System.Drawing.Point(49, 239);
            this.textBox_userEmail.Name = "textBox_userEmail";
            this.textBox_userEmail.Size = new System.Drawing.Size(184, 20);
            this.textBox_userEmail.TabIndex = 9;
            this.textBox_userEmail.CausesValidationChanged += new System.EventHandler(this.textBox_user_CausesValidationChanged);
            this.textBox_userEmail.TextChanged += new System.EventHandler(this.textBox_userEmail_TextChanged);
            // 
            // label_userSurname
            // 
            this.label_userSurname.AutoSize = true;
            this.label_userSurname.Location = new System.Drawing.Point(46, 184);
            this.label_userSurname.Name = "label_userSurname";
            this.label_userSurname.Size = new System.Drawing.Size(49, 13);
            this.label_userSurname.TabIndex = 10;
            this.label_userSurname.Text = "Apellidos";
            // 
            // label_userPass
            // 
            this.label_userPass.AutoSize = true;
            this.label_userPass.Location = new System.Drawing.Point(46, 262);
            this.label_userPass.Name = "label_userPass";
            this.label_userPass.Size = new System.Drawing.Size(61, 13);
            this.label_userPass.TabIndex = 11;
            this.label_userPass.Text = "Contraseña";
            // 
            // textBox_userPass
            // 
            this.textBox_userPass.Location = new System.Drawing.Point(49, 278);
            this.textBox_userPass.MaxLength = 16;
            this.textBox_userPass.Name = "textBox_userPass";
            this.textBox_userPass.PasswordChar = '*';
            this.textBox_userPass.Size = new System.Drawing.Size(184, 20);
            this.textBox_userPass.TabIndex = 12;
            this.textBox_userPass.UseSystemPasswordChar = true;
            // 
            // button_addUser
            // 
            this.button_addUser.Enabled = false;
            this.button_addUser.Location = new System.Drawing.Point(49, 398);
            this.button_addUser.Name = "button_addUser";
            this.button_addUser.Size = new System.Drawing.Size(75, 23);
            this.button_addUser.TabIndex = 13;
            this.button_addUser.Text = "Crear usuario";
            this.button_addUser.UseVisualStyleBackColor = true;
            this.button_addUser.Click += new System.EventHandler(this.button_addUser_Click);
            // 
            // textBox_userPhone
            // 
            this.textBox_userPhone.CausesValidation = false;
            this.textBox_userPhone.Location = new System.Drawing.Point(49, 316);
            this.textBox_userPhone.Name = "textBox_userPhone";
            this.textBox_userPhone.Size = new System.Drawing.Size(184, 20);
            this.textBox_userPhone.TabIndex = 14;
            this.textBox_userPhone.CausesValidationChanged += new System.EventHandler(this.textBox_user_CausesValidationChanged);
            this.textBox_userPhone.TextChanged += new System.EventHandler(this.textBox_userPhone_TextChanged);
            // 
            // textBox_userAddress
            // 
            this.textBox_userAddress.Location = new System.Drawing.Point(49, 356);
            this.textBox_userAddress.Name = "textBox_userAddress";
            this.textBox_userAddress.Size = new System.Drawing.Size(184, 20);
            this.textBox_userAddress.TabIndex = 15;
            // 
            // label_userPhone
            // 
            this.label_userPhone.AutoSize = true;
            this.label_userPhone.Location = new System.Drawing.Point(46, 301);
            this.label_userPhone.Name = "label_userPhone";
            this.label_userPhone.Size = new System.Drawing.Size(49, 13);
            this.label_userPhone.TabIndex = 16;
            this.label_userPhone.Text = "Teléfono";
            // 
            // label_userAddress
            // 
            this.label_userAddress.AutoSize = true;
            this.label_userAddress.Location = new System.Drawing.Point(46, 342);
            this.label_userAddress.Name = "label_userAddress";
            this.label_userAddress.Size = new System.Drawing.Size(52, 13);
            this.label_userAddress.TabIndex = 17;
            this.label_userAddress.Text = "Dirección";
            // 
            // button_del
            // 
            this.button_del.Enabled = false;
            this.button_del.Location = new System.Drawing.Point(872, 366);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(75, 23);
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
            this.comboBox_Activities_User.Location = new System.Drawing.Point(49, 160);
            this.comboBox_Activities_User.Name = "comboBox_Activities_User";
            this.comboBox_Activities_User.Size = new System.Drawing.Size(174, 21);
            this.comboBox_Activities_User.TabIndex = 19;
            this.comboBox_Activities_User.Visible = false;
            // 
            // comboBox_Activities_Categories
            // 
            this.comboBox_Activities_Categories.FormattingEnabled = true;
            this.comboBox_Activities_Categories.Location = new System.Drawing.Point(49, 199);
            this.comboBox_Activities_Categories.Name = "comboBox_Activities_Categories";
            this.comboBox_Activities_Categories.Size = new System.Drawing.Size(174, 21);
            this.comboBox_Activities_Categories.TabIndex = 20;
            this.comboBox_Activities_Categories.Visible = false;
            // 
            // textBox_Activities_Nombre
            // 
            this.textBox_Activities_Nombre.Location = new System.Drawing.Point(49, 239);
            this.textBox_Activities_Nombre.Name = "textBox_Activities_Nombre";
            this.textBox_Activities_Nombre.Size = new System.Drawing.Size(174, 20);
            this.textBox_Activities_Nombre.TabIndex = 21;
            this.textBox_Activities_Nombre.Visible = false;
            // 
            // textBox_Activities_Desc
            // 
            this.textBox_Activities_Desc.Location = new System.Drawing.Point(49, 278);
            this.textBox_Activities_Desc.Multiline = true;
            this.textBox_Activities_Desc.Name = "textBox_Activities_Desc";
            this.textBox_Activities_Desc.Size = new System.Drawing.Size(174, 81);
            this.textBox_Activities_Desc.TabIndex = 22;
            this.textBox_Activities_Desc.Visible = false;
            // 
            // comboBox_SelAct_users
            // 
            this.comboBox_SelAct_users.FormattingEnabled = true;
            this.comboBox_SelAct_users.Location = new System.Drawing.Point(253, 134);
            this.comboBox_SelAct_users.Name = "comboBox_SelAct_users";
            this.comboBox_SelAct_users.Size = new System.Drawing.Size(121, 21);
            this.comboBox_SelAct_users.TabIndex = 19;
            this.comboBox_SelAct_users.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelAct_users_SelectionChangeCommitted);
            // 
            // dtg_SelAct_Selct
            // 
            this.dtg_SelAct_Selct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SelAct_Selct.Location = new System.Drawing.Point(21, 161);
            this.dtg_SelAct_Selct.Name = "dtg_SelAct_Selct";
            this.dtg_SelAct_Selct.Size = new System.Drawing.Size(353, 215);
            this.dtg_SelAct_Selct.TabIndex = 20;
            // 
            // dtg_SelAct_Act
            // 
            this.dtg_SelAct_Act.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SelAct_Act.Location = new System.Drawing.Point(492, 38);
            this.dtg_SelAct_Act.Name = "dtg_SelAct_Act";
            this.dtg_SelAct_Act.Size = new System.Drawing.Size(448, 338);
            this.dtg_SelAct_Act.TabIndex = 21;
            // 
            // label_SelAct_Sel
            // 
            this.label_SelAct_Sel.AutoSize = true;
            this.label_SelAct_Sel.Location = new System.Drawing.Point(18, 144);
            this.label_SelAct_Sel.Name = "label_SelAct_Sel";
            this.label_SelAct_Sel.Size = new System.Drawing.Size(133, 13);
            this.label_SelAct_Sel.TabIndex = 22;
            this.label_SelAct_Sel.Text = "Actividades seleccionadas";
            // 
            // label_SelAct_Act
            // 
            this.label_SelAct_Act.AutoSize = true;
            this.label_SelAct_Act.Location = new System.Drawing.Point(489, 22);
            this.label_SelAct_Act.Name = "label_SelAct_Act";
            this.label_SelAct_Act.Size = new System.Drawing.Size(117, 13);
            this.label_SelAct_Act.TabIndex = 23;
            this.label_SelAct_Act.Text = "Actividades disponibles";
            // 
            // button_Act_create
            // 
            this.button_Act_create.Enabled = false;
            this.button_Act_create.Location = new System.Drawing.Point(85, 398);
            this.button_Act_create.Name = "button_Act_create";
            this.button_Act_create.Size = new System.Drawing.Size(75, 23);
            this.button_Act_create.TabIndex = 23;
            this.button_Act_create.Text = "Crear";
            this.button_Act_create.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 452);
            this.Controls.Add(this.label_SelAct_Act);
            this.Controls.Add(this.label_SelAct_Sel);
            this.Controls.Add(this.dtg_SelAct_Act);
            this.Controls.Add(this.dtg_SelAct_Selct);
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
        private System.Windows.Forms.MaskedTextBox textBox_userName;
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
    }
}


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
            ((System.ComponentModel.ISupportInitialize)(this.dtg1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg1
            // 
            this.dtg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg1.Location = new System.Drawing.Point(283, 12);
            this.dtg1.Name = "dtg1";
            this.dtg1.Size = new System.Drawing.Size(505, 253);
            this.dtg1.TabIndex = 0;
            // 
            // getUsers
            // 
            this.getUsers.Location = new System.Drawing.Point(660, 356);
            this.getUsers.Name = "getUsers";
            this.getUsers.Size = new System.Drawing.Size(97, 47);
            this.getUsers.TabIndex = 1;
            this.getUsers.Text = "Obtener usuarios";
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
            this.textBox_userName.Location = new System.Drawing.Point(49, 161);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(184, 20);
            this.textBox_userName.TabIndex = 5;
            this.textBox_userName.Tag = "Nombre";
            this.textBox_userName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.userName_MaskInputRejected);
            this.textBox_userName.Validating += new System.ComponentModel.CancelEventHandler(this.userName_Validating);
            // 
            // textBox_userSurname
            // 
            this.textBox_userSurname.Location = new System.Drawing.Point(49, 200);
            this.textBox_userSurname.Name = "textBox_userSurname";
            this.textBox_userSurname.Size = new System.Drawing.Size(184, 20);
            this.textBox_userSurname.TabIndex = 6;
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
            this.label_userEmail.Size = new System.Drawing.Size(32, 13);
            this.label_userEmail.TabIndex = 8;
            this.label_userEmail.Text = "Email";
            // 
            // textBox_userEmail
            // 
            this.textBox_userEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_userEmail.Location = new System.Drawing.Point(49, 239);
            this.textBox_userEmail.Name = "textBox_userEmail";
            this.textBox_userEmail.Size = new System.Drawing.Size(184, 20);
            this.textBox_userEmail.TabIndex = 9;
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
            this.button_addUser.Location = new System.Drawing.Point(49, 324);
            this.button_addUser.Name = "button_addUser";
            this.button_addUser.Size = new System.Drawing.Size(75, 23);
            this.button_addUser.TabIndex = 13;
            this.button_addUser.Text = "Crear usuario";
            this.button_addUser.UseVisualStyleBackColor = true;
            this.button_addUser.Click += new System.EventHandler(this.button_addUser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Text = "CRUD";
            ((System.ComponentModel.ISupportInitialize)(this.dtg1)).EndInit();
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
    }
}


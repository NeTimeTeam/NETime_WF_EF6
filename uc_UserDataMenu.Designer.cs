
namespace NETime_WF_EF6
{
    partial class UserDataMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_userDataForm = new System.Windows.Forms.GroupBox();
            this.button_ChangePass = new System.Windows.Forms.Button();
            this.label_userPass2 = new System.Windows.Forms.Label();
            this.textBox_userPass2 = new System.Windows.Forms.TextBox();
            this.label_userTel = new System.Windows.Forms.Label();
            this.textBox_userTel = new System.Windows.Forms.TextBox();
            this.label_userAddress = new System.Windows.Forms.Label();
            this.textBox_userAddress = new System.Windows.Forms.TextBox();
            this.label_userSurname = new System.Windows.Forms.Label();
            this.textBox_userSurname = new System.Windows.Forms.TextBox();
            this.label_userEmail = new System.Windows.Forms.Label();
            this.textBox_user_Email = new System.Windows.Forms.TextBox();
            this.label_userPass = new System.Windows.Forms.Label();
            this.textBox_userPass = new System.Windows.Forms.TextBox();
            this.label_userName = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.groupBox_userCounters = new System.Windows.Forms.GroupBox();
            this.label_HoursCounter = new System.Windows.Forms.Label();
            this.label_SelActivitiesCounter = new System.Windows.Forms.Label();
            this.label_ActivitiesCounter = new System.Windows.Forms.Label();
            this.label_HoursCounterLabel = new System.Windows.Forms.Label();
            this.label_SelActivitiesCounterLabel = new System.Windows.Forms.Label();
            this.label_ActivitiesCounterLabel = new System.Windows.Forms.Label();
            this.label_Msg = new System.Windows.Forms.Label();
            this.panel_Message = new System.Windows.Forms.Panel();
            this.groupBox_userDataForm.SuspendLayout();
            this.groupBox_userCounters.SuspendLayout();
            this.panel_Message.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_userDataForm
            // 
            this.groupBox_userDataForm.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox_userDataForm.Controls.Add(this.button_ChangePass);
            this.groupBox_userDataForm.Controls.Add(this.label_userPass2);
            this.groupBox_userDataForm.Controls.Add(this.textBox_userPass2);
            this.groupBox_userDataForm.Controls.Add(this.label_userTel);
            this.groupBox_userDataForm.Controls.Add(this.textBox_userTel);
            this.groupBox_userDataForm.Controls.Add(this.label_userAddress);
            this.groupBox_userDataForm.Controls.Add(this.textBox_userAddress);
            this.groupBox_userDataForm.Controls.Add(this.label_userSurname);
            this.groupBox_userDataForm.Controls.Add(this.textBox_userSurname);
            this.groupBox_userDataForm.Controls.Add(this.label_userEmail);
            this.groupBox_userDataForm.Controls.Add(this.textBox_user_Email);
            this.groupBox_userDataForm.Controls.Add(this.label_userPass);
            this.groupBox_userDataForm.Controls.Add(this.textBox_userPass);
            this.groupBox_userDataForm.Controls.Add(this.label_userName);
            this.groupBox_userDataForm.Controls.Add(this.textBox_userName);
            this.groupBox_userDataForm.Location = new System.Drawing.Point(17, 6);
            this.groupBox_userDataForm.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox_userDataForm.Name = "groupBox_userDataForm";
            this.groupBox_userDataForm.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox_userDataForm.Size = new System.Drawing.Size(602, 644);
            this.groupBox_userDataForm.TabIndex = 0;
            this.groupBox_userDataForm.TabStop = false;
            this.groupBox_userDataForm.Tag = "UserForm";
            this.groupBox_userDataForm.Text = "Edición de datos de usuario";
            // 
            // button_ChangePass
            // 
            this.button_ChangePass.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_ChangePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ChangePass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_ChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ChangePass.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ChangePass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_ChangePass.Location = new System.Drawing.Point(440, 300);
            this.button_ChangePass.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_ChangePass.Name = "button_ChangePass";
            this.button_ChangePass.Size = new System.Drawing.Size(148, 96);
            this.button_ChangePass.TabIndex = 7;
            this.button_ChangePass.Text = "Cambiar";
            this.button_ChangePass.UseVisualStyleBackColor = true;
            this.button_ChangePass.Visible = false;
            this.button_ChangePass.Click += new System.EventHandler(this.button_ChangePass_Click);
            // 
            // label_userPass2
            // 
            this.label_userPass2.AutoSize = true;
            this.label_userPass2.Location = new System.Drawing.Point(46, 344);
            this.label_userPass2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userPass2.Name = "label_userPass2";
            this.label_userPass2.Size = new System.Drawing.Size(205, 25);
            this.label_userPass2.TabIndex = 13;
            this.label_userPass2.Tag = "UserForm";
            this.label_userPass2.Text = "Repetir contraseña";
            this.label_userPass2.Visible = false;
            this.label_userPass2.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            this.label_userPass2.Leave += new System.EventHandler(this.userData_TextBoxLeave);
            // 
            // textBox_userPass2
            // 
            this.textBox_userPass2.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userPass2.Location = new System.Drawing.Point(52, 375);
            this.textBox_userPass2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_userPass2.Name = "textBox_userPass2";
            this.textBox_userPass2.PasswordChar = '-';
            this.textBox_userPass2.Size = new System.Drawing.Size(364, 32);
            this.textBox_userPass2.TabIndex = 6;
            this.textBox_userPass2.Tag = "UserForm";
            this.textBox_userPass2.UseSystemPasswordChar = true;
            this.textBox_userPass2.Visible = false;
            this.textBox_userPass2.CausesValidationChanged += new System.EventHandler(this.textBox_pass_ChangeValidation);
            this.textBox_userPass2.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            // 
            // label_userTel
            // 
            this.label_userTel.AutoSize = true;
            this.label_userTel.Location = new System.Drawing.Point(46, 419);
            this.label_userTel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userTel.Name = "label_userTel";
            this.label_userTel.Size = new System.Drawing.Size(101, 25);
            this.label_userTel.TabIndex = 11;
            this.label_userTel.Tag = "UserForm";
            this.label_userTel.Text = "Teléfono";
            // 
            // textBox_userTel
            // 
            this.textBox_userTel.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userTel.Location = new System.Drawing.Point(52, 450);
            this.textBox_userTel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_userTel.Name = "textBox_userTel";
            this.textBox_userTel.Size = new System.Drawing.Size(364, 32);
            this.textBox_userTel.TabIndex = 3;
            this.textBox_userTel.Tag = "UserForm";
            this.textBox_userTel.Text = "+34555222555";
            this.textBox_userTel.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            this.textBox_userTel.Leave += new System.EventHandler(this.userData_TextBoxLeave);
            // 
            // label_userAddress
            // 
            this.label_userAddress.AutoSize = true;
            this.label_userAddress.Location = new System.Drawing.Point(46, 494);
            this.label_userAddress.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userAddress.Name = "label_userAddress";
            this.label_userAddress.Size = new System.Drawing.Size(113, 25);
            this.label_userAddress.TabIndex = 9;
            this.label_userAddress.Tag = "UserForm";
            this.label_userAddress.Text = "Dirección";
            // 
            // textBox_userAddress
            // 
            this.textBox_userAddress.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userAddress.Location = new System.Drawing.Point(52, 525);
            this.textBox_userAddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_userAddress.Multiline = true;
            this.textBox_userAddress.Name = "textBox_userAddress";
            this.textBox_userAddress.Size = new System.Drawing.Size(364, 104);
            this.textBox_userAddress.TabIndex = 4;
            this.textBox_userAddress.Tag = "UserForm";
            this.textBox_userAddress.Text = "C\\Banco de tiempo 2, 4B";
            this.textBox_userAddress.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            this.textBox_userAddress.Leave += new System.EventHandler(this.userData_TextBoxLeave);
            // 
            // label_userSurname
            // 
            this.label_userSurname.AutoSize = true;
            this.label_userSurname.Location = new System.Drawing.Point(46, 119);
            this.label_userSurname.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userSurname.Name = "label_userSurname";
            this.label_userSurname.Size = new System.Drawing.Size(109, 25);
            this.label_userSurname.TabIndex = 7;
            this.label_userSurname.Tag = "UserForm";
            this.label_userSurname.Text = "Apellidos";
            // 
            // textBox_userSurname
            // 
            this.textBox_userSurname.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userSurname.Location = new System.Drawing.Point(52, 150);
            this.textBox_userSurname.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_userSurname.Name = "textBox_userSurname";
            this.textBox_userSurname.Size = new System.Drawing.Size(364, 32);
            this.textBox_userSurname.TabIndex = 1;
            this.textBox_userSurname.Tag = "UserForm";
            this.textBox_userSurname.Text = "Apellidos";
            this.textBox_userSurname.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            this.textBox_userSurname.Leave += new System.EventHandler(this.userData_TextBoxLeave);
            // 
            // label_userEmail
            // 
            this.label_userEmail.AutoSize = true;
            this.label_userEmail.Location = new System.Drawing.Point(46, 194);
            this.label_userEmail.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userEmail.Name = "label_userEmail";
            this.label_userEmail.Size = new System.Drawing.Size(73, 25);
            this.label_userEmail.TabIndex = 5;
            this.label_userEmail.Tag = "UserForm";
            this.label_userEmail.Text = "Email";
            // 
            // textBox_user_Email
            // 
            this.textBox_user_Email.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_user_Email.Location = new System.Drawing.Point(52, 225);
            this.textBox_user_Email.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_user_Email.Name = "textBox_user_Email";
            this.textBox_user_Email.Size = new System.Drawing.Size(364, 32);
            this.textBox_user_Email.TabIndex = 2;
            this.textBox_user_Email.Tag = "UserForm";
            this.textBox_user_Email.Text = "johnDoe@dominio.com";
            this.textBox_user_Email.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            this.textBox_user_Email.Leave += new System.EventHandler(this.userData_TextBoxLeave);
            // 
            // label_userPass
            // 
            this.label_userPass.AutoSize = true;
            this.label_userPass.Location = new System.Drawing.Point(46, 269);
            this.label_userPass.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userPass.Name = "label_userPass";
            this.label_userPass.Size = new System.Drawing.Size(129, 25);
            this.label_userPass.TabIndex = 3;
            this.label_userPass.Tag = "UserForm";
            this.label_userPass.Text = "Contraseña";
            // 
            // textBox_userPass
            // 
            this.textBox_userPass.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userPass.Location = new System.Drawing.Point(52, 300);
            this.textBox_userPass.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_userPass.Name = "textBox_userPass";
            this.textBox_userPass.PasswordChar = '-';
            this.textBox_userPass.Size = new System.Drawing.Size(364, 32);
            this.textBox_userPass.TabIndex = 5;
            this.textBox_userPass.Tag = "UserForm";
            this.textBox_userPass.UseSystemPasswordChar = true;
            this.textBox_userPass.CausesValidationChanged += new System.EventHandler(this.textBox_pass_ChangeValidation);
            this.textBox_userPass.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(46, 44);
            this.label_userName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(96, 25);
            this.label_userName.TabIndex = 1;
            this.label_userName.Tag = "UserForm";
            this.label_userName.Text = "Nombre";
            // 
            // textBox_userName
            // 
            this.textBox_userName.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userName.Location = new System.Drawing.Point(52, 75);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(1050, 32);
            this.textBox_userName.TabIndex = 0;
            this.textBox_userName.Tag = "UserForm";
            this.textBox_userName.Text = "Nombre";
            this.textBox_userName.TextChanged += new System.EventHandler(this.userData_TextBoxChanged);
            this.textBox_userName.Leave += new System.EventHandler(this.userData_TextBoxLeave);
            // 
            // groupBox_userCounters
            // 
            this.groupBox_userCounters.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox_userCounters.Controls.Add(this.label_HoursCounter);
            this.groupBox_userCounters.Controls.Add(this.label_SelActivitiesCounter);
            this.groupBox_userCounters.Controls.Add(this.label_ActivitiesCounter);
            this.groupBox_userCounters.Controls.Add(this.label_HoursCounterLabel);
            this.groupBox_userCounters.Controls.Add(this.label_SelActivitiesCounterLabel);
            this.groupBox_userCounters.Controls.Add(this.label_ActivitiesCounterLabel);
            this.groupBox_userCounters.Location = new System.Drawing.Point(633, 6);
            this.groupBox_userCounters.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox_userCounters.Name = "groupBox_userCounters";
            this.groupBox_userCounters.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox_userCounters.Size = new System.Drawing.Size(455, 644);
            this.groupBox_userCounters.TabIndex = 2;
            this.groupBox_userCounters.TabStop = false;
            this.groupBox_userCounters.Tag = "UserCounters";
            this.groupBox_userCounters.Text = "Contadores";
            // 
            // label_HoursCounter
            // 
            this.label_HoursCounter.AutoSize = true;
            this.label_HoursCounter.Location = new System.Drawing.Point(65, 529);
            this.label_HoursCounter.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_HoursCounter.Name = "label_HoursCounter";
            this.label_HoursCounter.Size = new System.Drawing.Size(31, 25);
            this.label_HoursCounter.TabIndex = 5;
            this.label_HoursCounter.Tag = "UserCounters";
            this.label_HoursCounter.Text = "- -";
            // 
            // label_SelActivitiesCounter
            // 
            this.label_SelActivitiesCounter.AutoSize = true;
            this.label_SelActivitiesCounter.Location = new System.Drawing.Point(65, 335);
            this.label_SelActivitiesCounter.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_SelActivitiesCounter.Name = "label_SelActivitiesCounter";
            this.label_SelActivitiesCounter.Size = new System.Drawing.Size(31, 25);
            this.label_SelActivitiesCounter.TabIndex = 4;
            this.label_SelActivitiesCounter.Tag = "UserCounters";
            this.label_SelActivitiesCounter.Text = "- -";
            // 
            // label_ActivitiesCounter
            // 
            this.label_ActivitiesCounter.AutoSize = true;
            this.label_ActivitiesCounter.Location = new System.Drawing.Point(65, 138);
            this.label_ActivitiesCounter.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_ActivitiesCounter.Name = "label_ActivitiesCounter";
            this.label_ActivitiesCounter.Size = new System.Drawing.Size(31, 25);
            this.label_ActivitiesCounter.TabIndex = 3;
            this.label_ActivitiesCounter.Tag = "UserCounters";
            this.label_ActivitiesCounter.Text = "- -";
            // 
            // label_HoursCounterLabel
            // 
            this.label_HoursCounterLabel.AutoSize = true;
            this.label_HoursCounterLabel.Location = new System.Drawing.Point(65, 429);
            this.label_HoursCounterLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_HoursCounterLabel.Name = "label_HoursCounterLabel";
            this.label_HoursCounterLabel.Size = new System.Drawing.Size(200, 25);
            this.label_HoursCounterLabel.TabIndex = 2;
            this.label_HoursCounterLabel.Tag = "UserCounters";
            this.label_HoursCounterLabel.Text = "Horas Disponibles";
            // 
            // label_SelActivitiesCounterLabel
            // 
            this.label_SelActivitiesCounterLabel.AutoSize = true;
            this.label_SelActivitiesCounterLabel.Location = new System.Drawing.Point(65, 235);
            this.label_SelActivitiesCounterLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_SelActivitiesCounterLabel.Name = "label_SelActivitiesCounterLabel";
            this.label_SelActivitiesCounterLabel.Size = new System.Drawing.Size(284, 25);
            this.label_SelActivitiesCounterLabel.TabIndex = 1;
            this.label_SelActivitiesCounterLabel.Tag = "UserCounters";
            this.label_SelActivitiesCounterLabel.Text = "Actividades seleccionadas";
            // 
            // label_ActivitiesCounterLabel
            // 
            this.label_ActivitiesCounterLabel.AutoSize = true;
            this.label_ActivitiesCounterLabel.Location = new System.Drawing.Point(65, 65);
            this.label_ActivitiesCounterLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_ActivitiesCounterLabel.Name = "label_ActivitiesCounterLabel";
            this.label_ActivitiesCounterLabel.Size = new System.Drawing.Size(133, 25);
            this.label_ActivitiesCounterLabel.TabIndex = 0;
            this.label_ActivitiesCounterLabel.Tag = "UserCounters";
            this.label_ActivitiesCounterLabel.Text = "Actividades";
            // 
            // label_Msg
            // 
            this.label_Msg.AutoSize = true;
            this.label_Msg.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Msg.Location = new System.Drawing.Point(46, 52);
            this.label_Msg.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_Msg.Name = "label_Msg";
            this.label_Msg.Size = new System.Drawing.Size(104, 25);
            this.label_Msg.TabIndex = 0;
            this.label_Msg.Tag = "UserMsg";
            this.label_Msg.Text = "message";
            this.label_Msg.Visible = false;
            // 
            // panel_Message
            // 
            this.panel_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Message.BackColor = System.Drawing.SystemColors.Window;
            this.panel_Message.Controls.Add(this.label_Msg);
            this.panel_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Message.Location = new System.Drawing.Point(17, 652);
            this.panel_Message.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel_Message.Name = "panel_Message";
            this.panel_Message.Size = new System.Drawing.Size(1070, 127);
            this.panel_Message.TabIndex = 5;
            this.panel_Message.Tag = "UserMsg";
            // 
            // UserDataMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel_Message);
            this.Controls.Add(this.groupBox_userCounters);
            this.Controls.Add(this.groupBox_userDataForm);
            this.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "UserDataMenu";
            this.Size = new System.Drawing.Size(1103, 785);
            this.groupBox_userDataForm.ResumeLayout(false);
            this.groupBox_userDataForm.PerformLayout();
            this.groupBox_userCounters.ResumeLayout(false);
            this.groupBox_userCounters.PerformLayout();
            this.panel_Message.ResumeLayout(false);
            this.panel_Message.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_userDataForm;
        private System.Windows.Forms.Label label_userTel;
        private System.Windows.Forms.TextBox textBox_userTel;
        private System.Windows.Forms.Label label_userAddress;
        private System.Windows.Forms.TextBox textBox_userAddress;
        private System.Windows.Forms.Label label_userSurname;
        private System.Windows.Forms.TextBox textBox_userSurname;
        private System.Windows.Forms.Label label_userEmail;
        private System.Windows.Forms.TextBox textBox_user_Email;
        private System.Windows.Forms.Label label_userPass;
        private System.Windows.Forms.TextBox textBox_userPass;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.GroupBox groupBox_userCounters;
        private System.Windows.Forms.Label label_HoursCounter;
        private System.Windows.Forms.Label label_SelActivitiesCounter;
        private System.Windows.Forms.Label label_ActivitiesCounter;
        private System.Windows.Forms.Label label_HoursCounterLabel;
        private System.Windows.Forms.Label label_SelActivitiesCounterLabel;
        private System.Windows.Forms.Label label_ActivitiesCounterLabel;
        private System.Windows.Forms.Label label_userPass2;
        private System.Windows.Forms.TextBox textBox_userPass2;
        private System.Windows.Forms.Button button_ChangePass;
        public System.Windows.Forms.Label label_Msg;
        private System.Windows.Forms.Panel panel_Message;
    }
}

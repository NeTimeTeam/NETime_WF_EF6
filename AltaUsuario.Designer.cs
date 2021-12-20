
namespace NETime_WF_EF6
{
    partial class AltaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaUsuario));
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.textBox_userSurname = new System.Windows.Forms.TextBox();
            this.textBox_userEmail = new System.Windows.Forms.TextBox();
            this.textBox_userPass = new System.Windows.Forms.TextBox();
            this.textBox_userPhone = new System.Windows.Forms.TextBox();
            this.textBox_userAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_AddUser = new System.Windows.Forms.Button();
            this.label_userPass2 = new System.Windows.Forms.Label();
            this.textBox_userPass2 = new System.Windows.Forms.TextBox();
            this.label_msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_userName
            // 
            this.textBox_userName.CausesValidation = false;
            this.textBox_userName.Location = new System.Drawing.Point(40, 78);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(173, 20);
            this.textBox_userName.TabIndex = 0;
            this.textBox_userName.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox_userSurname
            // 
            this.textBox_userSurname.CausesValidation = false;
            this.textBox_userSurname.Location = new System.Drawing.Point(40, 117);
            this.textBox_userSurname.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userSurname.Name = "textBox_userSurname";
            this.textBox_userSurname.Size = new System.Drawing.Size(173, 20);
            this.textBox_userSurname.TabIndex = 1;
            this.textBox_userSurname.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userSurname.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox_userEmail
            // 
            this.textBox_userEmail.CausesValidation = false;
            this.textBox_userEmail.Location = new System.Drawing.Point(40, 156);
            this.textBox_userEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userEmail.Name = "textBox_userEmail";
            this.textBox_userEmail.Size = new System.Drawing.Size(173, 20);
            this.textBox_userEmail.TabIndex = 2;
            this.textBox_userEmail.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userEmail.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox_userPass
            // 
            this.textBox_userPass.CausesValidation = false;
            this.textBox_userPass.Location = new System.Drawing.Point(259, 156);
            this.textBox_userPass.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userPass.Name = "textBox_userPass";
            this.textBox_userPass.PasswordChar = '*';
            this.textBox_userPass.Size = new System.Drawing.Size(200, 20);
            this.textBox_userPass.TabIndex = 3;
            this.textBox_userPass.UseSystemPasswordChar = true;
            this.textBox_userPass.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userPass.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox_userPhone
            // 
            this.textBox_userPhone.CausesValidation = false;
            this.textBox_userPhone.Location = new System.Drawing.Point(40, 195);
            this.textBox_userPhone.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userPhone.Name = "textBox_userPhone";
            this.textBox_userPhone.Size = new System.Drawing.Size(173, 20);
            this.textBox_userPhone.TabIndex = 4;
            this.textBox_userPhone.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userPhone.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBox_userAddress
            // 
            this.textBox_userAddress.CausesValidation = false;
            this.textBox_userAddress.Location = new System.Drawing.Point(259, 78);
            this.textBox_userAddress.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userAddress.Multiline = true;
            this.textBox_userAddress.Name = "textBox_userAddress";
            this.textBox_userAddress.Size = new System.Drawing.Size(200, 59);
            this.textBox_userAddress.TabIndex = 5;
            this.textBox_userAddress.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userAddress.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Teléfono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(256, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Dirección";
            // 
            // button_AddUser
            // 
            this.button_AddUser.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_AddUser.Enabled = false;
            this.button_AddUser.ForeColor = System.Drawing.SystemColors.Control;
            this.button_AddUser.Location = new System.Drawing.Point(163, 308);
            this.button_AddUser.Margin = new System.Windows.Forms.Padding(2);
            this.button_AddUser.Name = "button_AddUser";
            this.button_AddUser.Size = new System.Drawing.Size(152, 24);
            this.button_AddUser.TabIndex = 12;
            this.button_AddUser.Text = "Darme de alta";
            this.button_AddUser.UseVisualStyleBackColor = true;
            this.button_AddUser.Click += new System.EventHandler(this.button_AddUser_Click);
            // 
            // label_userPass2
            // 
            this.label_userPass2.AutoSize = true;
            this.label_userPass2.BackColor = System.Drawing.Color.Transparent;
            this.label_userPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_userPass2.Location = new System.Drawing.Point(256, 178);
            this.label_userPass2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_userPass2.Name = "label_userPass2";
            this.label_userPass2.Size = new System.Drawing.Size(111, 15);
            this.label_userPass2.TabIndex = 14;
            this.label_userPass2.Text = "Repetir contraseña";
            // 
            // textBox_userPass2
            // 
            this.textBox_userPass2.CausesValidation = false;
            this.textBox_userPass2.Location = new System.Drawing.Point(259, 195);
            this.textBox_userPass2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_userPass2.Name = "textBox_userPass2";
            this.textBox_userPass2.PasswordChar = '*';
            this.textBox_userPass2.Size = new System.Drawing.Size(200, 20);
            this.textBox_userPass2.TabIndex = 13;
            this.textBox_userPass2.UseSystemPasswordChar = true;
            this.textBox_userPass2.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_userPass2.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.Location = new System.Drawing.Point(37, 256);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(55, 13);
            this.label_msg.TabIndex = 15;
            this.label_msg.Text = "Response";
            this.label_msg.Visible = false;
            // 
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(491, 368);
            this.Controls.Add(this.label_msg);
            this.Controls.Add(this.label_userPass2);
            this.Controls.Add(this.textBox_userPass2);
            this.Controls.Add(this.button_AddUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_userAddress);
            this.Controls.Add(this.textBox_userPhone);
            this.Controls.Add(this.textBox_userPass);
            this.Controls.Add(this.textBox_userEmail);
            this.Controls.Add(this.textBox_userSurname);
            this.Controls.Add(this.textBox_userName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AltaUsuario";
            this.Text = "AltaUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.TextBox textBox_userSurname;
        private System.Windows.Forms.TextBox textBox_userEmail;
        private System.Windows.Forms.TextBox textBox_userPass;
        private System.Windows.Forms.TextBox textBox_userPhone;
        private System.Windows.Forms.TextBox textBox_userAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_AddUser;
        private System.Windows.Forms.Label label_userPass2;
        private System.Windows.Forms.TextBox textBox_userPass2;
        private System.Windows.Forms.Label label_msg;
    }
}
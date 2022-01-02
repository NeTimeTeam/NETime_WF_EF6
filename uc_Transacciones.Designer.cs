
namespace NETime_WF_EF6
{
    partial class transacciones
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
            this.groupBox_TransLog = new System.Windows.Forms.GroupBox();
            this.dataGridView_TransLog = new System.Windows.Forms.DataGridView();
            this.groupBox_Activities = new System.Windows.Forms.GroupBox();
            this.dataGridView_activities = new System.Windows.Forms.DataGridView();
            this.groupBox_transcForm = new System.Windows.Forms.GroupBox();
            this.panel_email = new System.Windows.Forms.Panel();
            this.label_email = new System.Windows.Forms.Label();
            this.panel_category = new System.Windows.Forms.Panel();
            this.label_category = new System.Windows.Forms.Label();
            this.panel_name = new System.Windows.Forms.Panel();
            this.label_name = new System.Windows.Forms.Label();
            this.label_qttyTitle = new System.Windows.Forms.Label();
            this.label_categoryTitle = new System.Windows.Forms.Label();
            this.numericUpDown_qtty = new System.Windows.Forms.NumericUpDown();
            this.label_userTitle = new System.Windows.Forms.Label();
            this.label_nameTitle = new System.Windows.Forms.Label();
            this.button_pay = new System.Windows.Forms.Button();
            this.panel_msg = new System.Windows.Forms.Panel();
            this.label_msg = new System.Windows.Forms.Label();
            this.groupBox_payed = new System.Windows.Forms.GroupBox();
            this.label_payed = new System.Windows.Forms.Label();
            this.groupBox_charged = new System.Windows.Forms.GroupBox();
            this.label_charged = new System.Windows.Forms.Label();
            this.groupBox_total = new System.Windows.Forms.GroupBox();
            this.label_total = new System.Windows.Forms.Label();
            this.groupBox_TransLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TransLog)).BeginInit();
            this.groupBox_Activities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            this.groupBox_transcForm.SuspendLayout();
            this.panel_email.SuspendLayout();
            this.panel_category.SuspendLayout();
            this.panel_name.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtty)).BeginInit();
            this.panel_msg.SuspendLayout();
            this.groupBox_payed.SuspendLayout();
            this.groupBox_charged.SuspendLayout();
            this.groupBox_total.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_TransLog
            // 
            this.groupBox_TransLog.Controls.Add(this.dataGridView_TransLog);
            this.groupBox_TransLog.Location = new System.Drawing.Point(244, 13);
            this.groupBox_TransLog.Name = "groupBox_TransLog";
            this.groupBox_TransLog.Size = new System.Drawing.Size(258, 387);
            this.groupBox_TransLog.TabIndex = 0;
            this.groupBox_TransLog.TabStop = false;
            this.groupBox_TransLog.Text = "Histórico de transacciones";
            // 
            // dataGridView_TransLog
            // 
            this.dataGridView_TransLog.AllowUserToAddRows = false;
            this.dataGridView_TransLog.AllowUserToDeleteRows = false;
            this.dataGridView_TransLog.AllowUserToOrderColumns = true;
            this.dataGridView_TransLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_TransLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TransLog.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_TransLog.Name = "dataGridView_TransLog";
            this.dataGridView_TransLog.ReadOnly = true;
            this.dataGridView_TransLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_TransLog.Size = new System.Drawing.Size(246, 362);
            this.dataGridView_TransLog.TabIndex = 0;
            this.dataGridView_TransLog.SelectionChanged += new System.EventHandler(this.dataGridView_TransLog_SelectionChanged);
            // 
            // groupBox_Activities
            // 
            this.groupBox_Activities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Activities.Controls.Add(this.dataGridView_activities);
            this.groupBox_Activities.Location = new System.Drawing.Point(3, 406);
            this.groupBox_Activities.Name = "groupBox_Activities";
            this.groupBox_Activities.Size = new System.Drawing.Size(499, 222);
            this.groupBox_Activities.TabIndex = 1;
            this.groupBox_Activities.TabStop = false;
            this.groupBox_Activities.Text = "Actividades";
            // 
            // dataGridView_activities
            // 
            this.dataGridView_activities.AllowUserToAddRows = false;
            this.dataGridView_activities.AllowUserToDeleteRows = false;
            this.dataGridView_activities.AllowUserToOrderColumns = true;
            this.dataGridView_activities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_activities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_activities.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_activities.Name = "dataGridView_activities";
            this.dataGridView_activities.ReadOnly = true;
            this.dataGridView_activities.RowHeadersVisible = false;
            this.dataGridView_activities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_activities.Size = new System.Drawing.Size(487, 197);
            this.dataGridView_activities.TabIndex = 0;
            this.dataGridView_activities.SelectionChanged += new System.EventHandler(this.dataGridView_activities_SelectionChanged);
            // 
            // groupBox_transcForm
            // 
            this.groupBox_transcForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_transcForm.Controls.Add(this.panel_email);
            this.groupBox_transcForm.Controls.Add(this.panel_category);
            this.groupBox_transcForm.Controls.Add(this.panel_name);
            this.groupBox_transcForm.Controls.Add(this.label_qttyTitle);
            this.groupBox_transcForm.Controls.Add(this.label_categoryTitle);
            this.groupBox_transcForm.Controls.Add(this.numericUpDown_qtty);
            this.groupBox_transcForm.Controls.Add(this.label_userTitle);
            this.groupBox_transcForm.Controls.Add(this.label_nameTitle);
            this.groupBox_transcForm.Controls.Add(this.button_pay);
            this.groupBox_transcForm.Location = new System.Drawing.Point(3, 80);
            this.groupBox_transcForm.Name = "groupBox_transcForm";
            this.groupBox_transcForm.Size = new System.Drawing.Size(235, 241);
            this.groupBox_transcForm.TabIndex = 2;
            this.groupBox_transcForm.TabStop = false;
            this.groupBox_transcForm.Text = "Formulario de pago";
            // 
            // panel_email
            // 
            this.panel_email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_email.Controls.Add(this.label_email);
            this.panel_email.Location = new System.Drawing.Point(86, 113);
            this.panel_email.Name = "panel_email";
            this.panel_email.Size = new System.Drawing.Size(143, 27);
            this.panel_email.TabIndex = 12;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(3, 5);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(56, 13);
            this.label_email.TabIndex = 6;
            this.label_email.Text = "User email";
            this.label_email.Visible = false;
            // 
            // panel_category
            // 
            this.panel_category.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_category.Controls.Add(this.label_category);
            this.panel_category.Location = new System.Drawing.Point(86, 74);
            this.panel_category.Name = "panel_category";
            this.panel_category.Size = new System.Drawing.Size(143, 27);
            this.panel_category.TabIndex = 11;
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Location = new System.Drawing.Point(3, 5);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(49, 13);
            this.label_category.TabIndex = 7;
            this.label_category.Text = "Category";
            this.label_category.Visible = false;
            // 
            // panel_name
            // 
            this.panel_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_name.Controls.Add(this.label_name);
            this.panel_name.Location = new System.Drawing.Point(86, 35);
            this.panel_name.Name = "panel_name";
            this.panel_name.Size = new System.Drawing.Size(143, 27);
            this.panel_name.TabIndex = 10;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(3, 5);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(70, 13);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "Activity name";
            this.label_name.Visible = false;
            // 
            // label_qttyTitle
            // 
            this.label_qttyTitle.AutoSize = true;
            this.label_qttyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_qttyTitle.Location = new System.Drawing.Point(29, 158);
            this.label_qttyTitle.Name = "label_qttyTitle";
            this.label_qttyTitle.Size = new System.Drawing.Size(44, 13);
            this.label_qttyTitle.TabIndex = 9;
            this.label_qttyTitle.Text = "Horas:";
            this.label_qttyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_categoryTitle
            // 
            this.label_categoryTitle.AutoSize = true;
            this.label_categoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_categoryTitle.Location = new System.Drawing.Point(6, 81);
            this.label_categoryTitle.Name = "label_categoryTitle";
            this.label_categoryTitle.Size = new System.Drawing.Size(67, 13);
            this.label_categoryTitle.TabIndex = 5;
            this.label_categoryTitle.Text = "Categoría:";
            this.label_categoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_qtty
            // 
            this.numericUpDown_qtty.Location = new System.Drawing.Point(86, 156);
            this.numericUpDown_qtty.Name = "numericUpDown_qtty";
            this.numericUpDown_qtty.Size = new System.Drawing.Size(143, 20);
            this.numericUpDown_qtty.TabIndex = 0;
            this.numericUpDown_qtty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_qtty.ThousandsSeparator = true;
            this.numericUpDown_qtty.ValueChanged += new System.EventHandler(this.numericUpDown_qtty_ValueChanged);
            // 
            // label_userTitle
            // 
            this.label_userTitle.AutoSize = true;
            this.label_userTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_userTitle.Location = new System.Drawing.Point(19, 120);
            this.label_userTitle.Name = "label_userTitle";
            this.label_userTitle.Size = new System.Drawing.Size(54, 13);
            this.label_userTitle.TabIndex = 3;
            this.label_userTitle.Text = "Usuario:";
            this.label_userTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_nameTitle
            // 
            this.label_nameTitle.AutoSize = true;
            this.label_nameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nameTitle.Location = new System.Drawing.Point(9, 42);
            this.label_nameTitle.Name = "label_nameTitle";
            this.label_nameTitle.Size = new System.Drawing.Size(64, 13);
            this.label_nameTitle.TabIndex = 2;
            this.label_nameTitle.Text = "Actividad:";
            this.label_nameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_pay
            // 
            this.button_pay.Enabled = false;
            this.button_pay.Location = new System.Drawing.Point(9, 210);
            this.button_pay.Name = "button_pay";
            this.button_pay.Size = new System.Drawing.Size(207, 21);
            this.button_pay.TabIndex = 1;
            this.button_pay.Text = "Pagar";
            this.button_pay.UseVisualStyleBackColor = true;
            this.button_pay.Click += new System.EventHandler(this.button_pay_Click);
            // 
            // panel_msg
            // 
            this.panel_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_msg.Controls.Add(this.label_msg);
            this.panel_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_msg.Location = new System.Drawing.Point(3, 327);
            this.panel_msg.Name = "panel_msg";
            this.panel_msg.Size = new System.Drawing.Size(235, 67);
            this.panel_msg.TabIndex = 3;
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.Location = new System.Drawing.Point(5, 20);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(73, 20);
            this.label_msg.TabIndex = 0;
            this.label_msg.Text = "messges";
            this.label_msg.Visible = false;
            // 
            // groupBox_payed
            // 
            this.groupBox_payed.Controls.Add(this.label_payed);
            this.groupBox_payed.Location = new System.Drawing.Point(10, 13);
            this.groupBox_payed.Name = "groupBox_payed";
            this.groupBox_payed.Size = new System.Drawing.Size(68, 61);
            this.groupBox_payed.TabIndex = 4;
            this.groupBox_payed.TabStop = false;
            this.groupBox_payed.Text = "Pagadas";
            // 
            // label_payed
            // 
            this.label_payed.AutoSize = true;
            this.label_payed.Location = new System.Drawing.Point(16, 29);
            this.label_payed.Name = "label_payed";
            this.label_payed.Size = new System.Drawing.Size(13, 13);
            this.label_payed.TabIndex = 0;
            this.label_payed.Text = "0";
            this.label_payed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox_charged
            // 
            this.groupBox_charged.Controls.Add(this.label_charged);
            this.groupBox_charged.Location = new System.Drawing.Point(89, 13);
            this.groupBox_charged.Name = "groupBox_charged";
            this.groupBox_charged.Size = new System.Drawing.Size(68, 61);
            this.groupBox_charged.TabIndex = 5;
            this.groupBox_charged.TabStop = false;
            this.groupBox_charged.Text = "Recibidas";
            // 
            // label_charged
            // 
            this.label_charged.AutoSize = true;
            this.label_charged.Location = new System.Drawing.Point(16, 29);
            this.label_charged.Name = "label_charged";
            this.label_charged.Size = new System.Drawing.Size(13, 13);
            this.label_charged.TabIndex = 1;
            this.label_charged.Text = "0";
            this.label_charged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox_total
            // 
            this.groupBox_total.Controls.Add(this.label_total);
            this.groupBox_total.Location = new System.Drawing.Point(166, 13);
            this.groupBox_total.Name = "groupBox_total";
            this.groupBox_total.Size = new System.Drawing.Size(68, 61);
            this.groupBox_total.TabIndex = 5;
            this.groupBox_total.TabStop = false;
            this.groupBox_total.Text = "Total";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(16, 29);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(13, 13);
            this.label_total.TabIndex = 2;
            this.label_total.Text = "0";
            this.label_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_total.TextChanged += new System.EventHandler(this.label_total_TextChanged);
            // 
            // transacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_total);
            this.Controls.Add(this.groupBox_charged);
            this.Controls.Add(this.groupBox_payed);
            this.Controls.Add(this.panel_msg);
            this.Controls.Add(this.groupBox_transcForm);
            this.Controls.Add(this.groupBox_Activities);
            this.Controls.Add(this.groupBox_TransLog);
            this.Name = "transacciones";
            this.Size = new System.Drawing.Size(505, 631);
            this.groupBox_TransLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TransLog)).EndInit();
            this.groupBox_Activities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            this.groupBox_transcForm.ResumeLayout(false);
            this.groupBox_transcForm.PerformLayout();
            this.panel_email.ResumeLayout(false);
            this.panel_email.PerformLayout();
            this.panel_category.ResumeLayout(false);
            this.panel_category.PerformLayout();
            this.panel_name.ResumeLayout(false);
            this.panel_name.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtty)).EndInit();
            this.panel_msg.ResumeLayout(false);
            this.panel_msg.PerformLayout();
            this.groupBox_payed.ResumeLayout(false);
            this.groupBox_payed.PerformLayout();
            this.groupBox_charged.ResumeLayout(false);
            this.groupBox_charged.PerformLayout();
            this.groupBox_total.ResumeLayout(false);
            this.groupBox_total.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_TransLog;
        private System.Windows.Forms.DataGridView dataGridView_TransLog;
        private System.Windows.Forms.GroupBox groupBox_Activities;
        private System.Windows.Forms.DataGridView dataGridView_activities;
        private System.Windows.Forms.GroupBox groupBox_transcForm;
        private System.Windows.Forms.Panel panel_email;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Panel panel_category;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.Panel panel_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_qttyTitle;
        private System.Windows.Forms.Label label_categoryTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_qtty;
        private System.Windows.Forms.Label label_userTitle;
        private System.Windows.Forms.Label label_nameTitle;
        private System.Windows.Forms.Button button_pay;
        private System.Windows.Forms.Panel panel_msg;
        private System.Windows.Forms.Label label_msg;
        private System.Windows.Forms.GroupBox groupBox_payed;
        private System.Windows.Forms.Label label_payed;
        private System.Windows.Forms.GroupBox groupBox_charged;
        private System.Windows.Forms.Label label_charged;
        private System.Windows.Forms.GroupBox groupBox_total;
        private System.Windows.Forms.Label label_total;
        //private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

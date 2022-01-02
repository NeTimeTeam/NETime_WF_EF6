
namespace NETime_WF_EF6
{
    partial class UserActivitiesMenu
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
            this.groupBox_ActivitiesForm = new System.Windows.Forms.GroupBox();
            this.label_msg = new System.Windows.Forms.Label();
            this.button_AddActivity = new System.Windows.Forms.Button();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.textBox_ActivityDesc = new System.Windows.Forms.TextBox();
            this.label_Description = new System.Windows.Forms.Label();
            this.label_Category = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.groupBox_UserActivities = new System.Windows.Forms.GroupBox();
            this.button_DeleteActivity = new System.Windows.Forms.Button();
            this.dataGridView_Activities = new System.Windows.Forms.DataGridView();
            this.groupBox_ActivitiesForm.SuspendLayout();
            this.groupBox_UserActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Activities)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_ActivitiesForm
            // 
            this.groupBox_ActivitiesForm.Controls.Add(this.label_msg);
            this.groupBox_ActivitiesForm.Controls.Add(this.button_AddActivity);
            this.groupBox_ActivitiesForm.Controls.Add(this.comboBox_Category);
            this.groupBox_ActivitiesForm.Controls.Add(this.textBox_ActivityDesc);
            this.groupBox_ActivitiesForm.Controls.Add(this.label_Description);
            this.groupBox_ActivitiesForm.Controls.Add(this.label_Category);
            this.groupBox_ActivitiesForm.Controls.Add(this.label_name);
            this.groupBox_ActivitiesForm.Controls.Add(this.textBox_name);
            this.groupBox_ActivitiesForm.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ActivitiesForm.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_ActivitiesForm.Location = new System.Drawing.Point(7, 594);
            this.groupBox_ActivitiesForm.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox_ActivitiesForm.Name = "groupBox_ActivitiesForm";
            this.groupBox_ActivitiesForm.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox_ActivitiesForm.Size = new System.Drawing.Size(597, 154);
            this.groupBox_ActivitiesForm.TabIndex = 0;
            this.groupBox_ActivitiesForm.TabStop = false;
            this.groupBox_ActivitiesForm.Text = "Crear actividades";
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.Location = new System.Drawing.Point(7, 133);
            this.label_msg.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(64, 15);
            this.label_msg.TabIndex = 8;
            this.label_msg.Text = "message";
            this.label_msg.Visible = false;
            // 
            // button_AddActivity
            // 
            this.button_AddActivity.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_AddActivity.Enabled = false;
            this.button_AddActivity.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddActivity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_AddActivity.Location = new System.Drawing.Point(220, 88);
            this.button_AddActivity.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_AddActivity.Name = "button_AddActivity";
            this.button_AddActivity.Size = new System.Drawing.Size(177, 23);
            this.button_AddActivity.TabIndex = 3;
            this.button_AddActivity.Text = "Crear actividad";
            this.button_AddActivity.UseVisualStyleBackColor = true;
            this.button_AddActivity.Click += new System.EventHandler(this.button_AddActivity_Click);
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(14, 88);
            this.comboBox_Category.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(193, 23);
            this.comboBox_Category.TabIndex = 2;
            // 
            // textBox_ActivityDesc
            // 
            this.textBox_ActivityDesc.CausesValidation = false;
            this.textBox_ActivityDesc.Location = new System.Drawing.Point(220, 39);
            this.textBox_ActivityDesc.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_ActivityDesc.Multiline = true;
            this.textBox_ActivityDesc.Name = "textBox_ActivityDesc";
            this.textBox_ActivityDesc.Size = new System.Drawing.Size(353, 37);
            this.textBox_ActivityDesc.TabIndex = 1;
            this.textBox_ActivityDesc.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_ActivityDesc.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Description.Location = new System.Drawing.Point(217, 19);
            this.label_Description.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(155, 14);
            this.label_Description.TabIndex = 4;
            this.label_Description.Text = "Descripción de la actividad";
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Category.Location = new System.Drawing.Point(18, 68);
            this.label_Category.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(60, 14);
            this.label_Category.TabIndex = 3;
            this.label_Category.Text = "Categoría";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(14, 19);
            this.label_name.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(133, 14);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "Nombre de la actividad";
            // 
            // textBox_name
            // 
            this.textBox_name.CausesValidation = false;
            this.textBox_name.Location = new System.Drawing.Point(14, 39);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(192, 23);
            this.textBox_name.TabIndex = 0;
            this.textBox_name.CausesValidationChanged += new System.EventHandler(this.textBox_CausesValidationChanged);
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // groupBox_UserActivities
            // 
            this.groupBox_UserActivities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_UserActivities.AutoSize = true;
            this.groupBox_UserActivities.Controls.Add(this.button_DeleteActivity);
            this.groupBox_UserActivities.Controls.Add(this.dataGridView_Activities);
            this.groupBox_UserActivities.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_UserActivities.Location = new System.Drawing.Point(7, 6);
            this.groupBox_UserActivities.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_UserActivities.Name = "groupBox_UserActivities";
            this.groupBox_UserActivities.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_UserActivities.Size = new System.Drawing.Size(600, 580);
            this.groupBox_UserActivities.TabIndex = 2;
            this.groupBox_UserActivities.TabStop = false;
            this.groupBox_UserActivities.Text = "Actividades del usuario";
            // 
            // button_DeleteActivity
            // 
            this.button_DeleteActivity.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_DeleteActivity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_DeleteActivity.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteActivity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_DeleteActivity.Location = new System.Drawing.Point(9, 524);
            this.button_DeleteActivity.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button_DeleteActivity.Name = "button_DeleteActivity";
            this.button_DeleteActivity.Size = new System.Drawing.Size(140, 32);
            this.button_DeleteActivity.TabIndex = 1;
            this.button_DeleteActivity.Text = "Borrar actividades";
            this.button_DeleteActivity.UseVisualStyleBackColor = true;
            this.button_DeleteActivity.Click += new System.EventHandler(this.button_DeleteActivity_Click);
            // 
            // dataGridView_Activities
            // 
            this.dataGridView_Activities.AllowUserToAddRows = false;
            this.dataGridView_Activities.AllowUserToDeleteRows = false;
            this.dataGridView_Activities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Activities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Activities.Location = new System.Drawing.Point(9, 21);
            this.dataGridView_Activities.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dataGridView_Activities.MultiSelect = false;
            this.dataGridView_Activities.Name = "dataGridView_Activities";
            this.dataGridView_Activities.RowHeadersVisible = false;
            this.dataGridView_Activities.RowHeadersWidth = 82;
            this.dataGridView_Activities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Activities.Size = new System.Drawing.Size(579, 491);
            this.dataGridView_Activities.TabIndex = 0;
            this.dataGridView_Activities.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Activities_CellEnter);
            this.dataGridView_Activities.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Activities_CellLeave);
            this.dataGridView_Activities.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Activities_CellValueChanged);
            // 
            // UserActivitiesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBox_UserActivities);
            this.Controls.Add(this.groupBox_ActivitiesForm);
            this.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "UserActivitiesMenu";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Size = new System.Drawing.Size(618, 760);
            this.groupBox_ActivitiesForm.ResumeLayout(false);
            this.groupBox_ActivitiesForm.PerformLayout();
            this.groupBox_UserActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Activities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ActivitiesForm;
        private System.Windows.Forms.TextBox textBox_ActivityDesc;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.GroupBox groupBox_UserActivities;
        private System.Windows.Forms.DataGridView dataGridView_Activities;
        private System.Windows.Forms.ComboBox comboBox_Category;
        private System.Windows.Forms.Button button_AddActivity;
        private System.Windows.Forms.Button button_DeleteActivity;
        private System.Windows.Forms.Label label_msg;
    }
}

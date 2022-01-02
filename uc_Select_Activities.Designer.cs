﻿
namespace NETime_WF_EF6
{
    partial class Select_Activities
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
            this.groupBox_availables = new System.Windows.Forms.GroupBox();
            this.dataGridView_Available = new System.Windows.Forms.DataGridView();
            this.groupBox_selected = new System.Windows.Forms.GroupBox();
            this.dataGridView_Selected = new System.Windows.Forms.DataGridView();
            this.panel_Control = new System.Windows.Forms.Panel();
            this.button_Dismiss = new System.Windows.Forms.Button();
            this.button_Select = new System.Windows.Forms.Button();
            this.label_msg = new System.Windows.Forms.Label();
            this.groupBox_availables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Available)).BeginInit();
            this.groupBox_selected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Selected)).BeginInit();
            this.panel_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_availables
            // 
            this.groupBox_availables.AutoSize = true;
            this.groupBox_availables.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox_availables.Controls.Add(this.dataGridView_Available);
            this.groupBox_availables.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_availables.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_availables.Location = new System.Drawing.Point(6, 0);
            this.groupBox_availables.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_availables.Name = "groupBox_availables";
            this.groupBox_availables.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_availables.Size = new System.Drawing.Size(998, 664);
            this.groupBox_availables.TabIndex = 0;
            this.groupBox_availables.TabStop = false;
            this.groupBox_availables.Text = "Actividades disponibles";
            // 
            // dataGridView_Available
            // 
            this.dataGridView_Available.AllowUserToAddRows = false;
            this.dataGridView_Available.AllowUserToDeleteRows = false;
            this.dataGridView_Available.AllowUserToOrderColumns = true;
            this.dataGridView_Available.AllowUserToResizeRows = false;
            this.dataGridView_Available.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Available.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Available.Location = new System.Drawing.Point(12, 37);
            this.dataGridView_Available.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_Available.MultiSelect = false;
            this.dataGridView_Available.Name = "dataGridView_Available";
            this.dataGridView_Available.ReadOnly = true;
            this.dataGridView_Available.RowHeadersWidth = 82;
            this.dataGridView_Available.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Available.Size = new System.Drawing.Size(974, 590);
            this.dataGridView_Available.TabIndex = 0;
            this.dataGridView_Available.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Available_CellContentDoubleClick);
            this.dataGridView_Available.SelectionChanged += new System.EventHandler(this.dataGridView_Available_SelectionChanged);
            // 
            // groupBox_selected
            // 
            this.groupBox_selected.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox_selected.Controls.Add(this.dataGridView_Selected);
            this.groupBox_selected.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_selected.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_selected.Location = new System.Drawing.Point(6, 746);
            this.groupBox_selected.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_selected.Name = "groupBox_selected";
            this.groupBox_selected.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_selected.Size = new System.Drawing.Size(998, 462);
            this.groupBox_selected.TabIndex = 1;
            this.groupBox_selected.TabStop = false;
            this.groupBox_selected.Text = "Actividades seleccionadas";
            // 
            // dataGridView_Selected
            // 
            this.dataGridView_Selected.AllowUserToAddRows = false;
            this.dataGridView_Selected.AllowUserToDeleteRows = false;
            this.dataGridView_Selected.AllowUserToOrderColumns = true;
            this.dataGridView_Selected.AllowUserToResizeRows = false;
            this.dataGridView_Selected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Selected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Selected.Location = new System.Drawing.Point(12, 37);
            this.dataGridView_Selected.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_Selected.MultiSelect = false;
            this.dataGridView_Selected.Name = "dataGridView_Selected";
            this.dataGridView_Selected.ReadOnly = true;
            this.dataGridView_Selected.RowHeadersWidth = 82;
            this.dataGridView_Selected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Selected.Size = new System.Drawing.Size(974, 387);
            this.dataGridView_Selected.TabIndex = 0;
            this.dataGridView_Selected.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Selected_CellContentDoubleClick);
            this.dataGridView_Selected.SelectionChanged += new System.EventHandler(this.dataGridView_Selected_SelectionChanged);
            // 
            // panel_Control
            // 
            this.panel_Control.BackColor = System.Drawing.Color.White;
            this.panel_Control.Controls.Add(this.button_Dismiss);
            this.panel_Control.Controls.Add(this.button_Select);
            this.panel_Control.Location = new System.Drawing.Point(6, 650);
            this.panel_Control.Margin = new System.Windows.Forms.Padding(6);
            this.panel_Control.Name = "panel_Control";
            this.panel_Control.Size = new System.Drawing.Size(992, 60);
            this.panel_Control.TabIndex = 2;
            // 
            // button_Dismiss
            // 
            this.button_Dismiss.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_Dismiss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Dismiss.Enabled = false;
            this.button_Dismiss.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Dismiss.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Dismiss.Location = new System.Drawing.Point(474, 6);
            this.button_Dismiss.Margin = new System.Windows.Forms.Padding(6);
            this.button_Dismiss.Name = "button_Dismiss";
            this.button_Dismiss.Size = new System.Drawing.Size(152, 46);
            this.button_Dismiss.TabIndex = 1;
            this.button_Dismiss.Text = "Quitar";
            this.button_Dismiss.UseVisualStyleBackColor = true;
            this.button_Dismiss.Click += new System.EventHandler(this.button_Dismiss_Click);
            // 
            // button_Select
            // 
            this.button_Select.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Select.Enabled = false;
            this.button_Select.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Select.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Select.Location = new System.Drawing.Point(322, 6);
            this.button_Select.Margin = new System.Windows.Forms.Padding(6);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(140, 46);
            this.button_Select.TabIndex = 0;
            this.button_Select.Text = "Añadir";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_msg.ForeColor = System.Drawing.Color.Navy;
            this.label_msg.Location = new System.Drawing.Point(12, 715);
            this.label_msg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(57, 25);
            this.label_msg.TabIndex = 3;
            this.label_msg.Text = "msg";
            this.label_msg.Visible = false;
            // 
            // Select_Activities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label_msg);
            this.Controls.Add(this.panel_Control);
            this.Controls.Add(this.groupBox_selected);
            this.Controls.Add(this.groupBox_availables);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Select_Activities";
            this.Size = new System.Drawing.Size(1010, 1213);
            this.groupBox_availables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Available)).EndInit();
            this.groupBox_selected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Selected)).EndInit();
            this.panel_Control.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_availables;
        private System.Windows.Forms.GroupBox groupBox_selected;
        private System.Windows.Forms.DataGridView dataGridView_Selected;
        private System.Windows.Forms.DataGridView dataGridView_Available;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Button button_Dismiss;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Label label_msg;
    }
}

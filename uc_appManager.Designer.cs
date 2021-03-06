namespace NETime_WF_EF6
{
    partial class appManager
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
            this.components = new System.ComponentModel.Container();
            this.groupBox_menu = new System.Windows.Forms.GroupBox();
            this.groupBox_export = new System.Windows.Forms.GroupBox();
            this.button_export_users = new System.Windows.Forms.Button();
            this.button_export_activities = new System.Windows.Forms.Button();
            this.button_export_balance = new System.Windows.Forms.Button();
            this.button_export_categories = new System.Windows.Forms.Button();
            this.groupBox_import = new System.Windows.Forms.GroupBox();
            this.button_import_users = new System.Windows.Forms.Button();
            this.button_import_categories = new System.Windows.Forms.Button();
            this.groupBox_delete = new System.Windows.Forms.GroupBox();
            this.groupBox_db = new System.Windows.Forms.GroupBox();
            this.button_db_categories = new System.Windows.Forms.Button();
            this.button_db_selAct = new System.Windows.Forms.Button();
            this.button_db_balance = new System.Windows.Forms.Button();
            this.button_db_activities = new System.Windows.Forms.Button();
            this.button_db_users = new System.Windows.Forms.Button();
            this.button_delete_all = new System.Windows.Forms.Button();
            this.groupBox_user = new System.Windows.Forms.GroupBox();
            this.comboBox_users_list = new System.Windows.Forms.ComboBox();
            this.button_delete_balance = new System.Windows.Forms.Button();
            this.button_delete_selAct = new System.Windows.Forms.Button();
            this.button_delete_user = new System.Windows.Forms.Button();
            this.button_delete_activities = new System.Windows.Forms.Button();
            this.groupBox_info = new System.Windows.Forms.GroupBox();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_activities = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_selection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_balance = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_counters = new System.Windows.Forms.Timer(this.components);
            this.groupBox_menu.SuspendLayout();
            this.groupBox_export.SuspendLayout();
            this.groupBox_import.SuspendLayout();
            this.groupBox_delete.SuspendLayout();
            this.groupBox_db.SuspendLayout();
            this.groupBox_user.SuspendLayout();
            this.groupBox_info.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_menu
            // 
            this.groupBox_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox_menu.Controls.Add(this.groupBox_export);
            this.groupBox_menu.Controls.Add(this.groupBox_import);
            this.groupBox_menu.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_menu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox_menu.Location = new System.Drawing.Point(3, 3);
            this.groupBox_menu.Name = "groupBox_menu";
            this.groupBox_menu.Size = new System.Drawing.Size(203, 392);
            this.groupBox_menu.TabIndex = 0;
            this.groupBox_menu.TabStop = false;
            this.groupBox_menu.Text = "Importar / Exportar";
            // 
            // groupBox_export
            // 
            this.groupBox_export.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox_export.Controls.Add(this.button_export_users);
            this.groupBox_export.Controls.Add(this.button_export_activities);
            this.groupBox_export.Controls.Add(this.button_export_balance);
            this.groupBox_export.Controls.Add(this.button_export_categories);
            this.groupBox_export.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_export.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_export.Location = new System.Drawing.Point(6, 40);
            this.groupBox_export.Name = "groupBox_export";
            this.groupBox_export.Size = new System.Drawing.Size(191, 210);
            this.groupBox_export.TabIndex = 5;
            this.groupBox_export.TabStop = false;
            this.groupBox_export.Text = "Exportar";
            // 
            // button_export_users
            // 
            this.button_export_users.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_export_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_export_users.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_export_users.Location = new System.Drawing.Point(6, 158);
            this.button_export_users.Name = "button_export_users";
            this.button_export_users.Size = new System.Drawing.Size(179, 36);
            this.button_export_users.TabIndex = 3;
            this.button_export_users.Text = "Usuarios";
            this.button_export_users.UseVisualStyleBackColor = true;
            this.button_export_users.Click += new System.EventHandler(this.button_export_users_Click);
            // 
            // button_export_activities
            // 
            this.button_export_activities.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_export_activities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_export_activities.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_export_activities.Location = new System.Drawing.Point(6, 31);
            this.button_export_activities.Name = "button_export_activities";
            this.button_export_activities.Size = new System.Drawing.Size(179, 36);
            this.button_export_activities.TabIndex = 0;
            this.button_export_activities.Text = "Actividades";
            this.button_export_activities.UseVisualStyleBackColor = true;
            this.button_export_activities.Click += new System.EventHandler(this.button_export_activities_Click);
            // 
            // button_export_balance
            // 
            this.button_export_balance.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_export_balance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_export_balance.Enabled = false;
            this.button_export_balance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_export_balance.Location = new System.Drawing.Point(6, 73);
            this.button_export_balance.Name = "button_export_balance";
            this.button_export_balance.Size = new System.Drawing.Size(179, 36);
            this.button_export_balance.TabIndex = 1;
            this.button_export_balance.Text = "Balance";
            this.button_export_balance.UseVisualStyleBackColor = true;
            this.button_export_balance.Click += new System.EventHandler(this.button_export_balance_Click);
            // 
            // button_export_categories
            // 
            this.button_export_categories.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_export_categories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_export_categories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_export_categories.Location = new System.Drawing.Point(6, 115);
            this.button_export_categories.Name = "button_export_categories";
            this.button_export_categories.Size = new System.Drawing.Size(179, 36);
            this.button_export_categories.TabIndex = 2;
            this.button_export_categories.Text = "Categorias";
            this.button_export_categories.UseVisualStyleBackColor = true;
            this.button_export_categories.Click += new System.EventHandler(this.button_export_categories_Click);
            // 
            // groupBox_import
            // 
            this.groupBox_import.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox_import.Controls.Add(this.button_import_users);
            this.groupBox_import.Controls.Add(this.button_import_categories);
            this.groupBox_import.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_import.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_import.Location = new System.Drawing.Point(6, 268);
            this.groupBox_import.Name = "groupBox_import";
            this.groupBox_import.Size = new System.Drawing.Size(191, 113);
            this.groupBox_import.TabIndex = 4;
            this.groupBox_import.TabStop = false;
            this.groupBox_import.Text = "Importar";
            // 
            // button_import_users
            // 
            this.button_import_users.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_import_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_import_users.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_import_users.Location = new System.Drawing.Point(6, 71);
            this.button_import_users.Name = "button_import_users";
            this.button_import_users.Size = new System.Drawing.Size(179, 36);
            this.button_import_users.TabIndex = 4;
            this.button_import_users.Text = "Usuarios";
            this.button_import_users.UseVisualStyleBackColor = true;
            this.button_import_users.Click += new System.EventHandler(this.button_import_users_Click);
            // 
            // button_import_categories
            // 
            this.button_import_categories.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_import_categories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_import_categories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_import_categories.Location = new System.Drawing.Point(6, 29);
            this.button_import_categories.Name = "button_import_categories";
            this.button_import_categories.Size = new System.Drawing.Size(179, 36);
            this.button_import_categories.TabIndex = 3;
            this.button_import_categories.Text = "Categorias";
            this.button_import_categories.UseVisualStyleBackColor = true;
            this.button_import_categories.Click += new System.EventHandler(this.button_import_categories_Click);
            // 
            // groupBox_delete
            // 
            this.groupBox_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox_delete.Controls.Add(this.groupBox_db);
            this.groupBox_delete.Controls.Add(this.groupBox_user);
            this.groupBox_delete.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_delete.ForeColor = System.Drawing.Color.White;
            this.groupBox_delete.Location = new System.Drawing.Point(209, 3);
            this.groupBox_delete.Name = "groupBox_delete";
            this.groupBox_delete.Size = new System.Drawing.Size(406, 392);
            this.groupBox_delete.TabIndex = 5;
            this.groupBox_delete.TabStop = false;
            this.groupBox_delete.Text = "Eliminar registros";
            // 
            // groupBox_db
            // 
            this.groupBox_db.BackColor = System.Drawing.Color.White;
            this.groupBox_db.Controls.Add(this.button_db_categories);
            this.groupBox_db.Controls.Add(this.button_db_selAct);
            this.groupBox_db.Controls.Add(this.button_db_balance);
            this.groupBox_db.Controls.Add(this.button_db_activities);
            this.groupBox_db.Controls.Add(this.button_db_users);
            this.groupBox_db.Controls.Add(this.button_delete_all);
            this.groupBox_db.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_db.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox_db.Location = new System.Drawing.Point(203, 40);
            this.groupBox_db.Name = "groupBox_db";
            this.groupBox_db.Size = new System.Drawing.Size(190, 341);
            this.groupBox_db.TabIndex = 6;
            this.groupBox_db.TabStop = false;
            this.groupBox_db.Text = "Base de datos";
            // 
            // button_db_categories
            // 
            this.button_db_categories.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_db_categories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_db_categories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_db_categories.Location = new System.Drawing.Point(5, 199);
            this.button_db_categories.Name = "button_db_categories";
            this.button_db_categories.Size = new System.Drawing.Size(179, 36);
            this.button_db_categories.TabIndex = 13;
            this.button_db_categories.Text = "Categorias";
            this.button_db_categories.UseVisualStyleBackColor = true;
            this.button_db_categories.Click += new System.EventHandler(this.button_db_categories_Click);
            // 
            // button_db_selAct
            // 
            this.button_db_selAct.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_db_selAct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_db_selAct.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_db_selAct.Location = new System.Drawing.Point(5, 73);
            this.button_db_selAct.Name = "button_db_selAct";
            this.button_db_selAct.Size = new System.Drawing.Size(179, 36);
            this.button_db_selAct.TabIndex = 12;
            this.button_db_selAct.Text = "Selección";
            this.button_db_selAct.UseVisualStyleBackColor = true;
            this.button_db_selAct.Click += new System.EventHandler(this.button_db_selAct_Click);
            // 
            // button_db_balance
            // 
            this.button_db_balance.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_db_balance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_db_balance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_db_balance.Location = new System.Drawing.Point(5, 31);
            this.button_db_balance.Name = "button_db_balance";
            this.button_db_balance.Size = new System.Drawing.Size(179, 36);
            this.button_db_balance.TabIndex = 11;
            this.button_db_balance.Text = "Balances";
            this.button_db_balance.UseVisualStyleBackColor = true;
            this.button_db_balance.Click += new System.EventHandler(this.button_db_balance_Click);
            // 
            // button_db_activities
            // 
            this.button_db_activities.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_db_activities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_db_activities.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_db_activities.Location = new System.Drawing.Point(5, 115);
            this.button_db_activities.Name = "button_db_activities";
            this.button_db_activities.Size = new System.Drawing.Size(179, 36);
            this.button_db_activities.TabIndex = 10;
            this.button_db_activities.Text = "Actividades";
            this.button_db_activities.UseVisualStyleBackColor = true;
            this.button_db_activities.Click += new System.EventHandler(this.button_db_activities_Click);
            // 
            // button_db_users
            // 
            this.button_db_users.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_db_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_db_users.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_db_users.Location = new System.Drawing.Point(5, 157);
            this.button_db_users.Name = "button_db_users";
            this.button_db_users.Size = new System.Drawing.Size(179, 36);
            this.button_db_users.TabIndex = 9;
            this.button_db_users.Text = "Usuarios";
            this.button_db_users.UseVisualStyleBackColor = true;
            this.button_db_users.Click += new System.EventHandler(this.button_db_users_Click);
            // 
            // button_delete_all
            // 
            this.button_delete_all.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_delete_all.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_delete_all.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_delete_all.Location = new System.Drawing.Point(6, 299);
            this.button_delete_all.Name = "button_delete_all";
            this.button_delete_all.Size = new System.Drawing.Size(179, 36);
            this.button_delete_all.TabIndex = 7;
            this.button_delete_all.Text = "Borrado total";
            this.button_delete_all.UseVisualStyleBackColor = true;
            this.button_delete_all.Click += new System.EventHandler(this.button_delete_all_Click);
            // 
            // groupBox_user
            // 
            this.groupBox_user.BackColor = System.Drawing.Color.White;
            this.groupBox_user.Controls.Add(this.comboBox_users_list);
            this.groupBox_user.Controls.Add(this.button_delete_balance);
            this.groupBox_user.Controls.Add(this.button_delete_selAct);
            this.groupBox_user.Controls.Add(this.button_delete_user);
            this.groupBox_user.Controls.Add(this.button_delete_activities);
            this.groupBox_user.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox_user.Location = new System.Drawing.Point(6, 40);
            this.groupBox_user.Name = "groupBox_user";
            this.groupBox_user.Size = new System.Drawing.Size(191, 341);
            this.groupBox_user.TabIndex = 9;
            this.groupBox_user.TabStop = false;
            this.groupBox_user.Text = "Usuario";
            // 
            // comboBox_users_list
            // 
            this.comboBox_users_list.FormattingEnabled = true;
            this.comboBox_users_list.Location = new System.Drawing.Point(6, 39);
            this.comboBox_users_list.Name = "comboBox_users_list";
            this.comboBox_users_list.Size = new System.Drawing.Size(179, 23);
            this.comboBox_users_list.TabIndex = 9;
            // 
            // button_delete_balance
            // 
            this.button_delete_balance.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_delete_balance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_delete_balance.Location = new System.Drawing.Point(6, 73);
            this.button_delete_balance.Name = "button_delete_balance";
            this.button_delete_balance.Size = new System.Drawing.Size(179, 36);
            this.button_delete_balance.TabIndex = 5;
            this.button_delete_balance.Text = "Balance";
            this.button_delete_balance.UseVisualStyleBackColor = true;
            this.button_delete_balance.Click += new System.EventHandler(this.button_delete_balance_Click);
            // 
            // button_delete_selAct
            // 
            this.button_delete_selAct.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_delete_selAct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_delete_selAct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_delete_selAct.Location = new System.Drawing.Point(6, 115);
            this.button_delete_selAct.Name = "button_delete_selAct";
            this.button_delete_selAct.Size = new System.Drawing.Size(179, 36);
            this.button_delete_selAct.TabIndex = 8;
            this.button_delete_selAct.Text = "Selección";
            this.button_delete_selAct.UseVisualStyleBackColor = true;
            this.button_delete_selAct.Click += new System.EventHandler(this.button_delete_selAct_Click);
            // 
            // button_delete_user
            // 
            this.button_delete_user.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_delete_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_delete_user.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_delete_user.Location = new System.Drawing.Point(6, 299);
            this.button_delete_user.Name = "button_delete_user";
            this.button_delete_user.Size = new System.Drawing.Size(179, 36);
            this.button_delete_user.TabIndex = 3;
            this.button_delete_user.Text = "Usuario";
            this.button_delete_user.UseVisualStyleBackColor = true;
            this.button_delete_user.Click += new System.EventHandler(this.button_delete_user_Click);
            // 
            // button_delete_activities
            // 
            this.button_delete_activities.BackgroundImage = global::NETime_WF_EF6.Properties.Resources.boton__1_;
            this.button_delete_activities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_delete_activities.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_delete_activities.Location = new System.Drawing.Point(6, 158);
            this.button_delete_activities.Name = "button_delete_activities";
            this.button_delete_activities.Size = new System.Drawing.Size(179, 36);
            this.button_delete_activities.TabIndex = 4;
            this.button_delete_activities.Text = "Actividades";
            this.button_delete_activities.UseVisualStyleBackColor = true;
            this.button_delete_activities.Click += new System.EventHandler(this.button_delete_activities_Click);
            // 
            // groupBox_info
            // 
            this.groupBox_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox_info.Controls.Add(this.textBox_info);
            this.groupBox_info.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_info.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox_info.Location = new System.Drawing.Point(6, 401);
            this.groupBox_info.Name = "groupBox_info";
            this.groupBox_info.Size = new System.Drawing.Size(612, 334);
            this.groupBox_info.TabIndex = 1;
            this.groupBox_info.TabStop = false;
            this.groupBox_info.Text = "Información";
            // 
            // textBox_info
            // 
            this.textBox_info.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_info.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_info.Location = new System.Drawing.Point(6, 22);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new System.Drawing.Size(600, 306);
            this.textBox_info.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_user,
            this.toolStripStatusLabel_activities,
            this.toolStripStatusLabel_selection,
            this.toolStripStatusLabel_balance});
            this.statusStrip1.Location = new System.Drawing.Point(0, 738);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(618, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            // 
            // toolStripStatusLabel_user
            // 
            this.toolStripStatusLabel_user.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel_user.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_user.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel_user.Name = "toolStripStatusLabel_user";
            this.toolStripStatusLabel_user.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel_user.Size = new System.Drawing.Size(133, 20);
            this.toolStripStatusLabel_user.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel_activities
            // 
            this.toolStripStatusLabel_activities.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel_activities.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_activities.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel_activities.Name = "toolStripStatusLabel_activities";
            this.toolStripStatusLabel_activities.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel_activities.Size = new System.Drawing.Size(133, 20);
            this.toolStripStatusLabel_activities.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel_selection
            // 
            this.toolStripStatusLabel_selection.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel_selection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_selection.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel_selection.Name = "toolStripStatusLabel_selection";
            this.toolStripStatusLabel_selection.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel_selection.Size = new System.Drawing.Size(133, 20);
            this.toolStripStatusLabel_selection.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel_balance
            // 
            this.toolStripStatusLabel_balance.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel_balance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_balance.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel_balance.Name = "toolStripStatusLabel_balance";
            this.toolStripStatusLabel_balance.Size = new System.Drawing.Size(131, 20);
            this.toolStripStatusLabel_balance.Text = "toolStripStatusLabel1";
            // 
            // timer_counters
            // 
            this.timer_counters.Interval = 2000;
            this.timer_counters.Tick += new System.EventHandler(this.timer_counters_Tick);
            // 
            // appManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_delete);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_info);
            this.Controls.Add(this.groupBox_menu);
            this.Name = "appManager";
            this.Size = new System.Drawing.Size(618, 760);
            this.groupBox_menu.ResumeLayout(false);
            this.groupBox_export.ResumeLayout(false);
            this.groupBox_import.ResumeLayout(false);
            this.groupBox_delete.ResumeLayout(false);
            this.groupBox_db.ResumeLayout(false);
            this.groupBox_user.ResumeLayout(false);
            this.groupBox_info.ResumeLayout(false);
            this.groupBox_info.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_menu;
        private System.Windows.Forms.GroupBox groupBox_info;
        private System.Windows.Forms.GroupBox groupBox_delete;
        private System.Windows.Forms.GroupBox groupBox_db;
        private System.Windows.Forms.Button button_db_categories;
        private System.Windows.Forms.Button button_db_selAct;
        private System.Windows.Forms.Button button_db_balance;
        private System.Windows.Forms.Button button_db_activities;
        private System.Windows.Forms.Button button_db_users;
        private System.Windows.Forms.Button button_delete_all;
        private System.Windows.Forms.GroupBox groupBox_user;
        private System.Windows.Forms.Button button_delete_balance;
        private System.Windows.Forms.Button button_delete_selAct;
        private System.Windows.Forms.Button button_delete_user;
        private System.Windows.Forms.Button button_delete_activities;
        private System.Windows.Forms.GroupBox groupBox_export;
        private System.Windows.Forms.Button button_export_activities;
        private System.Windows.Forms.Button button_export_balance;
        private System.Windows.Forms.Button button_export_categories;
        private System.Windows.Forms.GroupBox groupBox_import;
        private System.Windows.Forms.Button button_import_categories;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_user;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_activities;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_selection;
        private System.Windows.Forms.Button button_export_users;
        private System.Windows.Forms.Button button_import_users;
        private System.Windows.Forms.ComboBox comboBox_users_list;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_balance;
        private System.Windows.Forms.Timer timer_counters;
    }
}

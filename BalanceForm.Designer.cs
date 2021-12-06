
namespace NETime_WF_EF6
{
    partial class BalanceForm
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
            this.numericUpDown_qtty = new System.Windows.Forms.NumericUpDown();
            this.button_pay = new System.Windows.Forms.Button();
            this.comboBox_payer = new System.Windows.Forms.ComboBox();
            this.comboBox_Activity = new System.Windows.Forms.ComboBox();
            this.label_payer = new System.Windows.Forms.Label();
            this.label_activity = new System.Windows.Forms.Label();
            this.label_qttty = new System.Windows.Forms.Label();
            this.dgt_balance = new System.Windows.Forms.DataGridView();
            this.label_transactions = new System.Windows.Forms.Label();
            this.textBox_total_hours = new System.Windows.Forms.TextBox();
            this.label_total_hours = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgt_balance)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_qtty
            // 
            this.numericUpDown_qtty.Location = new System.Drawing.Point(153, 139);
            this.numericUpDown_qtty.Name = "numericUpDown_qtty";
            this.numericUpDown_qtty.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_qtty.TabIndex = 0;
            this.numericUpDown_qtty.ValueChanged += new System.EventHandler(this.numericUpDown_qtty_ValueChanged);
            // 
            // button_pay
            // 
            this.button_pay.Enabled = false;
            this.button_pay.Location = new System.Drawing.Point(23, 178);
            this.button_pay.Name = "button_pay";
            this.button_pay.Size = new System.Drawing.Size(78, 23);
            this.button_pay.TabIndex = 1;
            this.button_pay.Tag = "balance";
            this.button_pay.Text = "Pagar";
            this.button_pay.UseVisualStyleBackColor = true;
            this.button_pay.Click += new System.EventHandler(this.button_pay_Click);
            // 
            // comboBox_payer
            // 
            this.comboBox_payer.FormattingEnabled = true;
            this.comboBox_payer.Location = new System.Drawing.Point(22, 93);
            this.comboBox_payer.Name = "comboBox_payer";
            this.comboBox_payer.Size = new System.Drawing.Size(121, 21);
            this.comboBox_payer.TabIndex = 2;
            this.comboBox_payer.SelectedIndexChanged += new System.EventHandler(this.comboBox_payer_SelectedIndexChanged);
            // 
            // comboBox_Activity
            // 
            this.comboBox_Activity.FormattingEnabled = true;
            this.comboBox_Activity.Location = new System.Drawing.Point(23, 139);
            this.comboBox_Activity.Name = "comboBox_Activity";
            this.comboBox_Activity.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Activity.TabIndex = 3;
            // 
            // label_payer
            // 
            this.label_payer.AutoSize = true;
            this.label_payer.Location = new System.Drawing.Point(19, 77);
            this.label_payer.Name = "label_payer";
            this.label_payer.Size = new System.Drawing.Size(47, 13);
            this.label_payer.TabIndex = 4;
            this.label_payer.Text = "Pagador";
            // 
            // label_activity
            // 
            this.label_activity.AutoSize = true;
            this.label_activity.Location = new System.Drawing.Point(19, 123);
            this.label_activity.Name = "label_activity";
            this.label_activity.Size = new System.Drawing.Size(51, 13);
            this.label_activity.TabIndex = 5;
            this.label_activity.Text = "Actividad";
            // 
            // label_qttty
            // 
            this.label_qttty.AutoSize = true;
            this.label_qttty.Location = new System.Drawing.Point(149, 123);
            this.label_qttty.Name = "label_qttty";
            this.label_qttty.Size = new System.Drawing.Size(76, 13);
            this.label_qttty.TabIndex = 6;
            this.label_qttty.Text = "Núm. de horas";
            // 
            // dgt_balance
            // 
            this.dgt_balance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgt_balance.Location = new System.Drawing.Point(270, 46);
            this.dgt_balance.Name = "dgt_balance";
            this.dgt_balance.ReadOnly = true;
            this.dgt_balance.Size = new System.Drawing.Size(268, 260);
            this.dgt_balance.TabIndex = 7;
            this.dgt_balance.Tag = "balance";
            // 
            // label_transactions
            // 
            this.label_transactions.AutoSize = true;
            this.label_transactions.Location = new System.Drawing.Point(267, 30);
            this.label_transactions.Name = "label_transactions";
            this.label_transactions.Size = new System.Drawing.Size(77, 13);
            this.label_transactions.TabIndex = 8;
            this.label_transactions.Tag = "balance";
            this.label_transactions.Text = "Transacciones";
            // 
            // textBox_total_hours
            // 
            this.textBox_total_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_total_hours.Location = new System.Drawing.Point(22, 46);
            this.textBox_total_hours.Name = "textBox_total_hours";
            this.textBox_total_hours.ReadOnly = true;
            this.textBox_total_hours.Size = new System.Drawing.Size(44, 26);
            this.textBox_total_hours.TabIndex = 9;
            this.textBox_total_hours.Tag = "balance";
            // 
            // label_total_hours
            // 
            this.label_total_hours.AutoSize = true;
            this.label_total_hours.Location = new System.Drawing.Point(19, 30);
            this.label_total_hours.Name = "label_total_hours";
            this.label_total_hours.Size = new System.Drawing.Size(90, 13);
            this.label_total_hours.TabIndex = 10;
            this.label_total_hours.Tag = "balance";
            this.label_total_hours.Text = "Horas disponibles";
            // 
            // BalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 325);
            this.Controls.Add(this.label_total_hours);
            this.Controls.Add(this.textBox_total_hours);
            this.Controls.Add(this.label_transactions);
            this.Controls.Add(this.dgt_balance);
            this.Controls.Add(this.label_qttty);
            this.Controls.Add(this.label_activity);
            this.Controls.Add(this.label_payer);
            this.Controls.Add(this.comboBox_Activity);
            this.Controls.Add(this.comboBox_payer);
            this.Controls.Add(this.button_pay);
            this.Controls.Add(this.numericUpDown_qtty);
            this.Name = "BalanceForm";
            this.Tag = "balance";
            this.Text = "Transacciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BalanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgt_balance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_qtty;
        private System.Windows.Forms.Button button_pay;
        private System.Windows.Forms.ComboBox comboBox_payer;
        private System.Windows.Forms.ComboBox comboBox_Activity;
        private System.Windows.Forms.Label label_payer;
        private System.Windows.Forms.Label label_activity;
        private System.Windows.Forms.Label label_qttty;
        private System.Windows.Forms.DataGridView dgt_balance;
        private System.Windows.Forms.Label label_transactions;
        private System.Windows.Forms.TextBox textBox_total_hours;
        private System.Windows.Forms.Label label_total_hours;
    }
}
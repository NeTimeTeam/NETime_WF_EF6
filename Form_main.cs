using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETime_WF_EF6
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }
        public Form_main(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            SetPanelUser();
        }

        //UserVar
        private int userId;

        //UserControlForms
        private UserDataMenu udm;
        private UserActivitiesMenu uam;
        
        //Función de inicio.
        private void SetPanelUser()
        {
            udm = new UserDataMenu(userId);
            uam = new UserActivitiesMenu();            
            hideAllUserContro();
            panel_ContainerInterface.Controls.Add(this.uam);
            panel_ContainerInterface.Controls.Add(this.udm);
            this.udm.Show();
            this.label_title.Text = "Datos de cuenta del usuario";
        }

        private void pictureBox_Activities_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click userActivities");
            hideAllUserContro();
            this.uam.Show();
            this.label_title.Text = "Actividades del usuario";
            
        }

        private void pictureBox_UserData_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click userData");
            udm.reLoad();
            hideAllUserContro();
            this.udm.Show();
            this.label_title.Text = "Datos de cuenta del usuario";
        }
        private void hideAllUserContro()
        {
            this.udm.Hide();
            this.uam.Hide();
        }


    }
}

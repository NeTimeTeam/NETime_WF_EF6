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

        //C# winform How To Remove Screen Flickering Issue
        //https://www.youtube.com/watch?v=HQ0UYIuzucI
        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }

        //UserVar
        private int userId;

        //UserControlForms
        private UserDataMenu udm;
        private UserActivitiesMenu uam;
        private Select_Activities sa;
        
        //Función de inicio.
        private void SetPanelUser()
        {
            //udm = new UserDataMenu();
            //uam = new UserActivitiesMenu();

            //hideAllUserContro();
            //panel_ContainerInterface.Controls.Add(this.uam);
            //panel_ContainerInterface.Controls.Add(this.udm);
            //this.udm.Show();
            //this.label_title.Text = "Datos de cuenta del usuario";
            UserDataInf();
        }
        
        private void UserDataInf()
        {
            panel_ContainerInterface.Controls.Clear();
            udm = new UserDataMenu();
            panel_ContainerInterface.Controls.Add(this.udm);
            udm.ReLoad();
            //this.udm.Show();
            this.label_title.Text = "Datos de cuenta del usuario";
        }
        private void ActivitiesDataInf()
        {
            panel_ContainerInterface.Controls.Clear();
            uam = new UserActivitiesMenu();
            panel_ContainerInterface.Controls.Add(this.uam);
            uam.ReLoad();
            //this.uam.Show();
            this.label_title.Text = "Actividades del usuario";
        }        
        private void SelActivitiesDataInf() 
        {
            panel_ContainerInterface.Controls.Clear();
            sa = new Select_Activities();
            panel_ContainerInterface.Controls.Add(this.sa);
            //sa.Load();
            //this.sa.Show();
            this.label_title.Text = "Seleccion de actividades";
        }
        //CLICK EVENTS
        private void pictureBox_UserData_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click userData");
            UserDataInf();
        }
        private void pictureBox_Activities_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click userActivities");
            ActivitiesDataInf();
        }
        private void pictureBox_SelectActivities_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click userActivities");
            SelActivitiesDataInf();
        }
        private void pictureBox_Transactions_Click(object sender, EventArgs e)
        {
            //ACCIONES AQUÍ
        }
        private void pictureBox_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
        
        //HIDE/REMOVE Controls
        private void hideAllUserContro()
        {
            this.udm.Hide();
            this.uam.Hide();            
        }
        private void RemoveControl()
        {
            foreach(ControlCollection c in panel_ContainerInterface.Controls)
            {
                Console.WriteLine(c);
            }
        }

        
        
    }
}

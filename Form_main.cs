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

        //UserVar (deprecated)
        private int userId;

        // INIT USER CONTROL FORMS
        private UserDataMenu udm;
        private UserActivitiesMenu uam;
        private Select_Activities sa;
        private transacciones ut;
        private appManager appM;

        //DISPOSED EVENTS
        private void appM_Disposed(object sender, EventArgs e)
        {
            if(CurrentUser.Id == 0) { pictureBox_Logout_Click(sender, e); }            
        }

        //STARTUP METHOD
        private void SetPanelUser()
        {
            UserDataInf();
        }        
        //INTERFACE UPDATE METHODS
        private void UserDataInf()
        {            
            RemoveControl();
            udm = new UserDataMenu();
            panel_ContainerInterface.Controls.Add(this.udm);
            udm.ReLoad();            
            this.label_title.Text = "Datos de cuenta del usuario";
            IconsStatusChanger(pictureBox_UserData);
        }
        private void ActivitiesDataInf()
        {            
            RemoveControl();
            uam = new UserActivitiesMenu();
            panel_ContainerInterface.Controls.Add(this.uam);
            uam.ReLoad();         
            this.label_title.Text = "Actividades del usuario";
            IconsStatusChanger(pictureBox_Activities);
        }        
        private void SelActivitiesDataInf() 
        {            
            RemoveControl();
            sa = new Select_Activities();
            panel_ContainerInterface.Controls.Add(this.sa);            
            this.label_title.Text = "Seleccion de actividades";
            IconsStatusChanger(pictureBox_SelectActivities);
        }
        private void TransactionsDataInf()
        {
            RemoveControl();
            ut = new transacciones();
            panel_ContainerInterface.Controls.Add(ut);
            this.label_title.Text = "Transacciones";
            IconsStatusChanger(pictureBox_Transactions);
        }
        private void appManagerInf()
        {
            RemoveControl();
            appM = new appManager();
            panel_ContainerInterface.Controls.Add(appM);
            this.label_title.Text = "Gestión de la aplicación";
            IconsStatusChanger(pictureBox_Logout); //Activará todos los iconos.
            appM.Disposed += new EventHandler(appM_Disposed);
        }
        //CLICK EVENTS
        private void pictureBox_UserData_Click(object sender, EventArgs e)
        {            
            UserDataInf();
        }
        private void pictureBox_Activities_Click(object sender, EventArgs e)
        {            
            ActivitiesDataInf();
        }
        private void pictureBox_SelectActivities_Click(object sender, EventArgs e)
        {
            SelActivitiesDataInf();
        }
        private void pictureBox_Transactions_Click(object sender, EventArgs e)
        {
            TransactionsDataInf();
        }
        private void pictureBox_XML_Click(object sender, EventArgs e)
        {
            appManagerInf();
        }
        private void pictureBox_Logout_Click(object sender, EventArgs e)
        {                        
            this.Dispose();
        }       
        private void RemoveControl()
        {
            foreach(Control c in panel_ContainerInterface.Controls)
            {                
                c.Dispose();
            }
        }

        //XML LINK VISBLE & ENABLED TIMEOUT        
        private void label2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Desactivar label2 y Avtivar vinculo XML; Iniciar timer.
            ShowXMLIcon();            
        }
        private void ShowXMLIcon()
        {
            ChangeIconStatus(this.pictureBox_XML);
            ChangeIconStatus(this.label2, 2);
            this.timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Desactivar vinculo XML; Avtivar label2; Parar el timer.
            ChangeIconStatus(this.pictureBox_XML);
            ChangeIconStatus(label2, 2);
            this.timer1.Stop();
        }

        //ICON STATUS CTRL
        private void ChangeIconStatus(Label item)
        {
            item.Enabled = !item.Enabled;
            item.Visible = !item.Visible;
        }
        private void ChangeIconStatus(Label item, int mode)
        {
            if (mode == 0) { ChangeIconStatus(item); }

            if (mode == 1) { item.Visible = !item.Visible; }

            if (mode == 2) { item.Enabled = !item.Enabled; }
        }
        private void ChangeIconStatus(PictureBox item)
        {
            item.Enabled = !item.Enabled;
            item.Visible = !item.Visible;
        }
        private void ChangeIconStatus(PictureBox item, int mode)
        {
            if (mode == 0) { ChangeIconStatus(item); }

            if (mode == 1) { item.Visible = !item.Visible; }

            if (mode == 2) { item.Enabled = !item.Enabled; }
        }
        private void IconsStatusChanger(PictureBox item)
        {
            var ctrls = this.panel_MainMenuItems.Controls.GetEnumerator();
            while (ctrls.MoveNext())
            {                
                if ((ctrls.Current as PictureBox).Name.Equals(item.Name))
                {                    
                    ChangeIconStatus(item, 2);
                    item.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    (ctrls.Current as PictureBox).Enabled = true;
                    (ctrls.Current as PictureBox).BorderStyle = BorderStyle.None;
                }
            }                
        }
    }
}

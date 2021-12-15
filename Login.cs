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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Obtenemos el byte[] del password y el salt[] antes de almacenarlo en el DB.
            PasswordHash passGen = new PasswordHash(txtPass.Text);
          
            using (netimeContainer db = new netimeContainer())
            {
                var lst = from d in db.userSet
                          where d.email == txtUser.Text
                          && d.password == passGen.GenerateSaltedHash()
                          select d;

                if (lst.Count() > 0)
                {
                    MessageBox.Show("Usuario Correcto.");

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                    form1.FormClosed += (s, args) => this.Close();


                }
                else
                {
                    MessageBox.Show("Usuario Incorrecto. Revise datos o registrese");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Pendiente desarrollo de Form CrearUsuarios.
        }
    }
}

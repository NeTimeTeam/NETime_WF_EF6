using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETime_WF_EF6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var context = new netimeContainer();
            var ususario = new user()
            {
                email = "email@dominiio.com",
                name = "nombre",
                surname = "apellidos",
                address = "dirección",
                phone = "tel",
                password = "contraseña"
            };
            context.userSet.Add(ususario);
            context.SaveChanges();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
            
    }
}

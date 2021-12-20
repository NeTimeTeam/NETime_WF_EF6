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
            label_response.Text = string.Empty;
            setLogInFormParams();

            //¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!

            deleteMe(); // ESTA FUNCiÖN ES SOLO PARA PROBAR EL LOGIN. CREA UN USUARIO PARA INICIAR SESIÓN, SI ESTE NO EXISTE. COMENTAR LA LÍNEA SI NO SE VA A USAR.

            //¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!//¡¡¡¡ATENCIóN!!!!
        }
        private user user;
        private void deleteMe()
        {
            using (netimeContainer context = new netimeContainer())
            {                
                if (!context.userSet.Any<user>(us => us.email.Equals("nrovira@uoc.com")))
                {
                    PasswordHash pg = new PasswordHash("a1234567890");
                    user u = new user()
                    {
                        name = "Isaac",
                        surname = "Rovira",
                        address = "Mi dirección.",
                        phone = "+34686970016",
                        email = "nrovira@uoc.com",
                        salt = pg.Salt(),
                        password = pg.GenerateSaltedHash()
                    };
                    context.userSet.Add(u);
                    context.SaveChanges();
                    Console.WriteLine("Usuario {0} creado", u.email);                    
                }
                else
                {
                    Console.WriteLine("Existe un usuario nrovira@uoc.com");
                    context.userSet.Remove(context.userSet.Where(u => u.email.Equals("nrovira@uoc.com")).First<user>());
                    context.SaveChanges();
                    deleteMe();
                }
                //USUARIO PREDETERMINADO PARA EL LOGIN (TESTING)
                txtUser.Text = "nrovira@uoc.com";
                txtPass.Text = "a1234567890";                
            }
        }

        //SET TEXTBOX PARAMS
        private void setLogInFormParams()
        {
            //CONFIGURACIÓN RECOMENDADA PARA LOS TEXTBOX.
            txtUser.Multiline = txtPass.Multiline = false;
            txtPass.AcceptsReturn = false;
            txtPass.UseSystemPasswordChar = true;
            //ESTABLCE COMO PREDETERMINADO EL button1 (al apreter el enter se activa el botón).
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (notEmptyStrings())
            {
                if (emailExist(passMatch))//Si el email existe y la password coincide.
                {
                    userLogged(this.user);
                }
            }
            else
            {
                errMsg();
            }            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AltaUsuario regiserForm = new AltaUsuario();
            regiserForm.Show();
        }

        //LOGIN: funciones
        private bool notEmptyStrings()
        {            
            if(txtUser.Text.Equals(string.Empty) || txtPass.Text.Equals(string.Empty))
            {
                return false;
            }
            return true;
        }
        private bool emailExist(callback callback)
        {
            user user = new user() { };
            using (netimeContainer db = new netimeContainer())
            {
                try
                {
                    List<user> lst = (from d in db.userSet where d.email == txtUser.Text select d).ToList<user>();
                    if(lst.Count > 0)
                    {
                        response("Verificando...", Color.Black);
                        return callback(lst.First<user>());                        
                    }
                    else
                    {
                        errMsg();
                        return false;
                    }
                }
                catch(Exception e)
                {
                    response(e.Message, Color.Red);
                    return false;
                }                
            }
        }
        private bool passMatch(user user)
        {
            PasswordHash ph = new PasswordHash(txtPass.Text, user.salt);
            if (ph.PasswordMatch(user.password))
            {
                this.user = user;
                return true;
            }
            else
            {
                errMsg();
                return false;
            }
        }        
        private void userLogged(user user)
        {            
            Form_main form_main = new Form_main(user.Id);            
            this.Hide();
            form_main.ShowDialog();
            this.Close();
        }
        private void response(string res, Color color)
        {
            label_response.ForeColor = color;
            label_response.Text = res;
            label_response.Visible = true;
        }
        private void errMsg()
        {
            linkLabel1.Visible = true;
            response("El usuario y la contraseña no coinciden.", Color.Red);
        }

        //DELEGATES
        public delegate bool callback(user user);        
        

        //ASYNCCALLBACK EXPLORATION
        public bool passMatchAsync(user user, IAsyncResult result)
        {
            bool valid = (bool)result.AsyncState;
            PasswordHash ph = new PasswordHash(txtPass.Text, user.salt);
            if (ph.PasswordMatch(user.password))
            {
                this.user = user;
                valid = true;                
            }
            else
            {
                linkLabel1.Visible = true;
                response("El usuario y la contraseña no coinciden.", Color.Red);
                valid = false;
            }
            return valid;
        }

        //DEPRECATED
        private void deprecated_login()
        {
            using (netimeContainer db = new netimeContainer())
            {

                var lst = from d in db.userSet
                          where d.email == txtUser.Text
                          select d;
                if (lst.Count() > 0)    //Vrificar si el email existe en la base de datos.
                {
                    // 1- Obtenemos el primer usuario de la lista (solo deberia haber uno).
                    user currentUser = lst.First();

                    Console.WriteLine("Usario {0} encontrado", currentUser.email);

                    // 2- Generamos el objeto passGen con la contraseña que nos ha pasado el login y el salt del usario que hemos recuperado.
                    // El objeto passgen genera un hash de una cadena basado en un salt. Es por eso que le pasamos el texto del formulario y el SALT del usario con el que lo vamos a comparar.
                    PasswordHash passGen = new PasswordHash(txtPass.Text, currentUser.salt);

                    // 3 -Utilizando la función PasswordMatch, le pasamos el password del usuario que hemos recuperado de la db y esta nos devolvera TRUE si coincide con la que se le paso para crear el objeto.
                    //passGen tiene el HASH generado con el salt del usuario y el texto del formulario. Y dispone de un método para comparar dos hases, a saber, el almacenado para este usuario.
                    if (passGen.PasswordMatch(currentUser.password))
                    {
                        Console.WriteLine("Usuario {0} y password {1} coinciden", currentUser.email, currentUser.password);
                        //MessageBox.Show("Usuario y password correcto.");
                        //4 -He implementado un nuevo consructor en FORM1 que permite pasar como parámetro el objeto usuario q ha iniciado sesión y de esta forma lo tenemos disponible para las funciones de Form1.
                        //Form_main form_main = new Form_main(currentUser);                        
                        Form_main form_main = new Form_main(currentUser.Id);
                        Console.WriteLine("Lanzar form_main");
                        //5 -Escondemos el Form del login
                        this.Hide();
                        //6 -Mostramos el FORM1. La ejecución del código entra en el bucle del FORM1 y no seguira ejecutando el resto del código del form Login hasta que se cierre el FORM1.
                        form_main.ShowDialog();
                        //7 -Cerramos el este form, el Login si se ha cerrado el Form1.
                        this.Show();                        

                        //form1.Show();
                        //this.Hide();
                        //form1.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El usuario y la contraseña no coinciden. Revise datos o registrese");

                    }
                }
                else
                {
                    MessageBox.Show("El usuario y la contraseña no coinciden. Revise datos o registrese");
                }
            }
        }
        
        //TODO: Eliminar el texto del formulario si falla el login.
    }
}
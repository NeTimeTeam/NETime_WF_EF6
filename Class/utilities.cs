using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data;

namespace NETime_WF_EF6
{
    static class CurrentUser
    {
        public static void SetUser(user user)
        {
            Id = user.Id;
            name = user.name;
            surname = user.surname;
            address = user.address;
            phone = user.phone;
            email = user.email;
            password = user.password;
            salt = user.salt;
        }
        public static user GetUser()
        {
            user user = new user()
            {
                Id = Id,
                name = name,
                surname = surname,
                address = address,
                phone = phone,
                email = email,
                salt = salt,
                password = password
            };
            return user;
        }
        public static int Id { get; set; }
        public static string name { get; set; }
        public static string surname { get; set; }
        public static string address { get; set; }
        public static string phone { get; set; }
        public static string email { get; set; }
        public static byte[] salt { get; set; }
        public static byte[] password { get; set; }
    }
    static class Utilities
    {
        /*
            (?i) sets case-insensitive mode
            The ^ anchor asserts that we are at the beginning of the string
            (?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ]) matches one character...
            The lookahead (?![×Þß÷þø]) asserts that the char is not one of those in the brackets
            [-'0-9a-zÀ-ÿ] allows dash, apostrophe, digits, letters, and chars in a wide accented range, from which we need to subtract
            The + matches that one or more times
            The $ anchor asserts that we are at the end of the string
         */

        //Verifica el email
        static public bool emailValidation(string email)
        {
            /*
             * https://code.4noobz.net/c-email-validation              
             */
            Regex rx = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            return rx.IsMatch(email.Length >0 ? email : "null");
        }
        static public bool phoneValidation(string phone)
        {
            Regex rx = new Regex(@"^\+[1-9]{1}[0-9]{9,14}");
            return rx.IsMatch(phone.Length > 0 ? phone : "null");
        }
        static public bool nameValidation(string name)
        {
            Regex rx = new Regex(@"[A-Z][A-Za-zÀ-ÿ\s]{3,26}$"); //Solo letras y mín 3 - máx 26.
            return rx.IsMatch(name.Length > 0 ? name : "n");
        }
        static public bool descriptionValidation(string name)
        {
            Regex rx = new Regex(@"[A-Z][A-Za-zÀ-ÿ.,\-/\\0-9\s]{3,500}$"); //Solo letras y mín 10 - máx 500.
            return rx.IsMatch(name.Length > 0 ? name : "n");
        }
        static public bool passwordValidation(string pass, int lvl=0) //validación de password según nivel definido. Predeterminado 0, nvl más bajo.
        {
            string rgx;
            switch (lvl)
            {
                case 1:                    
                    rgx = "^(?=.*[A-Za-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,}$"; //Al menos una letra, un número, uno de estos símbolos [@$!%*#?&] y 8 carteres de longitud.
                    break;
                case 2:
                    rgx = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]{8,}$"; //Al menos una letra minúscula, una mayúscula, un número y 8 carcateres de longitud.
                    break;
                case 3:
                    rgx = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,}$"; //Al menos una letra minúscula, una mayúscula, un número, uno de estos símbolos [@$!%*#?&] y 8 carteres de longitud.
                    break;
                case 0:
                default:
                    rgx = "^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$"; //Al menos una letra, un número y 8 caracteres de longitud.
                    break;             
            }
            Regex rx = new Regex(rgx);
            return rx.IsMatch(pass.Length > 0 ? pass : "n");
        }
        static public void setTextBoxStatus(bool valid, TextBox textbox)
        {
            Color color = valid ? Color.Black : Color.Red;
            textbox.ForeColor = color;
            textbox.CausesValidation = valid;
        }
        static public void setTextBoxStatus(bool valid, TextBox[] textBoxes)
        {
            foreach (TextBox tb in textBoxes)
            {
                setTextBoxStatus(valid, tb);
            }
        }
        static public void checkTextboxStatus(TextBox[] textBoxes, Button btn)
        {
            btn.Enabled = true;
            foreach(TextBox tb in textBoxes)
            {                
                if (!tb.CausesValidation) { btn.Enabled = false; break; }
            }
        }
        static public bool checkTextboxStatus(TextBox[] textBoxes)
        {            
            foreach (TextBox tb in textBoxes)
            {
                if (!tb.CausesValidation) { return false; }
            }
            return true;
        }
    }
    public class Context
    {
        //DELEGATES
        public delegate void callback();        
        public delegate void res(string msg, Color color);
        public delegate bool response(bool valid);
        public delegate Task<bool> asyncCallback();
        public delegate Task asyncVoidCallback();

        public static async Task<bool> saveChanges(netimeContainer context, Label label, string fnDesc, asyncVoidCallback callback)
        {
            Messages.Message(label, "En proceso... espere.", Color.Black);
            int task = await Context.saveChanges(context, fnDesc);
            if (task > 0)
            {
                Messages.Message(label, "Finalizado.", Color.Black);
                await callback();
                return true;
            }
            else
            {
                Messages.ErrorMessage(label, "Error de acceso a la base de datos.");
                return false;
            }
        }
        public static async Task<bool> saveChanges(netimeContainer context, Label label, string fnDesc, asyncCallback callback)
        {
            Messages.Message(label, "En proceso... espere.", Color.Black);
            int task = await Context.saveChanges(context, fnDesc);
            if (task > 0)
            {
                Messages.Message(label, "Finalizado.", Color.Black);
                return await callback();                
            }
            else
            {
                Messages.ErrorMessage(label, "Error de acceso a la base de datos.");
                return false;
            }
        }
        public static async Task<bool> saveChanges(netimeContainer context, Label label, string fnDesc, callback callback)
        {            
            Messages.Message(label, "En proceso... espere.", Color.Black);
            int task = await Context.saveChanges(context, fnDesc);
            if (task > 0)
            {
                Messages.Message(label, "Finalizado.", Color.Black);
                callback();
                return true;
            }
            else
            {
                Messages.ErrorMessage(label, "Error de acceso a la base de datos.");
                return false;
            }
        }
        public static async Task<bool> saveChanges(netimeContainer context, Label label, string fnDesc)
        {            
            Messages.Message(label, "En proceso...espere.", Color.Black);
            int task = await Context.saveChanges(context, fnDesc);  
            if (task > 0)
            {
                Messages.Message(label, "Datos guardados.", Color.Black);
                return true;
            }
            else
            {
                Messages.ErrorMessage(label, "Error de acceso a la base de datos.");
                Console.WriteLine(task);
                return false;
            }
        }        
        public static async Task<int> saveChanges(netimeContainer context, string fnDesc)
        {            
            try
            {
                int task = await context.SaveChangesAsync();
                return task;
            }
            catch (DbUpdateException err)
            {
                MessageBox.Show(err.InnerException.ToString(), fnDesc);
            }
            catch (DBConcurrencyException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (DbEntityValidationException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (NotSupportedException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (ObjectDisposedException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }                        
            return 0;
        }
        public static async Task<int> saveChanges(netimeContainer context, string fnDesc, response callback)
        {
            try
            {
                int task = await context.SaveChangesAsync();
                callback(true);
                return task;
            }
            catch (DbUpdateException err)
            {
                MessageBox.Show(err.InnerException.ToString(), fnDesc);
            }
            catch (DBConcurrencyException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (DbEntityValidationException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (NotSupportedException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (ObjectDisposedException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, fnDesc);
            }            
            callback(false);
            return 0;
        }
    }
    class ErrorObject
    {
        public ErrorObject(bool status, string message, string code = "")
        {
            this.status = status;
            this.message = message;
            this.code = code;
        }
        public string message { get; set; }
        public bool status { get; set; }
        public string code { get; set; }
    }
    class Messages
    {
        public static void ErrorMessage(Label label, string msg)
        {
            Message(label, msg, Color.Red);
        }
        public static void Message(Label label, string msg, Color color)
        {            
            label.Text = msg;
            label.ForeColor = color;
            label.Visible = true;
        }
    }
    class PasswordHash
    {
        /*
         * https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
         */
        public PasswordHash(byte[] pass, int saltLengthLimit = 32)
        {
            this.pass = pass;
            this.saltLengthLimit = saltLengthLimit;
            this.salt = GenerateSalt(saltLengthLimit);
        }
        public PasswordHash(string pass, int saltLengthLimit = 32)
        {
            this.pass = Encoding.UTF8.GetBytes(pass);
            this.saltLengthLimit = saltLengthLimit;
            this.salt = GenerateSalt(saltLengthLimit);
        }
        public PasswordHash(string pass, string salt, int saltLengthLimit = 32)
        {
            this.pass = Encoding.UTF8.GetBytes(pass);
            this.salt = Encoding.UTF8.GetBytes(salt);
            this.saltLengthLimit = saltLengthLimit;
        }
        public PasswordHash(byte[] pass, byte[] salt, int saltLengthLimit = 32)
        {
            this.pass = pass;
            this.salt = salt;
            this.saltLengthLimit = saltLengthLimit;
        }
        public PasswordHash(string pass, byte[] salt, int saltLengthLimit = 32)
        {
            this.pass = Encoding.UTF8.GetBytes(pass);
            this.salt = salt;
            this.saltLengthLimit = saltLengthLimit;
        }
        
        

        private byte[] pass;
        private byte[] salt;
        public int saltLengthLimit { get; set; }

        public byte[] Salt() { return this.salt; }
        
        /*
         * You can convert text to byte arrays using Encoding.UTF8.GetBytes(string).
         * If you must convert a hash to its string representation you can use Convert.ToBase64String and Convert.FromBase64String to convert it back.
         */

        public byte[] GenerateSaltedHash(byte[] pass, byte[] salt)
        {            
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[pass.Length + salt.Length];

            for (int i = 0; i < pass.Length; i++)
            {
                plainTextWithSaltBytes[i] = pass[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[pass.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        public byte[] GenerateSaltedHash()
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[this.pass.Length + this.salt.Length];

            for (int i = 0; i < this.pass.Length; i++)
            {
                plainTextWithSaltBytes[i] = this.pass[i];
            }
            for (int i = 0; i < this.salt.Length; i++)
            {
                plainTextWithSaltBytes[this.pass.Length + i] = this.salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public byte[] GenerateSalt()
        {
            return GenerateSalt(this.saltLengthLimit);
        }
        private byte[] GenerateSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        private bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
        public bool PasswordMatch(byte[] storedPass)
        {            
            return CompareByteArrays(GenerateSaltedHash(), storedPass);
        }
    }
    class Usuario
    {
        public Usuario(user user) {
            this.Id = user.Id.ToString();
            this.email = user.email;
            this.name = user.name;
            this.surname = user.surname;
            this.phone = user.phone;
            this.address = user.address;
            this.password = Convert.ToBase64String(user.password);
            this.salt = Convert.ToBase64String(user.salt);
        }
        public Usuario(string Id, string email, string name, string surname, string phone, string address, string password, string salt)
        {
            this.Id = Id;
            this.email = email;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.address = address;
            this.password = password;
            this.salt = salt;
        }

        public string Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string salt { get; set; }

    }
    public class Actividades
    {
        public bool selector { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }        
        public string category { get; set; }
        public int userId { get; set; }
        public string email { get; set; }
        public int activityId { get; set; }
}    
    public class Balance
    {        
        public DateTime datetime { get; set; }
        public string activity { get; set; }
        public int qtty { get; set; }
    }
}

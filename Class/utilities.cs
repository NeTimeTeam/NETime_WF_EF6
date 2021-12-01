using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace NETime_WF_EF6
{
    class utilites
    {
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
            Regex rx = new Regex(@"^\+[1-9]{1}[0-9]{3,14}");
            return rx.IsMatch(phone.Length > 0 ? phone : "null");
        }

        static public bool nameValidation(string name)
        {
            Regex rx = new Regex(@"[A-Z][A-Za-z\s]{3,16}$"); //Solo letras y mín 3 - máx 16.
            return rx.IsMatch(name.Length > 0 ? name : "n");
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
        private int saltLengthLimit;

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

        private byte[] GenerateSalt()
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
}

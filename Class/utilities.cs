using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
}

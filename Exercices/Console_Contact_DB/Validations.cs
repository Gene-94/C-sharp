using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_Contact_DB
{
    internal class Validations
    {


        public static bool NameValidation(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                StdMsg.AskForValid("name");
                return false;
            }
            return true;
        }

        public static bool AddressValidation(string? address)
        {
            if (string.IsNullOrEmpty(address))
            {
                StdMsg.AskForValid("address");
                return false;
            }
            return true;
        }

        public static bool PhoneValidation(string? phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                StdMsg.AskForValid("phone number");
                return false;
            }
            return true;
        }

        public static bool AgeValidation(string? ageString)
        {
            bool isInt = int.TryParse(ageString, out int age);
            if(!isInt)
                return false;
            else if (age <= 0)
            {
                StdMsg.AskForValid("age");
            }
            else
            {
                return true;
            }
            return false;
        }


    }
}

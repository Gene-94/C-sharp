using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_Contact_DB
{
    internal class Contact_Model
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        public Contact_Model()
        {
            AskInfo();
        }
        public Contact_Model(int id, string name, string address, string phone, int age)
        {
            ID = id;
            Name = name;
            Address = address;
            Phone = phone;
            Age = age;
        }

        private void AskInfo()
        {
            string? name;
            string? address;
            string? phone;
            string? age;
            do
            {
                Console.Write("Insert contact name: ");
                name = Console.ReadLine();
            } while (!Validations.NameValidation(name));
            Name = name;

            do
            {
                Console.Write("Insert contact age: ");
                age = Console.ReadLine();
            } while (!Validations.AgeValidation(age));
            Age = int.Parse(age);

            do
            {
                Console.Write("Insert contacts address: ");
                address = Console.ReadLine();
            } while (!Validations.AddressValidation(address));
            Address = address;

            do
            {
                Console.Write("Insert contact phone number: ");
                phone = Console.ReadLine();
            } while (!Validations.PhoneValidation(phone));
            Phone = phone;

            Console.WriteLine();
        }

        
    }

}

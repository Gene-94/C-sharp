using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagmentSystem
{
    public class Client
    {
        //Client ID -> array index +1
        private int clientID;
        //Name
        private string name;
        //Address
        private string address;
        //Postal code
        private string postal;
        //City
        private string locale;
        //Phone number
        private string phone;
        //Email
        private string email;
        //VAT number
        private string vat;
        // Active bool field
        private bool active;

        //Current credit
        private float credit;
        //Credit validity
        private DateTime creditExpiry;

        public Client(int clientID, bool active, string name, string address, string postal, string locale, string phone, string email, string vat, float credit, DateTime creditExpiry){
            this.clientID = clientID;
            this.active = active;
            this.name = name;
            this.address = address;
            this.postal = postal;
            this.locale = locale;
            this.phone = phone;
            this.email = email;
            this.vat = vat;
            this.credit = credit;
            this.creditExpiry = creditExpiry;
        }

        public void PrintInfo(){
            Console.WriteLine(@$"
                Número Cliente ......{clientID}
                Ativo ...............{(active?"sim":"não")}
                Nome ................{name}
                Morada ..............{address}
                Código Postal .......{postal}
                Localidade ..........{locale}
                Telefone ............{phone}
                Email ...............{email}
                No Contribuinte .....{vat}
                Saldo Disponível ....{credit}
                Data de Validade ....{creditExpiry}
            ");
        }




        // All operations are stored in a adicional file called balance.csv
            // A client can charge his trip pass with payments, the minimum amount is 5€
            // the credit on the pass is never lost, but can only be used if a payment has been made within 30 days of last one

    }
}
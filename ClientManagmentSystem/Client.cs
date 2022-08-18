using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ClientManagmentSystem
{
    public class Client
    {


        //Client ID -> array index +1
        public int ClientID{get; private set;}
        // Active client bool field
        public bool Active{get; set;}
        //Name
        public string Name{get; set;}
        //Address
        public string Address{get;  set;}
        //Postal code
        public string Postal{get;  set;}
        //City
        public string Locale{get;  set;}
        //Phone number
        public string Phone{get;  set;}
        //Email
        public string Email{get;  set;}
        //VAT number
        public string Vat{get;  set;}

        //Current credit
        public float Credit{get; set;}
        //Credit validity
        public DateTime CreditExpiry{get; set;}
        

        public Client(int clientID, bool active, string name, string address, string postal, string locale, string phone, string email, string vat, float credit, DateTime creditExpiry){
            this.ClientID = clientID;
            this.Active = active;
            this.Name = name;
            this.Address = address;
            this.Postal = postal;
            this.Locale = locale;
            this.Phone = phone;
            this.Email = email;
            this.Vat = vat;
            this.Credit = credit;
            this.CreditExpiry = creditExpiry;
        }

        public string FullInfo(){
            string clientInfo = (@$"
                Número Cliente ......{ClientID}
                Ativo ...............{(Active?"sim":"não")}
                Nome ................{Name}
                Morada ..............{Address}
                Código Postal .......{Postal}
                Localidade ..........{Locale}
                Telefone ............{Phone}
                Email ...............{Email}
                No Contribuinte .....{Vat}
                Saldo Disponível ....{(Credit!=-999?Credit:"Erro na leitura de credito"):C}
                Data de Validade ....{(CreditExpiry==DateTime.MinValue?"Erro na leitura de validade":CreditExpiry)}{'\n'}");

            return clientInfo;
        }

        public string[] SplittedInfo(){
            string[] info = FullInfo().Split('\n');
            //info = new string[] {info[1],info[2],info[3],info[4],info[5],info[6],info[7],info[8],info[9],info[10]}; --> this removes tabulation from "Name.." line for some reason.
            return info; 
        }




        // All operations are stored in a adicional file called balance.csv
            // A client can charge his trip pass with payments, the minimum amount is 5€
            // the credit on the pass is never lost, but can only be used if a payment has been made within 30 days of last one

    }
}
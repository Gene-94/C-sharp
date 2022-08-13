using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagmentSystem
{
    public class Adapter
    {
        //read file with all client info for import




        //write to file with client info for update
        //probably best to simply rewrite the whole file based on object list
        //commit changes to file after each change
        

        
        // All client info is stored in a clients.csv file
            //one line per client
            // ';' separator for fields
            // ClientID;Active;Name;Address;PostalCode;City;Phone;Email;VAT;Credit;LastPayment



        // All operations are stored in a adicional file called balance.csv
            // A client can charge his trip pass with payments, the minimum amount is 5€
            // the credit on the pass is never lost, but can only be used if a payment has been made within 30 days of last one

            //Ex:
            //ClientID;operation DateTime;Amount
            //1;10/08/2022 22:33:55;-1.10
            //2;20/08/2022 15:14:13;10.00
            //2;21/08/2022 10:44:31;-1.50
            //2;22/08/2022 10:44:31;-2.50

        // include option to filter operations bu DateTime (options 8 & 9 on the Menu)

    }
}
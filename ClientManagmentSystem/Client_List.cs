using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagmentSystem
{
    public class Client_List
    {
        //Client list (include inactive clients)
        private List<Client>? clients = new List<Client>();

        Adapter file = new();

        public Client_List(){
            Import();
        }

        // Import all clients from csv to list
        public void Import(){
            // Use adapter to open file and create a initial list with data from csv
            clients = file.LoadList();
        }

        private void FilterActiveData(int[] lines, Client client){
            // lines index reference:
            // ID = 1, active = 2, name = 3, address = 4, postal = 5, city = 6, phone = 7, email = 8, vat = 9, credit = 10, validity = 11
            string[] info = client.SplittedInfo();
            if(client.Active){
                foreach(int i in lines){
                    Console.WriteLine(info[i]);
                }
            }
        }
        // All functionalities presented in the menu go here


            // List all active clients
        public void ListAllActive(){
            foreach(Client client in clients){
                FilterActiveData(new int[] {1,3,9,10}, client);
            }
        }
    

            // List all active client, with positive availble credit
        public void ListPositiveCredit(){
            foreach(Client client in clients){
                if(client.Credit>0)
                    FilterActiveData(new int[] {1,3,10,11}, client);
            }
        }

            // List all active clients with expired credit validity 


            // List a single client


            // Add a new client


            // Remove a client (make inactive)


            // Edit a client


            // List a clients balance sheet


            // Add a trip to a client


            // Add credit to trip pass




        // # Extra #   (nice to have)

        // print all operations pertinent to one client into a separate balance sheet

        // search option, allow to search client database by field

        // list all clients
        public void ListAll(){
            foreach(Client client in clients){
                Console.Write(client.FullInfo());
            }
        }


        public void Save(){
            file.Save(clients);
        }






    }
}
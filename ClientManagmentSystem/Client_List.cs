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

        // All functionalities presented in the menu go here


            // List all active clients
    

            // List all active client, with positive availble credit


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
        public void listAll(){
            foreach(Client client in clients){
                client.PrintInfo();
            }
        }






    }
}
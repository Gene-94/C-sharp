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


        public void ListAllActive(){
            if(clients is null){
                Console.WriteLine("* Ainda não existem clientes *");
                return;
            }
            // List all active clients
            foreach(Client client in clients){
                FilterActiveData(new int[] {1,3,9,10}, client);
            }
        }
    

        public void ListPositiveCredit(){
            if(clients is null){
                Console.WriteLine("* Ainda não existem clientes *");
                return;
            }
            // List all active client, with positive availble credit
            foreach(Client client in clients){
                if(client.Credit>0)
                    FilterActiveData(new int[] {1,3,10,11}, client);
            }
        }

        public void ListExpired(){
            if(clients is null){
                Console.WriteLine("* Ainda não existem clientes *");
                return;
            }
            // List all active clients with expired credit validity 
            foreach(Client client in clients){
                if(client.CreditExpiry < DateTime.Now)
                    FilterActiveData(new int[] {1,3,10,11}, client);
            }
        }

            // List a single client
        public void IdInfo(){
            if(clients is null){
                Console.WriteLine("* Ainda não existem clientes *");
                return;
            }
            //after 5 tries it just list all info on all clients to help the user search for the information
            for(int i=0; i<5; i++){
                Console.Write("\n\nInsira o id de cliente: ");
                if(int.TryParse(Console.ReadLine(), out int _id))
                    if(_id <=0 || _id > clients.Count)
                        Console.WriteLine("Não existe um cliente com esse número!");
                    else{
                        foreach(Client client in clients){
                            if(client.ClientID==_id){
                                Console.Write(client.FullInfo());
                                return;
                            }
                        }
                    }
                else
                    Console.WriteLine("Insira um número de cliente valido!\n");
            }
            Console.WriteLine("Talvez o que procura esteja aqui...\n");
            ListAll();

        }

            // Add a new client
        public bool AddClient(){
            return true;
        }

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
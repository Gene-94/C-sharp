using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


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

        private void FilterActiveData(int[] lines, Client client, bool append=false){
            // lines index reference:
            // ID = 1, active = 2, name = 3, address = 4, postal = 5, city = 6, phone = 7, email = 8, vat = 9, credit = 10, validity = 11
            string[] info = client.SplittedInfo();
            if(client.Active){
                int a = 1;
                foreach(int i in lines){
                    Console.WriteLine(append?a+" - "+(info[i].Trim()):info[i]);
                    a++;
                }
            }
        }

        private bool ListIsEmpty(){
            if(clients is null){
                Console.WriteLine("* Ainda não existem clientes *");
                return true;
            }
            return false;
        }

        private Client? validateID(){
            if(ListIsEmpty())
                return null;
            //after 5 tries it just list all info on all clients to help the user search for the information
            for(int i=0; i<5; i++){
                Console.Write("\n\nInsira o id de cliente: ");
                if(int.TryParse(Console.ReadLine(), out int _id))
                    if(_id <=0 || _id > clients.Count)
                        Console.WriteLine("Não existe um cliente com esse número!");
                    else{
                        foreach(Client client in clients){
                            if(client.ClientID==_id){
                                if(!client.Active){
                                    Console.WriteLine("O cliente com esse id já foi eliminado.");
                                    return null;
                                }
                                else
                                    return client;
                            }
                        }
                    }
                else
                    Console.WriteLine("Insira um número de cliente valido!\n");
            }
            Console.WriteLine("Talvez o que procura esteja aqui...\n");
            ListAllActive();
            return null;
        }

        // All functionalities presented in the menu go here


        public void ListAllActive(){
            if(!ListIsEmpty()){
                // List all active clients
                bool any = false;
                foreach(Client client in clients){
                    FilterActiveData(new int[] {1,3,9,10}, client);
                    any = true;
                }
                if(!any)
                    Console.WriteLine("* De momento não existem nenhuns *");
            }
        }
    

        public void ListPositiveCredit(){
            if(ListIsEmpty())
                return;
            // List all active client, with positive availble credit
            bool any = false;
            foreach(Client client in clients){
                if(client.Credit>0){
                    FilterActiveData(new int[] {1,3,10,11}, client);
                    any = true;
                }
            }
            if(!any)
                Console.WriteLine("* De momento não existem nenhuns *");
        }

        public void ListExpired(){
            if(!ListIsEmpty()){
                // List all active clients with expired credit validity 
                bool any = false;
                foreach(Client client in clients){
                    if(client.CreditExpiry < DateTime.Now){
                        FilterActiveData(new int[] {1,3,10,11}, client);
                        any = true;
                    }
                }
                if(!any)
                    Console.WriteLine("* De momento não existem nenhuns *");
            }
        }

            // List a single client
        public void IdInfo(){
            if(ListIsEmpty())
                return;
            Client? client = validateID();
            if(client!=null)
                Console.Write(client.FullInfo());

        }

        public void AddClient(){
            // Add a new client
            // validate input field with regex
            string? name, addr, postal, city, phone, email, vat;
            while(true){
                Console.Write("Insira o nome do cliente: ");
                name = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(name))
                    break;
            }

            while(true){
                Console.Write("Insira a morada do cliente: ");
                addr = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(addr))
                    break;
            }

            while(true){
                Console.Write("Insira o código postal: ");
                postal = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(postal))
                    break;
            }

            while(true){
                Console.Write("Insira a localidade: ");
                city = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(city))
                    break;
            }

            while(true){
                Console.Write("Insira o número de telefone: ");
                phone = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(phone))
                    break;
            }

            while(true){
                Console.Write("Insira o email: ");
                email = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(email))
                    break;
            }

            while(true){
                Console.Write("Insira o número de contribuinte: ");
                if(int.TryParse(vat=Console.ReadLine(), out int tmp))
                    break;
                Console.WriteLine("Insira um número de contribuinte valido.\n");   
            }

            int ID = clients.Count+1;

            float credit = 0;

            DateTime expiry = DateTime.Now;

            clients.Add(new Client(
                        ID,
                        true,
                        name,
                        addr,
                        postal,
                        city,
                        phone,
                        email,
                        vat,
                        credit,
                        expiry
                    ));


            Console.WriteLine("Foi adicionado o seguinte cliente: \n\n"+clients[clients.Count -1].FullInfo());

            Save();
        }

        public void DeactivateClient(){
            // Remove a client (make inactive)
            Client? client = validateID();
            if(client!=null){
                client.Active=false;
                Console.WriteLine("Cliente eliminado!");
            }

            Save();

        }


            // Edit a client

        private string EditFieldTemplate(string prep, string field){
            while(true){
                Console.Write($"Nov{prep} {field}: ");
                string? input = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(input)){
                    Console.WriteLine($"{prep.ToUpper()} {field} foi alterad{prep} com sucesso.");
                    return input;  
                }
                Console.WriteLine($"{field} {field} não pode ficar em branco.");
            }

            Save();
        }
        public void EditClient(){

            Client? client = validateID(); 
            if(client!=null){
                Console.WriteLine("\n\t\t# menu de edição #\n\t(escolha o campo que pretende editar)\n");
                FilterActiveData(new int[] {3,4,5,6,7,8,9}, client, true);
                Console.WriteLine("0 - Sair de submenu");
                while(true){
                    Console.Write(">> ");
                    string option = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if(option.IndexOf("contribuinte")!=-1)
                        option="nif";
                    switch(option){
                        case "0":
                            return;
                        case "1":
                        case "name":
                        case "nome":
                            client.Name = EditFieldTemplate("o", "nome");
                            break;
                        case "2":
                        case "address":
                        case "morada":
                            client.Address = EditFieldTemplate("a", "morada");
                            break;
                        case "3":
                        case "postal":
                        case "codigo postal":
                        case "postal code":
                            client.Postal = EditFieldTemplate("o", "código postal");
                            break;
                        case "4":
                        case "localidade":
                        case "city":
                            client.Locale = EditFieldTemplate("a", "localidade");
                            break;
                        case "5":
                        case "phone":
                        case "telefone":
                            client.Phone = EditFieldTemplate("o", "número de telefone");
                            break;
                        case "6":
                        case "email":
                            client.Email = EditFieldTemplate("o", "email");
                            break;
                        case "7":
                        case "vat":
                        case "nif":
                            client.Vat = EditFieldTemplate("o", "número de contribuinte");
                            break;
                        default:
                            Console.WriteLine("Opção invalida.\n");
                            continue;

                    }
                    break;
                }
            }

            Save();
            
        }

        public void ListTrips(){
            // List all payments made by a client

        }

        public void ListPayments(){
            // List all trips made by a client

        }

        public void Trip(Client? client=null){
            // Add a trip to a client
            if(client is null)
                if((client = validateID()) is null)
                    return;
            float price = 3.14f;
            Console.WriteLine($"A viagem tem um custo de {price}");
            if(client.Credit<price){
                Console.WriteLine($"{client.Name} não têm saldo suficiente, falta {price-client.Credit:C} para poder fazer a viagem.\n");
                ProposeRecharge();
                
            }
            else if(client.CreditExpiry < DateTime.Now){
                Console.WriteLine($"A validade do passe de {client.Name} expirou a {client.CreditExpiry}, para voltar a usufruir dos {client.Credit:C} restantes recarregue o passe.");
                ProposeRecharge();
            }
            else{
                client.Credit = client.Credit - price;
                Console.Write($"Foram debitados {price:C} do passe, {client.Name} tem {client.Credit:C} restantes no cartão, validos até {client.CreditExpiry}");
                //save operation
                //update client record
                Save();

            }
        }

        private void ProposeRecharge(){
            string? op;
                for(int i=0; i<3; i++){
                    Console.Write("Deseja realizar um carregamento?\n(s/n) >> ");
                    op = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(op) && (op.ToLower() == "s" || op.ToLower() == "sim")){
                        AddCredit();
                        Trip(client);
                    }
                    else if(!string.IsNullOrWhiteSpace(op) && (op.ToLower() == "n" || op.ToLower() == "não")){
                        break;
                    }
                    Console.WriteLine("Oops... Isso quer dizer sim ou não ??\n");
                }
                Console.WriteLine("De momento não é possível realizar a viagem, recarregue o passe e tente novamente.");
        }

        public void AddCredit(){
            // Add credit to trip pass

        }




        // # Extra #   (nice to have)

        // print all operations pertinent to one client into a separate balance sheet

        // search option, allow to search client database by field

        // list all clients
        public void ListAll(){
            if(ListIsEmpty())
                return;
            foreach(Client client in clients){
                Console.Write(client.FullInfo());
            }
        }


        public void Save(){
            //commit changes to file after each change
            if(clients!=null)
                file.Save(clients);
        }







    }
}
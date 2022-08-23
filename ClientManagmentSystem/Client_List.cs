using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;


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

        private void FilterData(int[] lines, Client client, bool append=false){
            // lines index reference:
            // ID = 1, active = 2, name = 3, address = 4, postal = 5, city = 6, phone = 7, email = 8, vat = 9, credit = 10, validity = 11
            string[] info = client.SplittedInfo();
            int a = 1;
            foreach(int i in lines){
                Console.WriteLine(append?a+" - "+(info[i].Trim()):info[i]);
                a++;
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
            for(int i=0; i<3; i++){
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
            Console.WriteLine("\t\t# Lista de clientes ativos #\n");
            if(!ListIsEmpty()){
                // List all active clients
                bool any = false;
                foreach(Client client in clients){
                    if(client.Active){
                        if(any)
                            Console.WriteLine("\n---------------------------------------------\n");
                        FilterData(new int[] {1,3,9,10}, client);
                        any = true;
                    }
                }
                if(!any)
                    Console.WriteLine("\t    * De momento não existem nenhuns *");
            }
        }
    

        public void ListPositiveCredit(){
            Console.WriteLine("\t# Lista de clientes com credito no passe #\n");
            if(ListIsEmpty())
                return;
            // List all active client, with positive availble credit
            bool any = false;
            foreach(Client client in clients){
                if(client.Active && client.Credit>0){
                    if(any)
                        Console.WriteLine("\n---------------------------------------------\n");
                    FilterData(new int[] {1,3,10,11}, client);
                    any = true;
                }
            }
            if(!any)
                Console.WriteLine("\t    * De momento não existem nenhuns *");
        }

        public void ListExpired(){
            Console.WriteLine("\t# Lista de clientes com credito expirado #\n");
            if(!ListIsEmpty()){
                // List all active clients with expired credit validity 
                bool any = false;
                foreach(Client client in clients){
                    if(client.Active && client.CreditExpiry < DateTime.Now){
                        if(any)
                            Console.WriteLine("\n---------------------------------------------\n");
                        FilterData(new int[] {1,3,10,11}, client);
                        any = true;
                    }
                }
                if(!any)
                    Console.WriteLine("\t    * De momento não existem nenhuns *");
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


            Console.WriteLine("\nFoi adicionado o seguinte cliente: \n"+clients[clients.Count -1].FullInfo());

            Save();
        }

        public void DeactivateClient(){
            // Remove a client (make inactive)
            Client? client = validateID();
            if(client!=null){
                Console.WriteLine(client.FullInfo());
                string? sure="";
                for(int i=0; i<3 && !( sure=="sim" || sure=="yes" || sure=="no" || sure=="nao" || sure=="não"); i++){
                    Console.Write("Tem a certeza que quer eliminar este cliente?\n > ");
                    sure = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(sure)){sure=sure.ToLower();}
                }
                if(sure=="sim" || sure=="yes"){
                    client.Active=false;
                    Console.WriteLine("Cliente eliminado!");
                    Save();
                }
                else{
                    Console.WriteLine("\na voltar ao menu principal...");
                    Console.WriteLine(" # Sem alterações #");
                }
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
        }
        public void EditClient(){

            Client? client = validateID(); 
            if(client!=null){
                Console.WriteLine("\n\t\t# menu de edição #");
                while(true){
                    Console.WriteLine("\t(escolha o campo que pretende editar)\n");
                    FilterData(new int[] {3,4,5,6,7,8,9}, client, true);
                    Console.WriteLine("0 - Sair de submenu");
                    Console.Write(">> ");
                    string? option = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(option))
                        continue;
                    else
                        option=option.ToLower();
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
                    Save();
                    for(int i=0; i<3;i++){
                        Console.Write("\nContinuar a editar?\n(S/N) : ");
                        option = Console.ReadLine();
                        if(!string.IsNullOrWhiteSpace(option))
                            option=option.ToLower();
                        if(option=="nao" || option=="não" || option=="no" || option=="n"){
                            Console.WriteLine("A sair de edição...");
                            return;
                        }
                        else if(option=="sim" || option=="s" || option=="yes" || option=="y"){
                            break;
                        }
                        else{
                            Console.WriteLine("Resposta invalida.");
                            if(i==2){
                                Console.WriteLine("Demasiadas tentativas. A sair de edição...");
                                return;
                            }

                        }


                        
                    }
                }
            }    
        }

        public void ListBalance(){
            Client? client;
            if((client = validateID()) is null)
                return;
            file.ReadBalance(client, "all");
        }


        public void ListTrips(){
            // List all payments made by a client
            Client? client;
            if((client = validateID()) is null)
                return;
            file.ReadBalance(client, "trips");
        }

        public void ListPayments(){
            // List all trips made by a client
            Client? client;
            if((client = validateID()) is null)
                return;
            file.ReadBalance(client, "payments");

        }

        public void Trip(Client? client=null){
            // Add a trip to a client
            if(client is null)
                if((client = validateID()) is null)
                    return;
            float price = 3.14f;
            Console.Write($"A viagem tem um custo de {price}");
            if(client.Credit<price){
                Console.WriteLine($"\n{client.Name} não têm saldo suficiente, falta {price-client.Credit:C} para poder fazer a viagem.\n");
                ProposeRecharge(client);
                
            }
            else if(client.CreditExpiry < DateTime.Now){
                Console.WriteLine($"\nA validade do passe de {client.Name} expirou a {client.CreditExpiry}, para voltar a usufruir dos {client.Credit:C} restantes recarregue o passe.");
                ProposeRecharge(client);
            }
            else{
                string? opt="";
                Console.WriteLine(", deseja prosseguir?");
                for(int i=0; i<4; i++){
                    Console.Write("(s/n) > ");
                    opt = Console.ReadLine();
                    if(!(string.IsNullOrWhiteSpace(opt)) && (opt.ToLower()=="nao" || opt.ToLower()=="não" || opt.ToLower()=="no" || opt.ToLower()=="n"))
                        break;
                    else if(!(string.IsNullOrWhiteSpace(opt)) && (opt.ToLower()=="sim" || opt.ToLower()=="s" || opt.ToLower()=="yes" || opt.ToLower()=="y")){
                        client.Credit = client.Credit -price;
                        Console.Write($"Foram debitados {price:C} do passe, {client.Name} tem {client.Credit:C} restantes no cartão, validos até {client.CreditExpiry}");
                        //save operation
                        Save(client, -price);
                        //update client record
                        Save();
                        return;
                    }
                    else{
                        Console.WriteLine("Opção invalida. Por favor responda com 'sim' ou 'não'.");
                    }
                }
                Console.WriteLine("Viagem cancelada !");
            }
        }

        private void ProposeRecharge(Client client){
            string? op;
            for(int i=0; i<3; i++){
                Console.Write("Deseja realizar um carregamento?\n(s/n) >> ");
                op = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(op) && (op.ToLower() == "s" || op.ToLower() == "sim" || op.ToLower() == "yes" || op.ToLower() == "y")){
                    AddCredit(client);
                    Trip(client);
                    return;
                }
                else if(!string.IsNullOrWhiteSpace(op) && (op.ToLower() == "n" || op.ToLower() == "não" || op.ToLower() == "nao" || op.ToLower() == "no")){
                    break;
                }
                Console.WriteLine("Oops... Isso quer dizer sim ou não ??\n");
            }
            Console.WriteLine("De momento não é possível realizar a viagem, recarregue o passe e tente novamente.");
        }

        public void AddCredit(Client? client=null){
            // Add credit to trip pass
            if(client is null)
                if((client = validateID()) is null)
                    return;
            for(int i=0; i<5; i++){
                Console.WriteLine($"Insira o valor que deseja creditar no passe de {client.Name} (montante mínimo de 5€).");
                Console.Write("valor >> ");
                float credit;
                if(((float.TryParse(Console.ReadLine().Replace(".",","), NumberStyles.Currency ,CultureInfo.CurrentCulture, out credit)) )&& credit>=5){
                    client.Credit = client.Credit + credit;
                    client.CreditExpiry = DateTime.Now.AddDays(30);
                    Save(client, credit);
                    Save();
                    Console.WriteLine($"Crédito de {credit:c} adicionado ao passe de {client.Name}");
                    return;
                }else{
                    Console.WriteLine("Valor inserido não é valido...");
                }
            }
            Console.WriteLine("Volte a tentar novamente mais tarde...");
        }


        public void Save(){
            //commit changes to file after each change
            if(clients!=null)
                file.SaveClients(clients);
        }
        public void Save(Client client, float amount){
            //commit changes to file after each change
            if(clients!=null){
                file.SaveOperation(client, amount, DateTime.Now);
            }
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









    }
}
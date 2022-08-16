using System.Globalization;

namespace ClientManagmentSystem;
class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-PT");
        Client_List clients = new Client_List();

        while(true){
        // # Menu #
            Console.WriteLine(@"
                    ### MENU ###
            1- Listar todos os clientes ativos
            2- Listar clientes ativos com saldo disponível
            3- Listar clientes ativos com data de validade expirada
            4- Informações detalhadas de cliente
            5- adicionar novo cliente
            6- Eliminar cliente
            7- Editar cliente
            8- Listar carregamentos de um cliente
            9- listar consumos de um cliente
            10- Adicionar viagem (consumo)
            11- Adicionar carregamento

            0- Sair
            ");
            Console.Write(">> ");
            string? opt = Console.ReadLine();
            switch(opt){
                case "1":
                    // List all active clients
                        //show:
                        //Client Id
                        //Name
                        //Vat number
                        //Availble credit
                    clients.ListAllActive();
                    break;
                case "2":
                    // List all active client, with positive availble credit
                        //show:
                        //Client Id
                        //Name
                        //Availble credit value
                        //Credit validity
                    clients.ListPositiveCredit();
                    break;    
            
            // List all active clients with expired credit validity 
                //show:
                //Client Id
                //Name
                //Availble credit value
                //For how long the credit has expired
            // List a single client
                //show:
                //Client ID -> array index +1
                //Name
                //Address
                //Postal code
                //Locality
                //Phone number
                //Email
                //VAT number
                //Current credit
                //Credit validity
            // Add a new client
            // Remove a client (make inactive)
            // Edit a client
            // List a clients balance sheet
                //show:
                //Client Id
                //Name
                //DateTime for operation
                //Amount (+ for charging the trip pass, - for trip made, thus amount debited from trip pass)
            // Add a trip to a client
                //show:
                //Client ID (?)
                //Client Name (?) 
                //Trip cost
                //DateTime of the charge for the trip
            // Add credit to trip pass
                //Client ID (?)
                //Client Name (?) 
                //Amount paid by the client
                //DateTime of the payment
                case "0":
                    return;
                case "list all":
                    clients.ListAll();
                    break;
                default:
                    //Invalid option message
                    Console.WriteLine("Opção invalida!");
                    break;
            }
            Console.WriteLine("\n\t\t( Enter to continue )");
            Console.ReadLine();
        }
    }
}

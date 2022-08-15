using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

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


        private string CLIENTS_FILE = "clients.csv";

        public List<Client>? LoadList(){
            // return a complete client list loaded from csv file     
            List<Client>? storedClients = new List<Client>();

            try{
                foreach (string line in File.ReadLines(CLIENTS_FILE)){
                    string[] tokens = line.Split(';');
                    float credit = float.Parse(tokens[9]);
                    DateTime credExp = DateTime.ParseExact(tokens[10], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    storedClients.Add(new Client(
                        int.Parse(tokens[0]),
                        tokens[1]=="true",
                        tokens[2],
                        tokens[3],
                        tokens[4],
                        tokens[5],
                        tokens[6],
                        tokens[7],
                        tokens[8],
                        credit,
                        credExp
                    ));
                }

            }
            catch (UnauthorizedAccessException){
                Console.WriteLine("Not enough permitions to read the file. Run this program with the correct privileges to get access to file");
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException){
                Console.WriteLine($"The file '{Path.GetFileName(CLIENTS_FILE)}' was not found in {Path.GetDirectoryName(Path.GetFullPath(CLIENTS_FILE))}");
                Console.WriteLine("Check if file exists, has the right name and extension, as well that it is located in the specified directory.");
                while(true){
                    Console.Write("\nDo you wish to proceed with an empty client list? (Yes/No): ");
                    string? opt = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(opt))
                        continue;
                    else if(opt.ToLower() == "no" || opt.ToLower() == "n")
                        Environment.Exit(9);
                    else if(opt.ToLower() != "yes" || opt.ToLower() == "y")
                        break;
                }
            }
            return storedClients;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Contact_DB
{
    internal class StdMsg
    {

        public static void AskForValid(string fieldName)
        {
            Console.WriteLine($"Please insert a valid {fieldName}.");
        }
        
        public static void DbConnectionError()
        {
            Console.WriteLine("An error has occurred while tying to connect to database");
        }

        public static void ForcedExit()
        {
            Console.WriteLine("Terminating the application...");
        }

        public static void InsertSuccessful()
        {
            Console.WriteLine("Client added to database");
        }

        public static void InsertFailed()
        {
            Console.WriteLine("Failed to add client to database");
        }

        public static void InvalidOption()
        {
            Console.WriteLine("That is not an option... \nChoose one of the numbers from the menu");
        }
    }
}

namespace Console_Contact_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adapter adapter = new Adapter();

            while (true)
            {
                Console.WriteLine("\n\t### MENU ###");
                Console.WriteLine("1- Insert new contact");
                Console.WriteLine("2- List all contacts");
                Console.WriteLine("3- Exit");
                Console.Write("> ");
                string? opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Contact_Model _contact = new Contact_Model();
                        adapter.Insert(_contact);
                        break;
                    case "2":
                        List<Contact_Model> contacts = adapter.Read();
                        foreach(Contact_Model contact in contacts)
                        {
                            Console.WriteLine($@"------------------------------
         _Contact Info_                                
ID:.......{contact.ID}
Name:.....{contact.Name}
Age:......{contact.Age}
Address:..{contact.Address}");
                        }
                        Console.WriteLine("------------------------------");
                        break;
                    case "3":
                    case "0":
                        return;
                    default:
                        StdMsg.InvalidOption();
                        break;
                }
            }

        }
    }
}
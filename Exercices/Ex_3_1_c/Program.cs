namespace Ex_3_1_c;
class Program
{
    static void Main(string[] args)
    {
        Person person = new();

        Console.WriteLine("\nHello !\n");
        Console.Write("What is your name?\n> ");
        person.Name = Console.ReadLine();
        Console.Write("What is your surname?\n> ");
        person.Surname = Console.ReadLine();
        Console.Write("\nNice to meet you {0} {1}.\n\n", person.Name, person.Surname);
        while(true){
            Console.Write("How old are you?\n> ");
            if(int.TryParse(Console.ReadLine(), out int temp)){
                if(temp>0){
                    person.Age = temp;
                    break;
                }
            }
            Console.WriteLine("Insert a valid age!");
        }
        Console.Write("And where do you live, {0}?\n>", person.Name);
        person.Address = Console.ReadLine();
        Console.Write("Have you lived in {0} for all of the {1} years?\n>", person.Address, person.Age);
        Console.ReadLine();
        Console.WriteLine("Ohh, okay.");
        Console.WriteLine("\nIt was nice to meet you {0}.", person.Name);
        Thread.Sleep(3500);
        Console.WriteLine("Bye!");

    }
}

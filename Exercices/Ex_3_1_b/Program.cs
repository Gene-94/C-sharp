namespace Ex_3_1_b;
class Program
{
    static void Main(string[] args){
        Person person = new();

        Console.WriteLine("\nHello !\n");
        Console.Write("What is your name?\n> ");
        person.Name = Console.ReadLine();
        Console.Write("\nWhat is your surname?\n> ");
        person.Surname = Console.ReadLine();
        while(true){
            Console.Write("\nWhat is your age?\n> ");
            if(int.TryParse(Console.ReadLine(), out int temp)){
                if(temp>0){
                    person.Age = temp;
                    break;
                }
            }
            Console.WriteLine("Insert a valid age!");
        }
        Console.Write("\nNice to meet you {0} {1}. I see you are {2} years wise.\n", person.Name, person.Surname, person.Age);
    }
}

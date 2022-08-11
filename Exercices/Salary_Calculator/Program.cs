namespace Salary_Calculator;
class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new();
        int hours;
        int income;

        Console.WriteLine("### Salary calculator ###\n");
        Console.WriteLine("Welcome, here you're able to calculate your income based on the number of hours worked\n");

        do{
            Console.Write("Insert the number of hours worked: ");

        }while(!int.TryParse(Console.ReadLine(), out hours));

        calc.HoursWorked = hours;

        calc.PrintMessage();
        
    }
}

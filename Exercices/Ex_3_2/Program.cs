using System.Globalization;
namespace Ex_3_2;
class Program
{
    static void Main(string[] args)
    {
        CultureInfo culture = new CultureInfo("pt-PT");  

        MyData data = new();

        Console.Write("What is you favorite year?\n> ");
        while(true){
            if(ushort.TryParse(Console.ReadLine(), out var tmp)){
                data.myUnsignedShort = tmp;
                break;
            }
            Console.WriteLine("Please enter a valid year!");
        }
        Console.Write("What was the best thing that happened that year?\n> ");
        data.myString = Console.ReadLine();
        Console.Write("Did you buy something you really liked that year?\n> ");
        while(true){
            if(Boolean.TryParse(Console.ReadLine(), out var tmp)){
                data.myBool = tmp;
                break;
            }
            Console.WriteLine("Please answer with 'true' or 'false'");
        }
        while(data.myBool){
            Console.Write("How much did it cost?\n> ");
            if(float.TryParse(Console.ReadLine(), out var tmp)){
                if(tmp>=0){
                    data.myFloat=tmp;
                    break;
                }
            }
            Console.WriteLine("Insert a valid value for the item price.");
        }
        while(true){
            Console.Write("When were you born?\n(dd/mm/yyyy) > ");
            if(DateTime.TryParse(Console.ReadLine(), out var date)){
                data.myDouble = (DateTime.Now).Subtract(date).TotalSeconds;
                break;
            }
            Console.WriteLine("Write a valid date!");
        }
    }
}

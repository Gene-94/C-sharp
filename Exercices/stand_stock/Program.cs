using System;
using System.IO;
using System.Text;

namespace stand_stock;
class Program
{
    static void Main(string[] args)
    {
        Cars stand = new("stock.csv");
        stand.ListStock();

        Console.WriteLine("### Welcome to the Virtual Stand ###");
        Console.WriteLine("\n-- Menu -- ");
        Console.WriteLine("1- List the whole collection");
        Console.WriteLine("2- Take a veicule of our hands");
        Console.WriteLine("3- Donate a vehicle to our collection");
        Console.WriteLine("4- Merge your collection with ours");
        Console.WriteLine("5- Get a copy of our collection in stock");
        Console.WriteLine("0- Exit");
        string? opt = Console.ReadLine();
        switch(opt){
            case "1":
                stand.ListStock();
                break;
            case "2":
                stand.SellCar();
                break;
            case "3":
                Car car = new Car();
                stand.Add(car);
                break;
            case "4":
                break;
            case "5":
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

}

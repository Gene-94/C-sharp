using System;
using System.IO;
using System.Text;

namespace stand_stock;
class Program
{
    static void Main(string[] args)
    {
        Cars stand = new("stock.csv");

        Console.WriteLine("### Welcome to the Virtual Stand ###");
        while(true){
            Console.WriteLine("\n-- Menu -- ");
            Console.WriteLine("1- List the whole collection");
            Console.WriteLine("2- Take a veicule of our hands");
            Console.WriteLine("3- Donate a vehicle to our collection");
            Console.WriteLine("4- Merge your collection with ours");
            Console.WriteLine("5- Get a copy of our collection in stock");
            Console.WriteLine("0- Exit");
            Console.Write("\noption: ");
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
                    while(true){
                        Console.Write("Full path to your collection csv file: ");
                        string path = Console.ReadLine();
                        if(!string.IsNullOrWhiteSpace(path) && path.EndsWith(".csv")){
                            stand.ImportStockList(path);
                            break;
                        }
                        Console.WriteLine("Invalid path!\nCheck that the path actually exists and that you're including the filename and its extension (.csv)");
                    }
                    break;
                case "5":
                    stand.PrintStock("AmazingCarsToBuy.csv");
                    Console.WriteLine($"Done.\nYour file is at {Path.GetFullPath("AmazingCarsToBuy.csv")}");
                    break;
                case "0":
                //Update the current file before exiting
                    stand.PrintStock("stock.csv");
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

}

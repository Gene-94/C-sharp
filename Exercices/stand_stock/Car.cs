using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace stand_stock
{
    public class Car
    {
        public string Brand{get;private set;}
        public string Model{get;private set;}
        public int Year{get; private set;}

        public Car(){
            
            do{
                Console.Write("Brand: ");
            }while(string.IsNullOrWhiteSpace(Brand = Console.ReadLine()));
            do{
                Console.Write("Model: ");
            }while(string.IsNullOrWhiteSpace(Model = Console.ReadLine()));
            while(true){
                Console.Write("License plate year: ");
                try{
                    Year = int.Parse(Console.ReadLine());
                    break;
                }catch (Exception e) when (e is ArgumentNullException || e is FormatException || e is OverflowException){
                    Console.WriteLine("Please, insert a valid year");
                }
            }   
        }

        public Car(string brand, string model, int year){
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
        }
    }
}
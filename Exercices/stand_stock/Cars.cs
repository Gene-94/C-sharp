using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stand_stock
{
    public class Cars
    {
        private List<Car> cars = new();

        public Cars(){}
        public Cars(string path){
            ImportStockList(path);
        }
        
        public void Add(Car new_car){
            cars.Add(new_car);
        }

        public void GetInfo(int index){
            // When passing I will be working with car numbers, so I will pass (int carNumber-1)
            if(index<0){Console.Write("Invalid index!");}
            else if(index>=cars.Count){Console.Write($"There aren't that many cars yet. At the moment there are {cars.Count} cars.");}
            else if(index<cars.Count){
                Console.WriteLine("\n######################");
                Console.WriteLine($"\tCar nrº{index+1} ");
                Console.WriteLine($"Brand: {cars[index].Brand}");
                Console.WriteLine($"Model: {cars[index].Model}");
                Console.WriteLine($"License plate year: {(cars[index].Year==0?"Not available":cars[index].Year)}");
            }
        }

        public void ListStock(){
            if(cars.Count>0){
                for(int i=0; i<cars.Count; i++){
                    GetInfo(i);
                }
            }else{Console.WriteLine("SOLD OUT! No cars availble");}
        }

        public void SellCar(){
            while(true){
                Console.WriteLine("What is the number of the car you want to get?");
                Console.Write(">> ");
                try{
                    int carNr = int.Parse(Console.ReadLine());
                    cars.RemoveAt(carNr-1);
                    break;
                }
                catch (ArgumentOutOfRangeException){
                    Console.WriteLine("Inserted car number does not exist. \nMake sure the car with can number desired is still availble by listing our collection");
                }
                catch (Exception e) when (e is ArgumentNullException || e is FormatException || e is OverflowException){
                    Console.WriteLine("That is not a valid car number.");
                }
            }
        }

        public void ImportStockList(string path){
            // Imports a list of veicules from a csv file
            // Can be used to inicialize the class or to just add more veicules to it
            Reader import = new Reader(path);

            //import.Load() needs to return a list of type Car
            cars.AddRange(import.Load());
        }


    }
}
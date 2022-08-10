using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;

namespace stand_stock
{
    public class Reader{
        
        private string path;

        public Reader(string file_path){
            this.path = file_path;
        }

        public List<Car> Load(){

            List<Car>? newStock = new List<Car>();
            StreamReader reader = new("stock.csv");
            try{
                reader = new(path);
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException){
                return null;
            }

            
            for(int i=1; true; i++){
                string? buff=reader.ReadLine();
                if(buff == null)
                    break;
                buff.Trim();
                string [] tokens = buff.Split(';');

                Car newCar = new Car(tokens[0], tokens[1], 0);
                Action<Exception> ParseHandler = (e) => {
                    Console.WriteLine($"Incurred into a missing or poorly formatted date on line {i}, therefore setting it to 0");
                };
                try{
                    newCar = new Car(tokens[0], tokens[1], int.Parse(tokens[2]));
                }
                catch (ArgumentNullException e){ParseHandler(e);}
                catch (FormatException e){ParseHandler(e);}
                catch (OverflowException e){ParseHandler(e);}
                finally{newStock.Add(newCar);}
            }

            return newStock;
        }

        public void SaveToFile(List<Car> stock, string path){

            StreamWriter writer = new(path, true);

            for(int i=0; i<stock.Count; i++){
                string line = stock[i].Brand + ";" + stock[i].Model + ";" + stock[i].Year ;
                writer.WriteLine(line);
            }
            writer.Close();

        }
    
    }
}
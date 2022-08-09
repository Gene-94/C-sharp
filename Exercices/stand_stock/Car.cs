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
        public int Year{get;private set;}

        Car(string brand, string model, string year){
           Year = Int32.TryParse(year);
        }
    }
}
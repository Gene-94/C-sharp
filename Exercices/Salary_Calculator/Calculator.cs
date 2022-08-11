using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Salary_Calculator
{
    public class Calculator
    {

        private int hoursWorked;
        public int HoursWorked {
            get{return hoursWorked;} 
            set{
                if (value>0)
                    hoursWorked=value;
                else
                    hoursWorked=0;
            }
        }

        private float hourlyRate=5;
        

        private float CalculatePay() => (HoursWorked * hourlyRate);
        
        public void PrintMessage() {
            //Console.WriteLine($"Calculating Pay{Thread.Sleep(1500)}.{Thread.Sleep(1500)}.{Thread.Sleep(1500)}.");
            Console.WriteLine("Calculating amount...");
            Task.Delay(3000);
    
            CultureInfo.CurrentCulture = new CultureInfo("pt-PT");
            Console.WriteLine($"Your salary is {CalculatePay():C}");
        }

    }
}
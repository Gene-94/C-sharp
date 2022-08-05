using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        private int hourlyRate=5;

        public void PrintMessage() {
            Console.WriteLine("Calculating Pay...");
        }

        public int CalculatePay(){
            PrintMessage();

            int staffPay = HoursWorked * hourlyRate;

            return staffPay;
        }
    }
}
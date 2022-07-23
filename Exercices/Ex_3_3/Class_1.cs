using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_3_3
{
    public class Class_1
    {
        


        public void sumThreeInt(){
            // Variables: total and num both int
            int total = 0, num = 0;
            Console.WriteLine("Hello! \nWe are gonna sum three integer numbers.\n");
            for(int i=1; i<4; i++){
                while(true){
                    Console.Write("Insert number {0}: ", i);
                    if(int.TryParse(Console.ReadLine(), out num))
                        break;
                    Console.WriteLine("Insert a valid number!");
                }
                total += num;
            }
            
            Console.Write("The total sum of your numbers is {0}\n\n", total);
        }

        public void swapfloats(){
            float num1, num2, holder;
            Console.WriteLine("We are gonna do a magic trick and swap two floating point numbers!");
            Console.Write("Insert value of float 1: ");
            while(true){
                if(float.TryParse(Console.ReadLine(), out num1)){
                    break;
                }
            }
            Console.Write("Insert value of float 2: ");
            while(true){
                if(float.TryParse(Console.ReadLine(), out num2)){
                    break;
                }
            }
            holder = num1;
            num1 = num2;
            num2 = holder;
            Console.WriteLine("And now...");
            Thread.Sleep(2000);
            Console.WriteLine("The float in hat 1 will magically switch places with the float in hat 2...");
            Thread.Sleep(2500);
            Console.WriteLine("TAAADAANN !\nThe value of float 1 is now {0} and the value of float 2 is {1}.", num1, num2);
        }



    }
}
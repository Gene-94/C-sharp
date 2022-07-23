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



    }
}
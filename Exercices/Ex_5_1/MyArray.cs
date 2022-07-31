using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_5_1
{
    public class MyArray
    {
        private int[] myArray;
        public MyArray(int[] myArray)
        {
            try{
                Array.Copy(myArray, this.myArray, myArray.Length);
            }
            catch (Exception e){
                
            }
        }
        public int[] GetMyArray()
        {
            return myArray;
        }
        public int GetMyArraySoma(){
            return myArray.Sum();

        }
        public int[] GetMyArrayPar(){
            List<int> Pairs = new List<int>();
            foreach(var elem in myArray){
                if(elem % 2 == 0)
                    Pairs.Add(elem);
            }
            return Pairs.ToArray();
        }
        public int[] GetMyArrayImPar(){
             List<int> Pairs = new List<int>();
            foreach(var elem in myArray){
                if(elem % 2 == 1)
                    Pairs.Add(elem);
            }
            return Pairs.ToArray();
        }
        public int[] GetMyArrayPos(){
             List<int> Pairs = new List<int>();
            foreach(var elem in myArray){
                if(elem > 0)
                    Pairs.Add(elem);
            }
            return Pairs.ToArray();
        }
        public int[] GetMyArrayNeg(){
             List<int> Pairs = new List<int>();
            foreach(var elem in myArray){
                if(elem < 0)
                    Pairs.Add(elem);
            }
            return Pairs.ToArray();
        }
        public int[] GetMyArrayCresc(){
            int[] sortedArray = new int[(myArray.Length)];
            Array.Copy(myArray, sortedArray, myArray.Length);
            Array.Sort(sortedArray);
            return sortedArray;
        }
        public int[] GetMyArrayDecresc(){
            int[] sortedArray = new int[(myArray.Length)];
            Array.Copy(myArray, sortedArray, myArray.Length);
            Array.Sort(sortedArray);
            Array.Reverse(sortedArray);
            return sortedArray;
        }
        public void Print(int[] myArrayToPrint){
            try{
                Console.Write("[ ");
                foreach(var elem in myArrayToPrint)
                    Console.Write(elem+" ");
                Console.Write("]\n");
            }
            catch (Exception e){

            }
        }
    }
}
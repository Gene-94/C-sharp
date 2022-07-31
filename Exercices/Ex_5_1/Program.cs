namespace Ex_5_1;
class Program
{
    static void Main(string[] args)
    {
        MyArray myArray = new MyArray(new int[] {51, 16, -33, 154, -77, 876, 32, -28, 93});
        Console.WriteLine("\n\na) myArray = ");
        myArray.Print(myArray.GetMyArray());
        Console.WriteLine("b) myArray = ");
        myArray.GetMyArraySoma();
        Console.WriteLine("c) myArray = ");
        myArray.Print(myArray.GetMyArrayPar());
        Console.WriteLine("d) myArray = ");
        myArray.Print(myArray.GetMyArrayImPar());
        Console.WriteLine("e) myArray = ");
        myArray.Print(myArray.GetMyArrayPos());
        Console.WriteLine("f) myArray = ");
        myArray.Print(myArray.GetMyArrayNeg());
        Console.WriteLine("g) myArray = ");
        myArray.Print(myArray.GetMyArrayCresc());
        Console.WriteLine("h) myArray = ");
        myArray.Print(myArray.GetMyArrayDecresc());


    }
}

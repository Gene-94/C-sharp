using System;
using System.IO;
using System.Text;

namespace stand_stock;
class Program
{
    static void Main(string[] args)
    {
        
        FileStream fs = new FileStream("stock.csv", FileMode.Open, FileAccess.ReadWrite);

        //string? message = "test";

        byte[] message = new UTF8Encoding(true).GetBytes("test");
        fs.Write(message);
        fs.Close();
    }
}

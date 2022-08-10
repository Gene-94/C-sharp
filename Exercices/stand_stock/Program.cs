using System;
using System.IO;
using System.Text;

namespace stand_stock;
class Program
{
    static void Main(string[] args)
    {
           Cars stand = new("stock copy.csv");
           stand.ListStock();
    }

}

using System;
using System.IO;
using System.Text;

namespace stand_stock;
class Program
{
    static void Main(string[] args)
    {
        
        using (FileStream fs = File.Create("test_file.txt")){
            AddText(fs, "Line 1\n");
            AddText(fs, "Line 2\n");
            AddText(fs, "Another great line\n");
            AddText(fs, "This block is on a new line");
            AddText(fs, ", but this is not.");

        }
    }

    private static void AddText(FileStream fs, string msg){
        byte[] byte_msg = new UTF8Encoding(true).GetBytes(msg);
        fs.Write(byte_msg);
    }
}

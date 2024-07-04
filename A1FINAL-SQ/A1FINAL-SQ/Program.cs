using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using A1FINAL_SQ;

namespace A1FINAL_SQ
{
    class Program
    {
        static void Main(string[] args)
        {
            MyModernAppliances app = new MyModernAppliances();

            string filePath = "appliances.txt";
            if (File.Exists(filePath))
            {
                app.LoadAppliances(filePath);
                app.DisplayMenu();
            }
            else
            {
                Console.WriteLine($"Error {filePath}' not found.");
                Console.WriteLine("press any key to exit......");
                Console.ReadKey();
            }
        }
    }
}
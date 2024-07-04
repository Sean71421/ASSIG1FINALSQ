using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A1FINAL_SQ.ProblemDomain;

namespace A1FINAL_SQ.ProblemDomain

{ public class Refrigerator : Appliance
        {
            public int Doors { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }

            public Refrigerator(string itemNumber, string brand, int quantity, double wattage, string color, double price, int doors, int height, int width)
                : base(itemNumber, brand, quantity, wattage, color, price)
            {
                Doors = doors;
                Height = height;
                Width = width;
            }
            public override string FormatForFile()
            {
                return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Doors};{Height};{Width} ";
            }

            public override string ToString()
            {
                return $"Item Number: {ItemNumber}\n" +
                       $"Brand: {Brand}\n" +
                       $"Quantity: {Quantity}\n" +
                       $"Wattage: {Wattage}\n" +
                       $"Color: {Color}\n" +
                       $"Price: {Price}\n" +
                       $"Number of Doors: {(Doors == 2 ? "Doubles Door" : Doors == 3 ? "Three Doors" : "Four Doors")}\n" +
                       $"Height: {Height}\n" +
                       $"Width: {Width}";
            }
        }
    }
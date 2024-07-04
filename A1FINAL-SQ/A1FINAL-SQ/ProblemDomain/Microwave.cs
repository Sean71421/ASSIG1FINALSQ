using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1FINAL_SQ.ProblemDomain
{
        public class Microwave : Appliance
        {
            public double Capacity { get; set; }
            public string RoomType { get; set; }

            public Microwave(string itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomType)
                : base(itemNumber, brand, quantity, wattage, color, price)
            {
                Capacity = capacity;
                RoomType = roomType;
            }

            public override string FormatForFile()
            {
                return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{RoomType}";
            }


            public override string ToString()
            {
                return $"Item Number: {ItemNumber}\n" +
                       $"Brand: {Brand}\n" +
                       $"Quantity: {Quantity}\n" +
                       $"Wattage : {Wattage}\n" +
                       $"Color: {Color}\n" +
                       $"Price: {Price}\n" +
                       $"Capacity: {Capacity}\n" +
                       $"Room Type: {(RoomType == "K" ? "kitchen" : "Work Site")}";
            }
        }
    }

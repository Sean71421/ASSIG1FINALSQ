using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A1FINAL_SQ.ProblemDomain;

namespace A1FINAL_SQ.ProblemDomain
{
        public class Vacuum : Appliance
        {
            public string Grade { get; set; }
            public int BatteryVoltage { get; set;}
            public Vacuum(string itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int batteryVoltage)
                : base(itemNumber, brand, quantity, wattage, color, price)
            {
                Grade = grade;
                BatteryVoltage = batteryVoltage;
            }
            public override string FormatForFile()
            {
                return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage}";
            }




            public override string ToString()
            {
                return $"Item Number: {ItemNumber}\n" +
                       $"Brand: {Brand}\n" +
                       $"Quatity: {Quantity}\n" +
                       $"Wattage: {Wattage}\n" +
                       $"Color: {Color}\n" +
                       $"Price: {Price}\n" +
                       $"Grade: {Grade}\n" +
                       $"Battery voltage: {(BatteryVoltage == 18 ? "Low " : "High")}";
            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A1FINAL_SQ.ProblemDomain;

namespace A1FINAL_SQ
{
    public class MyModernAppliances : ModernAppliances
    {
        public MyModernAppliances() : base()
        {
        }
        public void DisplayDishwashers()
        {
            var dishwashers = Appliances.OfType<Dishwasher>().ToList();
            foreach (var dishwasher in dishwashers)
            {
                Console.WriteLine(dishwasher.ToString());
                Console.WriteLine();
            }
        }
        public void DisplayMicrowaves()
        {
            var microwaves = Appliances.OfType<Microwave>().ToList();
            foreach (var microwave in microwaves)
            {
                Console.WriteLine(microwave.ToString());
                Console.WriteLine();
            }
        }

        public void DisplayRefrigerators()
        {
            var refrigerators = Appliances.OfType<Refrigerator>().ToList();
            foreach (var refrigerator in refrigerators)
            {
                Console.WriteLine(refrigerator.ToString());
                Console.WriteLine();
            }
        }

        public void DisplayVacuums()
        {
            var vacuums = Appliances.OfType<Vacuum>().ToList();
            foreach (var vacuum in vacuums)
            {
                Console.WriteLine(vacuum.ToString());
                Console.WriteLine();
            }
        }



        public override void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome To Modern Appliances!");
                Console.WriteLine("How May We Assist You?");
                Console.WriteLine("1 – Check Out Appliance");
                Console.WriteLine("2 – Find Appliances By Brand");
                Console.WriteLine("3 – Display Appliances By Type");
                Console.WriteLine("4 – Produce Random Appliance List");
                Console.WriteLine("5 – Save & exit");
                Console.Write("Enter Option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case ".1":
                        Checkout();
                        break;
                    case "2":
                        FindAppliancesByBrand();
                        break;
                    case "3":
                        DisplayAppliancesByType();
                        break;
                    case "4":
                        RandomList();
                        break;
                    case "5":
                        SaveAppliancesToFile("appliances.txt");
                        return;
                    default:
                        Console.WriteLine("Indvalid.");
                        break;
                }

                Console.WriteLine();
            }
        }



        public void RandomList()
        {
            Console.Write("enter number of appliances: ");
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
            {
                var randomAppliances = Appliances.OrderBy(a => Guid.NewGuid()).Take(count).ToList();
                foreach (var appliance in randomAppliances)
                {
                    Console.WriteLine(appliance.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("enter a posotive integer.");
            }
        }
    }
}




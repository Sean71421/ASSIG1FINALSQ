using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using A1FINAL_SQ.ProblemDomain;

namespace A1FINAL_SQ
{
        public class ModernAppliances
        {
            protected List<Appliance> Appliances;

            public ModernAppliances()
            {
                Appliances = new List<Appliance>();
            }

            public void LoadAppliances(string fileName)
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    string itemNumber = parts[0];

                    Appliance appliance = null;
                    switch (itemNumber[0])
                    {
                        case '1':
                            appliance = new Refrigerator(itemNumber, parts[1],  int.Parse(parts[2]), double.Parse(parts[3]),
                                parts[4], double.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]));
                            break;
                        case '2':
                            appliance = new Vacuum(itemNumber, parts[1], int.Parse(parts[2]), double.Parse(parts[3]),
                                parts[4], double.Parse(parts[5]), parts[6], int.Parse(parts[7]));
                            break;
                        case '3':
                            appliance = new Microwave(itemNumber, parts[1],  int.Parse(parts[2]), double.Parse(parts[3]),
                                parts[4], double.Parse(parts[5]), double.Parse(parts[6]), parts[7]);
                            break;
                        case '4':
                        case '5':
                            appliance = new Dishwasher(itemNumber,parts[1], int.Parse(parts[2]), double.Parse(parts[3]),
                                parts[4], double.Parse(parts[5]), parts[6], parts[7]);
                            break;
                    }

                    if (appliance != null)
                    {
                        Appliances.Add(appliance);
                    }
                }
            }


            public virtual void Checkout()
            {
                Console.Write("Enter The Item number: ");
                string itemNumber = Console.ReadLine();

                Appliance appliance = Appliances.FirstOrDefault(a => a.ItemNumber == itemNumber);
                if (appliance == null)
                {
                    Console.WriteLine("No appliances are with that item number.");
                    return;
                }

                if (appliance.Quantity > 0)
                {
                    appliance.Quantity--;
                    Console.WriteLine($"Appliance \"{itemNumber}\" is checked out.");
                }
                else
                {
                    Console.WriteLine("The applaince is not available!");
                }
            }
            public void FindAppliancesByBrand()
            {
                Console.Write("Enter brand to search:");
                string brand = Console.ReadLine();

                var matchingAppliances = Appliances.Where(a => a.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matchingAppliances.Count == 0)
                {
                    Console.WriteLine("no matching appliances found.");
                }
                else
                {
                    Console.WriteLine("Matchiing Appliances:");
                    foreach (var appliance in matchingAppliances)
                    {
                        Console.WriteLine(appliance.ToString());
                        Console.WriteLine();
                    }
                }
            }




            public virtual void DisplayAppliancesByType()
            {
                Console.WriteLine("Appliance Type");
                Console.WriteLine("1 -- Refrigerators");
                Console.WriteLine("2 -- Vacuums");
                Console.WriteLine("3 -- Microwaves");
                Console.WriteLine("4 -- Dishwashers");
                Console.Write("Enter your choice! ");

                string choice = Console.ReadLine();
                List<Appliance> matchingAppliances = new List<Appliance>();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Number Of Deors: 2 (Double Door), 3(Three Doors) or 4 (Four Doors): ");
                        int doors = int.Parse(Console.ReadLine());
                        matchingAppliances = Appliances.OfType<Refrigerator>().Where(r => r.Doors == doors).Cast<Appliance>().ToList();
                        break;
                    case "2":
                        Console.Write("Enter Battery Voltage Value Is. 18 V ( low) or 24 V (high): ");
                        int voltage = int.Parse(Console.ReadLine());
                        matchingAppliances = Appliances.OfType<Vacuum>().Where(v => v.BatteryVoltage == voltage).Cast<Appliance>().ToList();
                        break;
                    case "3":
                        Console.Write("room where the microwave will be Installed: K (Kitchen) or W (Work Site): ");
                        string roomType = Console.ReadLine().ToUpper();
                        matchingAppliances = Appliances.OfType<Microwave>().Where(m => m.RoomType == roomType).Cast<Appliance>().ToList();
                        break;
                    case "4":
                        Console.Write("enter the sound rating of the dishwasher: QT (Quietst), QR (Quieter), QU (Quiet) or M (Moderate): ");
                        string soundRating = Console.ReadLine().ToUpper();
                        matchingAppliances = Appliances.OfType<Dishwasher>().Where(d => d.SoundRating.ToUpper() == soundRating).Cast<Appliance>().ToList();
                        break;
                    default:
                        Console.WriteLine("INVALID.");
                        return;
                }

                if (matchingAppliances.Count == 0)
                {
                    Console.WriteLine("no appliances found.");
                }
                else
                {
                    Console.WriteLine("Matching Appliance:");
                    foreach (var appliance in matchingAppliances)
                    {
                        Console.WriteLine(appliance.ToString());
                        Console.WriteLine();
                    }
                }
            }
            public void SaveAppliancesToFile(string fileName)
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var appliance in Appliances)
                    {
                        writer.WriteLine(appliance.FormatForFile());
                    }
                }
                Console.WriteLine(" saved to the file. ");
            }
            public virtual void DisplayMenu()
            {
                while (true)
                {
                    Console.WriteLine("Welcome To Modern Appliances!");
                    Console.WriteLine("How May We Assist You?");
                    Console.WriteLine("1 – Check Out Appliance");
                    Console.WriteLine("2 – Find Appliances By Brand");
                    Console.WriteLine("3 – Display Appliances by Type");
                    Console.WriteLine("4 – Produce Random Appliance List");
                    Console.WriteLine("5 – Save & Exit");
                    Console.Write("Enter Option: ");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
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
                        case " 5":
                            SaveAppliancesToFile("appliances.txt");
                            return;
                        default:
                            Console.WriteLine("INDVALID");
                            break;
                    }

                    Console.WriteLine();
                }
            }








            public virtual void RandomList()
            {
                Console.Write("Enter number for the appliances: ");
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
                    Console.WriteLine("Enter Posotive Question.");
                }
            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_KomodoOutingsConsole
{
    class ProgramUI
    {
        public bool _keepRunning = true;
        public KomodoOutingsRepo _outingList = new KomodoOutingsRepo() { };
        public void Run()
        {
            SeedValues();

            while (_keepRunning)
            {
                DisplayMenu();
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\tKomodo Outings\n" +
                "================================================\n" +
                "Choose a menu item:\n" +
                "1. Display All Items\n" +
                "2. Add Events to List\n" +
                "3. Display Cost Calculations\n" +
                "4. Exit\n");

            GetResponse();
        }

        private void GetResponse()
        {
            Console.WriteLine("Enter a Number: ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        DisplayOutings();
                        ClearAfterKeypress();
                        break;
                    case 2:
                        Console.Clear();
                        AddEvents();
                        ClearAfterKeypress();
                        break;
                    case 3:
                        Console.Clear();
                        DisplayCosts();
                        ClearAfterKeypress();
                        break;
                    case 4:
                        _keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Choose a number between 1 and 4");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
        }

        private void ClearAfterKeypress()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private void DisplayOutings()
        {
            List<KomodoOutings> displayList = _outingList.ReadEvents();

            foreach(KomodoOutings Outing in displayList)
            {
                Console.WriteLine($"Outing Event: {Outing.TypeOfEvent}");
                Console.WriteLine($"Number of Employees: {Outing.NumberOfEmployees}");
                Console.WriteLine($"Event Date: {Outing.EventDate.ToShortDateString()}");
                Console.WriteLine($"Cost Per Person: {Outing.CostPerPeron}");
                Console.WriteLine($"Cost Per Person: {Outing.TotalCost}\n\n");
            }
        }

        private void AddEvents()
        {
            KomodoOutings Outing = new KomodoOutings();

            Outing.TypeOfEvent = DisplayTypeMenu();

            Console.Write("Enter the number of People that Attended: ");
            Outing.NumberOfEmployees = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Date for the Event: (month/day/year): ");
            string[] mystring = (Console.ReadLine().Split('/'));
            Outing.EventDate = new DateTime(Convert.ToInt32(mystring[2]),Convert.ToInt32(mystring[0]),Convert.ToInt32(mystring[1]));

            Console.Write("Total Cost Per Person: $");
            Outing.CostPerPeron = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Total Cost for Event: $");
            Outing.TotalCost = Convert.ToDecimal(Console.ReadLine());

            _outingList.AddEvent(Outing);
        }

        private EventType DisplayTypeMenu()
        {
            Console.Clear();
            Console.WriteLine("\tSelect Outing Type\n" +
                "================================================\n" +
                "Choose a menu item:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");

            return GetTypeResponse();
        }

        private EventType GetTypeResponse()
        {
            Console.WriteLine("Enter a Number: ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        return EventType.Golf;
                    case 2:
                        return EventType.Bowling;
                    case 3:
                        return EventType.Amusement_Park;
                    case 4:
                        return EventType.Concert;
                    default:
                        Console.WriteLine("Choose a number between 1 and 4");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
            return EventType.Concert;
        }

        private void DisplayCosts()
        {
            List<KomodoOutings> costList = _outingList.ReadEvents();
            
            decimal allOutings = 0.00m;
            Dictionary<string, decimal> costDict = new Dictionary<string, decimal>();
            costDict.Add("Golf", 0.00m);
            costDict.Add("Bowling", 0.00m);
            costDict.Add("Amusement_Park", 0.00m);
            costDict.Add("Concerts", 0.00m);

            foreach (KomodoOutings Outing in costList)
            {
                if (Outing.TypeOfEvent == EventType.Golf)
                    costDict["Golf"] += Outing.TotalCost;
                else if(Outing.TypeOfEvent == EventType.Bowling)
                    costDict["Bowling"] += Outing.TotalCost;
                else if (Outing.TypeOfEvent == EventType.Amusement_Park)
                    costDict["Amusement_Park"] += Outing.TotalCost;
                else if (Outing.TypeOfEvent == EventType.Concert)
                    costDict["Concerts"] += Outing.TotalCost;
            }

            allOutings = costDict["Golf"] + costDict["Bowling"] + costDict["Amusement_Park"] + costDict["Concerts"];

            Console.WriteLine($"Total Cost for All Outings: ${allOutings}");
            Console.WriteLine($"Total Cost for Golf: ${costDict["Golf"]}");
            Console.WriteLine($"Total Cost for Bowling: ${costDict["Bowling"]}");
            Console.WriteLine($"Total Cost for Amusement Parks: ${costDict["Amusement_Park"]}");
            Console.WriteLine($"Total Cost for Concerts: ${costDict["Concerts"]}");
        }

        private void SeedValues()
        {
            //Add values here
            _outingList.AddEvent(new KomodoOutings(EventType.Golf, 350, new DateTime(2020, 5, 18), 23.32m, 20000.00m));
            _outingList.AddEvent(new KomodoOutings(EventType.Bowling, 1000, new DateTime(2020, 7, 25), 10.50m, 10500.00m));
            _outingList.AddEvent(new KomodoOutings(EventType.Amusement_Park, 1800, new DateTime(2020, 6, 30), 55.00m, 35000.00m));
            _outingList.AddEvent(new KomodoOutings(EventType.Concert, 2000, new DateTime(2020, 8, 5), 22.50m, 44500.00m));
        }
    }
}

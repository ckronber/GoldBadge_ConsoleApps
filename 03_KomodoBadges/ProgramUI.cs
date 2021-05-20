using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_KomodoBadges
{
    public class ProgramUI
    {
        public bool _keepRunning = true;
        public BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            seedValues();

            while (_keepRunning)
            {
                DisplayMenu();
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\tKomodo Insurance Badges\n" +
                "================================================\n" +
                "Choose a menu item:\n" +
                "1. Add a Badge\n" +
                "2. Edit a Badge\n" +
                "3. List all Badges\n" +
                "4. Exit\n");

            GetResponse();
        }

        private void GetResponse()
        {
            Console.Write("Enter a Number: ");
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        AddBadge();
                        ClearAfterKeypress();
                        break;
                    case 2:
                        Console.Clear();
                        EditBadge();
                        ClearAfterKeypress();
                        break;
                    case 3:
                        Console.Clear();
                        ListBadges();
                        ClearAfterKeypress();
                        break;
                    case 4:
                        _keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Choose a number between 1 and 4");
                        Thread.Sleep(1000);
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
            Console.WriteLine("\n\nPress a key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private void AddBadge()
        {
            Badge myBadge = new Badge();

            ListBadges();

            Console.Write("\n\nEnter the Number on the Badge to Add: ");
            myBadge.BadgeID = Convert.ToInt32(Console.ReadLine());

            Console.Write("List the doors you need access to seperated by commas:");
            string[] Badges = Console.ReadLine().Split(',');

            List<string> BadgeList = Badges.ToList();
            myBadge.DoorNames = BadgeList;
            _badgeRepository.AddBadge(myBadge);
        }

        private void DisplayEditMenu()
        {
            Console.WriteLine("\n\n\tWhat would you like to do?\n" +
                "================================================\n" +
                "1. Remove a Door\n" +
                "2. Add a Door\n");
        }

        private void GetEditResponse(int Badge)
        {
            List<string> DoorAccess;
            int PreviousAccess = _badgeRepository.DisplayBadges()[Badge].Count;

            string Door;
            bool AddRemove = true;

            Console.Write("\nEnter a Number: ");

            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        //Remove a door
                        AddRemove = false;

                        Console.Write("Which door would you like to Remove: ");

                        Door = Console.ReadLine();
                        DoorAccess = _badgeRepository.UpdateBadgebyKey(Badge, Door, AddRemove);

                        if (DoorAccess.Count < PreviousAccess)
                            Console.WriteLine($"Door {Door} Removed from {Badge}\n");
                        else
                            Console.WriteLine($"Door {Door} Not Removed from {Badge}\n");
                       
                        break;
                    case 2:
                        //Add a door
                        AddRemove = true;

                        Console.Write("Which door would you like to Add: ");
                        Door = Console.ReadLine();
                        DoorAccess = _badgeRepository.UpdateBadgebyKey(Badge, Door, AddRemove);

                        if (DoorAccess.Count > PreviousAccess)
                            Console.WriteLine($"Door {Door} Added to {Badge}\n");
                        else
                            Console.WriteLine($"Door {Door} Not Added to {Badge}\n");

                        break;
                    default:
                        Console.WriteLine("Choose 1 or 2");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
        }

        private void EditBadge()
        {
            ListBadges();

            Console.WriteLine();
            Dictionary<int, List<string>> myDict = _badgeRepository.DisplayBadges(); // Needed for displaying Badges for door
            int BadgeNum;
            string DoorAccess = "";

            Console.Write("What is the number on the badge of doors to change: ");
            BadgeNum = Convert.ToInt32(Console.ReadLine());

            DoorAccess = AccessReturn(DoorAccess, myDict, BadgeNum);
          
            Console.WriteLine($"{BadgeNum} has acess to doors {DoorAccess}");

            DisplayEditMenu();
            GetEditResponse(BadgeNum);

            DoorAccess = "";
            DoorAccess = AccessReturn(DoorAccess, myDict, BadgeNum);
    
            Console.WriteLine($"{BadgeNum} has acess to doors {DoorAccess}");
            Thread.Sleep(2000);
        }

        private string AccessReturn(string doors,Dictionary<int,List<string>> dict,int badge)
        {
            foreach (string door in dict[badge])
            {
                if (door != dict[badge].Last())
                    doors += door + ", ";
                else
                    doors += door;
            }

            return doors;
        }

        private void ListBadges()
        {
            //list all badges view
            Dictionary<int, List<string>> myDict = _badgeRepository.DisplayBadges();

            Console.WriteLine("Current Badges with attached Door Access\n\n");

            Console.WriteLine("{0,-10}{1,-10}", "Badge #", "Door Access");
            Console.WriteLine("{0,-10}{1,-10}", "========", "===========");
            for (int i = 0; i < myDict.Count; i++)
            {
                string Values = "";
                foreach (string mystring in myDict[myDict.Keys.ElementAt(i)])
                {
                    if (myDict[myDict.Keys.ElementAt(i)].Last() == mystring)
                        Values += mystring;
                    else
                        Values += mystring + ", ";
                }
                Console.WriteLine("{0,-10}{1,-10}", myDict.Keys.ElementAt(i), Values);
            }
        }

        private void seedValues()
        {
            _badgeRepository.AddBadge(new Badge(12345, new List<string>() { "A7", "B4" }));
            _badgeRepository.AddBadge(new Badge(22345, new List<string>() { "A1", "A4", "B1", "B2" }));
            _badgeRepository.AddBadge(new Badge(32345, new List<string>() { "A4", "A5" }));
        }
    }
}

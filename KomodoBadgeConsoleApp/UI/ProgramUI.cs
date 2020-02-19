using KomodoBadgeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoBadgeClasses.Badge;

namespace KomodoBadgeConsoleApp.UI
{
    public class ProgramUI
    {
        private bool _exitMenu = false;
        private bool _exitAddPage = false;
        private int _userInput;
        BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            while (!_exitMenu)
            {
                RunMenu();
            }
        }

        public void RunMenu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. View all badges\n" +
                "4. Exit");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        while (!_exitAddPage)
                        {
                            AddBadge();
                        }
                        break;
                    case 2:
                        EditBadge();
                        break;
                    case 3:
                        ViewAllBadges();
                        break;
                    case 4:
                        _exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid option.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
        }

        public void AddBadge()
        {
            Badge newBadge = new Badge();
            Console.Clear();
            bool badgeNumberConfirmed = false;
            while (!badgeNumberConfirmed)
            {


                Console.WriteLine("Enter the number of the badge you would like to add:");
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    if (!_badgeRepository.CheckIfBadgeExists(_userInput))
                    {
                        newBadge.BadgeId = _userInput;
                        badgeNumberConfirmed = true;

                    }
                    else
                    {
                        Console.WriteLine("This badge number already exists.\n" +
                            "Press any key to enter a different badge number.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }

            }

            Doors door = new Doors();

            bool doorsConfirmed = false;
            while (!doorsConfirmed)
            {
                bool doorConfirmed = false;
                while (!doorConfirmed)
                {
                    Console.WriteLine("Enter a door that it needs access to:");
                    if (Enum.TryParse(Console.ReadLine(), out door))
                    {
                        newBadge.AddDoor(door);
                        doorConfirmed = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid door option.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                    }
                    bool doorParsed = false;
                    while (!doorParsed)
                    {
                        Console.Clear();
                        Console.WriteLine("Would you like to add another door?\n" +
                            "1. Yes\n" +
                            "2. No\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            switch (_userInput)
                            {
                                case 1:
                                    doorParsed = true;
                                    break;
                                case 2:
                                    doorParsed = true;
                                    doorsConfirmed = true;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid response.\n" +
                                        "Press any key to try again.");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                        }
                    }
                }
            }
            _badgeRepository.AddBadgeToDictionary(newBadge);
            Console.Clear();
            bool doorsParsed = false;
            while (!doorsParsed)
            {
                Console.WriteLine("Would you like to add another badge?\n" +
                    "1. Yes\n" +
                    "2. No");
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    switch (_userInput)
                    {
                        case 1:
                            doorsParsed = true;
                            break;
                        case 2:
                            doorsParsed = true;
                            _exitAddPage = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                }
            }

        }


        public void EditBadge()
        {
            Console.WriteLine("What badge number would you like to update?");

            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                if (_badgeRepository.CheckIfBadgeExists(_userInput))
                {
                    List<Doors> doors = _badgeRepository.GetDoorsByBadgeId(_userInput);
                    Console.Write($"{_userInput} has access to: ");
                    foreach(Doors door in doors)
                    {
                        Console.Write($"{door} ");
                    }
                    Console.Write("\n");
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Add a door\n" +
                        "2. Remove a door\n");
                    if(Int32.TryParse(Console.ReadLine(), out _userInput))
                    {
                        switch (_userInput)
                        {
                            case 1:
                                Doors addDoor = new Doors();
                                Console.WriteLine("What door would you like to add?");
                                if(Enum.TryParse(Console.ReadLine(), out addDoor))
                                {
                                    doors.Add(addDoor);
                                    _badgeRepository.RemoveBadge(_userInput);
                                    Badge newBadge = new Badge();
                                    newBadge.BadgeId = _userInput;
                                    foreach (Doors door in doors)
                                    {
                                        newBadge.AddDoor(door);
                                    }
                                    _badgeRepository.AddBadgeToDictionary(newBadge);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid door\n" +
                                        "Press any key to try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                Doors removeDoor = new Doors();
                                Console.WriteLine("What door would you like to remove?");
                                if (Enum.TryParse(Console.ReadLine(), out removeDoor))
                                {
                                    doors.Remove(removeDoor);
                                    _badgeRepository.RemoveBadge(_userInput);
                                    Badge newBadge = new Badge();
                                    newBadge.BadgeId = _userInput;
                                    foreach (Doors door in doors)
                                    {
                                        newBadge.AddDoor(door);
                                    }
                                    _badgeRepository.AddBadgeToDictionary(newBadge);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid door\n" +
                                        "Press any key to try again.");
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                Console.WriteLine("Please enter a valid reponse\n" +
                                    "Press any key to try again");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("That badge does not exist.\n" +
                        "Press any key to enter different badge ID.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid badge number.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
        }

        public void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<Doors>> dictionary = _badgeRepository.ReturnDictionary();
            List<int> keys = dictionary.Keys.ToList(); 
            foreach (int key in keys)
            {
                List<Doors> doors = dictionary[key];
                Console.Write($"{key}: ");
                foreach (Doors door in doors)
                {
                    Console.Write($"{door} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public void SeedContent()
        {
            Doors doorAOne = Doors.A1;
            Doors doorBOne = Doors.B1;
            Doors doorAThree = Doors.A3;
            Badge badgeOne = new Badge(101);
            badgeOne.AddDoor(doorAOne);
            Badge badgeTwo = new Badge(102);
            badgeTwo.AddDoor(doorBOne);
            badgeTwo.AddDoor(doorAOne);
            Badge badgeThree = new Badge(103);
            badgeThree.AddDoor(doorAThree);
            badgeThree.AddDoor(doorAOne);
            badgeThree.AddDoor(doorBOne);

            _badgeRepository.AddBadgeToDictionary(badgeOne);
            _badgeRepository.AddBadgeToDictionary(badgeThree);
            _badgeRepository.AddBadgeToDictionary(badgeTwo);
            ;
        }

    }
}

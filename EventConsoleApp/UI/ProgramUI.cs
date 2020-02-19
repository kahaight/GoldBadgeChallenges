using EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleApp.UI
{
    class ProgramUI
    {
        private int _userInput;
        private bool _exitMenu;
        private bool _exitAccessCalculations;
        private EventRepository _eventRepository = new EventRepository();
        public void Run()
        {
            SeedContent();
            _exitMenu = false;
            while (!_exitMenu)
            {
                RunMenu();
            }
        }

        public void RunMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n" +
                "1. View all outings\n" +
                "2. Add an outing\n" +
                "3. Access Calculations\n" +
                "4. Exit");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        ViewAllOutings();
                        break;
                    case 2:
                        AddOutingToList();
                        break;
                    case 3:
                        _exitAccessCalculations = false;
                        while (!_exitAccessCalculations)
                        {
                            Console.Clear();
                        AccessCalculations();
                        }
                        break;
                    case 4:
                        _exitMenu = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("clean later");
            }

        }
        public void SeedContent()
        {
            Event outingOne = new Event("Golf", 20, new DateTime(2020, 2, 14), 20.5m);
            _eventRepository.AddEventToList(outingOne);
            Event outingTwo = new Event("Golf", 20, new DateTime(2020, 2, 15), 20.5m);
            _eventRepository.AddEventToList(outingTwo);
            Event outingThree = new Event("Bowling", 20, new DateTime(2020, 2, 16), 20.5m);
            _eventRepository.AddEventToList(outingThree);
            Event outingFour = new Event("Bowling", 20, new DateTime(2020, 2, 17), 20.5m);
            _eventRepository.AddEventToList(outingFour);
            Event outingFive = new Event("Movies", 20, new DateTime(2020, 2, 18), 10.5m);
            _eventRepository.AddEventToList(outingFive);
            Event outingSix = new Event("Movies", 20, new DateTime(2020, 2, 19), 10.5m);
            _eventRepository.AddEventToList(outingSix);
        }
        public void ViewAllOutings()
        {
            Console.Clear();
            List<Event> events = _eventRepository.GetEventList();
            foreach (Event outing in events)
            {
                Console.WriteLine($"{outing.EventType} on {outing.EventDate.ToString("yyyy-MM-dd")}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        public void AddOutingToList()
        {
            Event newEvent = new Event();
            Console.WriteLine("Enter the type of outing:");
            newEvent.EventType = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter the number of attendees:");
            newEvent.NumberOfAttendees = Int32.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Enter the year of the event:");
            int year = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month of the event:");
            int month = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day of the event:");
            int day = Int32.Parse(Console.ReadLine());
            newEvent.EventDate = new DateTime(year, month, day);
            Console.Clear();
            Console.WriteLine("Enter the per person cost:");
            decimal cost = Decimal.Parse(Console.ReadLine());
            newEvent.CostPerPerson = cost;
            _eventRepository.AddEventToList(newEvent);
        }
        public void AccessCalculations()
        {
            Console.WriteLine("What would you like to see?\n" +
                "1. Cost of events by type of event.\n" +
                "2. Cost of all events\n" +
                "3. Return to menu");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        CostOfEachEventType();
                        break;
                    case 2:
                        CostOfAllEvents();
                        break;
                    case 3:
                        _exitAccessCalculations = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("clean later");
            }
        }
        public void CostOfAllEvents()
        {
            Console.Clear();
            decimal cost = _eventRepository.CalculateCostOfAllEvents();
            Console.WriteLine($"The cost of all events was ${cost}.\n" +
                $"Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void CostOfEachEventType()
        {
            Console.Clear();
            List<Event> events = _eventRepository.GetEventList();
            HashSet<string> eventTypes = new HashSet<string>();
            foreach (Event outing in events) { eventTypes.Add(outing.EventType); }
            foreach(string eventType in eventTypes) { Console.WriteLine($"{eventType}: ${_eventRepository.CalculateCostsByEventType(eventType)}"); }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

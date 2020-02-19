using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventClasses
{
    public class EventRepository
    {
        protected readonly List<Event> _events = new List<Event>();

        public List<Event> GetEventList()
        {
            return _events;
        }

        public void AddEventToList(Event eventOne)
        {
            _events.Add(eventOne);
        }

        public decimal CalculateCostOfAllEvents()
        {
            decimal cost = 0;
            foreach (Event outing in _events)
            {
                cost = cost + outing.TotalCost;
            }
            return cost;
        }

        public decimal CalculateCostsByEventType(string eventType)
        {
            decimal cost = 0;
            foreach (Event outing in _events)
            {
                if(outing.EventType.ToLower() == eventType.ToLower())
                {
                    cost = cost + outing.TotalCost;
                }
            }
            return cost;
        }
    }
}

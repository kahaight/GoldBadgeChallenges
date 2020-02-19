using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventClasses
{
    public class Event
    {
        public Event() { }

        public Event(string eventType, int attendees, DateTime eventDate, decimal costPerPerson)
        {
            EventType = eventType;
            NumberOfAttendees = attendees;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
        }
        public string EventType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost
        {
            get
            {
                return CostPerPerson * NumberOfAttendees;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeClasses
{
    public class Badge
    {
        public enum Doors { A1, A2, A3, B1, B2, B3}
        private List<Doors> _doors = new List<Doors>();

        public Badge() { }

        public Badge(int badgeId)
        {
            BadgeId = badgeId;
        }

        public int BadgeId { get; set; }
        public List<Doors> AccessibleDoors { get 
            {
                return _doors;
            } 
        }

        public void AddDoor(Doors door)
        {
            _doors.Add(door);
        }

        public void RemoveDoor(Doors door)
        {
            _doors.Remove(door);
        }

    }
}

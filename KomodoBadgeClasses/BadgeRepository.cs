using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoBadgeClasses.Badge;

namespace KomodoBadgeClasses
{
    public class BadgeRepository
    {
        protected readonly Dictionary<int, List<Doors>> _badgeDictionary = new Dictionary<int, List<Doors>>();

        public void AddBadgeToDictionary(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeId, badge.AccessibleDoors);
        }
        public List<Doors> GetDoorsByBadgeId(int badgeId)
        {
            if (_badgeDictionary.TryGetValue(badgeId, out List<Doors> doors))
            {
                return doors;
            }

            else
                return null;
        }

        public bool CheckIfBadgeExists(int badgeId)
        {
            return _badgeDictionary.ContainsKey(badgeId);
        }

        public void RemoveBadge(int badgeId)
        {
            _badgeDictionary.Remove(badgeId);
        }

        public Dictionary<int, List<Doors>> ReturnDictionary()
        {
            return _badgeDictionary;
        }

    }
}

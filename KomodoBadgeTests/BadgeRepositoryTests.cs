using System;
using System.Collections.Generic;
using KomodoBadgeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KomodoBadgeClasses.Badge;

namespace KomodoBadgeTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void AddBadgeToRepository()
        {
            BadgeRepository repository = new BadgeRepository();
            Dictionary<int, List<Doors>> dictionary = repository.ReturnDictionary();
            int x = dictionary.Count;
            Badge newBadge = new Badge(101);
            repository.AddBadgeToDictionary(newBadge);
            Assert.AreEqual(x + 1, dictionary.Count);

        }
        [TestMethod]
        public void GetDoorsByBadgeId()
        {
            BadgeRepository repository = new BadgeRepository();
            Dictionary<int, List<Doors>> dictionary = repository.ReturnDictionary();
            Badge newBadge = new Badge(101);
            List<Doors> doors = new List<Doors>();
            repository.AddBadgeToDictionary(newBadge);
            Assert.IsTrue(doors.GetType() == repository.GetDoorsByBadgeId(101).GetType());

        }
        [TestMethod]
        public void CheckIfBadgeExists()
        {
            BadgeRepository repository = new BadgeRepository();
            Dictionary<int, List<Doors>> dictionary = repository.ReturnDictionary();
            Badge newBadge = new Badge(101);
            List<Doors> doors = new List<Doors>();
            repository.AddBadgeToDictionary(newBadge);
            Assert.IsTrue(repository.CheckIfBadgeExists(101));
        }
        [TestMethod]
        public void RemoveBadgeFromRepository()
        {
            BadgeRepository repository = new BadgeRepository();
            Dictionary<int, List<Doors>> dictionary = repository.ReturnDictionary();
            Badge newBadge = new Badge(101);
            repository.AddBadgeToDictionary(newBadge);
            int x = dictionary.Count;
            repository.RemoveBadge(101);
            Assert.AreEqual(x - 1, dictionary.Count);

        }
    }
}

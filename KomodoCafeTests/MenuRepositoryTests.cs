using System;
using System.Collections.Generic;
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void AddItemToMenu_ShouldAddItem()
        {
            Menu numberOne = new Menu();
            MenuRepository menu = new MenuRepository();
            bool isAdded = menu.AddItemToMenu(numberOne);
            Assert.IsTrue(isAdded);
        }
        [TestMethod]
        public void RemoveMenuItemByMealNumber_ShouldRemoveItem()
        {
            List<string> ingredients = new List<string>();
            Menu numberOne = new Menu(1, "Number One", "Number One", ingredients, 5.99m);
            MenuRepository menu = new MenuRepository();
            menu.AddItemToMenu(numberOne);
            bool isRemoved = menu.RemoveMenuItemByMealNumber(1);
            Assert.IsTrue(isRemoved);
        }
        [TestMethod]
        public void GetAllMenuItems_ShouldReturnList()
        {
            List<string> ingredients = new List<string>();
            MenuRepository menu = new MenuRepository();
            Menu numberOne = new Menu(1, "Number One", "Number One", ingredients, 5.99m);
            menu.AddItemToMenu(numberOne);
            Menu numberTwo = new Menu(2, "Number Two", "Number Two", ingredients, 5.99m);
            menu.AddItemToMenu(numberOne);
            List<Menu> newList = new List<Menu>();

            var menuOne = menu.GetAllMenuItems();
            Assert.IsTrue(menuOne.GetType() == newList.GetType());
        }
    }
}

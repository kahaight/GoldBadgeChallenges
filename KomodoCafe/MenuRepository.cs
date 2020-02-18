using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepository
    {
        private List<Menu> _menu = new List<Menu>();
        public bool AddItemToMenu(Menu menuItem)
        {
            int directoryLength = _menu.Count();
            _menu.Add(menuItem);
            bool wasAdded = directoryLength + 1 == _menu.Count();
            return wasAdded;
        }
        public List<Menu> GetAllMenuItems()
        {
            return _menu;
        }
        public bool RemoveMenuItemByMealNumber(int mealNumber)
        {
            bool deletedResult = false;
            foreach (Menu menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    deletedResult = _menu.Remove(menuItem);
                    return deletedResult;
                }
            }
            return deletedResult;
        }
    }
}

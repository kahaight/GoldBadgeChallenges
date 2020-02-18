using KomodoCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsole.UI
{
    public class ProgramUI
    {
        private int _userInput;
        private string _userStringInput;
        private bool _closeMenu = false;
        MenuRepository _menu = new MenuRepository();
        private bool _userInputConfirmed;
        private decimal _userPriceInput;

        public void Run()
        {
            SeedContent();
            while (!_closeMenu)
            {
                RunMenu();
            }
        }
        public void RunMenu()
        {
            Console.WriteLine("Welcome to your menu app, what would you like to do?\n" +
                "1.) View all menu items\n" +
                "2.) Add a menu item\n" +
                "3.) Delete a menu item\n" +
                "4.) Exit");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                Console.Clear();

                switch (_userInput)
                {
                    case 1:
                        ViewAllMenuItems();
                        break;
                    case 2:
                        AddMenuItem();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        _closeMenu = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid response.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void SeedContent()
        {
            List<string> ingredients = new List<string>();
            Menu numberOne = new Menu(1, "Hamburger Combo", "Hamburger, Medium Fries, Medium Drink", ingredients, 5.99m);
            _menu.AddItemToMenu(numberOne);
            Menu numberTwo = new Menu(2, "CheeseBurger Combo", "Cheeseburger, Medium Fries, Medium Drink", ingredients, 6.99m);
            _menu.AddItemToMenu(numberTwo);
            Menu numberThree = new Menu(3, "Chicken Sandwich Combo", "Chicken Sandwich, Medium Fries, Medium Drink", ingredients, 6.99m);
            _menu.AddItemToMenu(numberThree);
        }
        public void ViewAllMenuItems()
        {
            List<Menu> menuItems = _menu.GetAllMenuItems();
            foreach (Menu menuItem in menuItems)
            {
                Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n" +
                    $"Meal Name: {menuItem.MealName}\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void AddMenuItem()
        {
            Menu menuItem = new Menu();
            bool parsed = false;
            while (!parsed)
            {
                Console.WriteLine("Enter the meal number:");
                //parsed = Int32.TryParse(Console.ReadLine(), out number);
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    menuItem.MealNumber = _userInput;
                    parsed = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
            parsed = false;
            while (!parsed)
            {
                Console.Clear();
                Console.WriteLine("Enter the meal name:");
                _userStringInput = Console.ReadLine();
                bool confirmed = false;
                while (!confirmed)
                {
                Console.WriteLine($"You entered {_userStringInput}.\n" +
                    $"Confirm meal name?\n" +
                    $"1.) Yes\n" +
                    $"2.) No\n");
                    if (Int32.TryParse(Console.ReadLine(), out _userInput))
                    {
                        switch (_userInput)
                        {
                            case 1:
                                menuItem.MealName = _userStringInput;
                                parsed = true;
                                confirmed = true;
                                Console.Clear();
                                break;

                            case 2:
                                Console.WriteLine("Press any key to re-enter the meal name");
                                confirmed = true;
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            parsed = false;
            while (!parsed)
            {
                Console.Clear();
                Console.WriteLine("Enter the meal description:");
                _userStringInput = Console.ReadLine();

                bool confirmed = false;
                while (!confirmed)
                {
                Console.WriteLine($"You entered {_userStringInput}.\n" +
                    $"Confirm meal name?\n" +
                    $"1.) Yes\n" +
                    $"2.) No\n");
                    if (Int32.TryParse(Console.ReadLine(), out _userInput))
                    {
                        switch (_userInput)
                        {
                            case 1:
                                menuItem.MealName = _userStringInput;
                                parsed = true;
                                confirmed = true;
                                Console.Clear();
                                break;

                            case 2:
                                Console.WriteLine("Press any key to re-enter the meal description");
                                Console.ReadKey();
                                confirmed = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Please enter a valid response.\n" +
                                    "Press any key to try again.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response.\n" +
                                    "Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            List<string> ingredients = new List<string>();
            bool ingredientsConfirmed = false;
            while (!ingredientsConfirmed)
            {
                bool ingredientConfirmed = false;
                while (!ingredientConfirmed)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the ingredient:");
                    _userStringInput = Console.ReadLine();
                    Console.WriteLine($"You entered {_userStringInput}.\n" +
                        $"Confirm ingredient?\n" +
                        $"1.) Yes\n" +
                        $"2.) No\n");
                    _userInput = Int32.Parse(Console.ReadLine());
                    switch (_userInput)
                    {
                        case 1:
                            ingredients.Add(_userStringInput);
                            ingredientConfirmed = true;
                            break;
                        case 2:
                            Console.WriteLine("Press any key to re-enter the ingredient");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid response, Please re-enter the ingredient.\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
                _userInputConfirmed = false;
                while (!_userInputConfirmed)
                {
                    Console.WriteLine($"Are you done entering ingredients?\n" +
                        $"1.) Yes\n" +
                        $"2.) No\n");
                    _userInput = Int32.Parse(Console.ReadLine());
                    switch (_userInput)
                    {
                        case 1:
                            ingredientsConfirmed = true;
                            _userInputConfirmed = true;
                            menuItem.Ingredients = ingredients;
                            break;
                        case 2:
                            Console.WriteLine("Press any key to enter another ingredient");
                            _userInputConfirmed = true;
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid response.\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            bool priceConfirmed = false;
            _userInputConfirmed = false;
            while (!priceConfirmed)
            {
                Console.WriteLine($"Please enter the price of the menu item:\n");
                _userPriceInput = Convert.ToDecimal(Console.ReadLine());

                while (!_userInputConfirmed)
                {

                    Console.WriteLine($"Are you?\n" +
                                        $"1.) Yes\n" +
                                        $"2.) No\n");
                    _userInput = Int32.Parse(Console.ReadLine());
                    switch (_userPriceInput)
                    {
                        case 1:
                            priceConfirmed = true;
                            _userInputConfirmed = true;
                            menuItem.MealPrice = _userPriceInput;
                            break;
                        case 2:
                            Console.WriteLine("Press any key to re-enter the price");
                            _userInputConfirmed = true;
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid response.\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
        public void RemoveMenuItem()
        {
            Console.WriteLine("Enter the meal number of the menu item you would like to removed");
            _userInput = Int32.Parse(Console.ReadLine());
            _menu.RemoveMenuItemByMealNumber(_userInput);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2._2
{
    class Store
    {
        private MenuCatalog menuCatalog = new MenuCatalog();
        public void AddPizzaToMenu(Pizza pizza)
        {
            menuCatalog.AddPizza(pizza);
        }

        public void DeletePizzaFromMenu(string pizzaName)
        {
            menuCatalog.DeletePizza(pizzaName);
        }

        public void UpdatePizzaOnMenu(string pizzaName, Pizza updatedPizza)
        {
            menuCatalog.UpdatePizza(pizzaName, updatedPizza);
        }


        public void TestSystem()
        {
            // Adding some pizzas to the menu
            menuCatalog.AddPizza(new Pizza { Name = "Margherita", Description = "Classic tomato, mozzarella, and basil", Price = 8.99m });
            menuCatalog.AddPizza(new Pizza { Name = "Pepperoni", Description = "Tomato sauce, pepperoni, and mozzarella", Price = 10.99m });

            // Testing CRUD operations
            Console.WriteLine("Initial Menu:");
            menuCatalog.PrintMenu();

            // Update pizza
            menuCatalog.UpdatePizza("Margherita", new Pizza { Name = "Margherita Supreme", Description = "Classic tomato, mozzarella, basil, and extra toppings", Price = 11.99m });
            Console.WriteLine("\nMenu after updating Margherita:");
            menuCatalog.PrintMenu();

            // Delete pizza
            menuCatalog.DeletePizza("Pepperoni");
            Console.WriteLine("\nMenu after deleting Pepperoni:");
            menuCatalog.PrintMenu();

            // Search pizza
            var searchResult = menuCatalog.SearchPizza("Supreme");
            if (searchResult != null)
            {
                Console.WriteLine($"\nSearch result: {searchResult.Name} - {searchResult.Description} - ${searchResult.Price}");
            }
            else
            {
                Console.WriteLine("\nPizza not found.");
            }

            // Display menu
            Console.WriteLine("\nFinal Menu:");
            menuCatalog.PrintMenu();
        }

        public int MenuChoice(List<string> menuItems)
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }

            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= menuItems.Count)
                    {
                        return choice;
                    }
                }
                Console.WriteLine("Invalid choice. Please enter a number from the menu.");
            }
        }
    }
}

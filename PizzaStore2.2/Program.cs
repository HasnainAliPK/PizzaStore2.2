using static System.Formats.Asn1.AsnWriter;

namespace PizzaStore2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> menuItems = new List<string> {
            "Add new pizza to the menu",
            "Delete pizza",
            "Update pizza",
            "Search pizza",
            "Display pizza menu",
            "Exit"
        };

            while (true)
            {
                int choice = Store.MenuChoice(menuItems);
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the name of the pizza: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the description of the pizza: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter the price of the pizza: ");
                        decimal price;
                        while (!decimal.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                        }
                        Store.menuCatalog.AddPizza(new Pizza { Name = name, Description = description, Price = price });
                        break;
                    case 2:
                        Console.Write("Enter the name of the pizza to delete: ");
                        string deleteName = Console.ReadLine();
                        Store.menuCatalog.DeletePizza(deleteName);
                        break;
                    case 3:
                        Console.Write("Enter the name of the pizza to update: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Enter the new description of the pizza: ");
                        string updateDescription = Console.ReadLine();
                        Console.Write("Enter the new price of the pizza: ");
                        decimal updatePrice;
                        while (!decimal.TryParse(Console.ReadLine(), out updatePrice))
                        {
                            Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                        }
                        Store.menuCatalog.UpdatePizza(updateName, new Pizza { Name = updateName, Description = updateDescription, Price = updatePrice });
                        break;
                    case 4:
                        Console.Write("Enter criteria to search pizza: ");
                        string searchCriteria = Console.ReadLine();
                        Pizza searchResult = Store.menuCatalog.SearchPizza(searchCriteria);
                        if (searchResult != null)
                        {
                            Console.WriteLine($"Found pizza: {searchResult.Name} - {searchResult.Description} - ${searchResult.Price}");
                        }
                        else
                        {
                            Console.WriteLine("Pizza not found.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Menu:");
                        Store.menuCatalog.PrintMenu();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program.");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

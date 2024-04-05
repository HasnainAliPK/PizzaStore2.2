using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2._2
{
    class MenuCatalog
    {
        private List<Pizza> pizzas = new List<Pizza>();

        public void AddPizza(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void DeletePizza(string pizzaName)
        {
            pizzas.RemoveAll(p => p.Name == pizzaName);
        }

        public void UpdatePizza(string pizzaName, Pizza updatedPizza)
        {
            var index = pizzas.FindIndex(p => p.Name == pizzaName);
            if (index != -1)
            {
                pizzas[index] = updatedPizza;
            }
        }

        public Pizza SearchPizza(string criteria)
        {
            return pizzas.Find(p => p.Name.ToLower().Contains(criteria.ToLower()) || p.Description.ToLower().Contains(criteria.ToLower()));
        }

        public void PrintMenu()
        {
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"{pizza.Name} - {pizza.Description} - ${pizza.Price}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    // Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими
    // продукции. 

    [Flags]
    public enum OrderedFood
    {
        None = 0,
        Entree = 1,
        Appetizer = 2,
        Side = 4,
        Dessert = 8,
        Beverage = 16,
        BarBeverage = 32
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var order1 = OrderedFood.Appetizer | OrderedFood.Entree | OrderedFood.Beverage | OrderedFood.Dessert;
            var order2 = OrderedFood.Entree | OrderedFood.Beverage;
            var order3 = OrderedFood.Appetizer | OrderedFood.Entree;

            var customer1 = new Customer("Harry", "Potter");
            var customer2 = new Customer("Arthur", "Weasley");
            var customer3 = new Customer("Albus", "Dumbledore");

            var orders = new Dictionary<Customer, OrderedFood>();
            orders.Add(customer1, order1);
            orders.Add(customer2, order2);
            orders.Add(customer3, order3);

            // Из коллекции можно получать категории товаров, которые купил покупатель или по категории определить покупателей.

            var orderedFood = orders[customer2];
            Console.WriteLine(orderedFood);

            Console.WriteLine(new string('-', 30));

            foreach (var order in orders)
            {
                if (order.Value.HasFlag(OrderedFood.Appetizer))
                {
                    Console.WriteLine($"{order.Key.FirstName} {order.Key.LastName}");
                }
            }

            Console.ReadKey();
        }
    }
}

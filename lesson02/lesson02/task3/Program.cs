using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    // Несколькими способами создайте коллекцию, в которой можно хранить только целочисленные и
    // вещественные значения, по типу «счет предприятия – доступная сумма» соответственно.
    class Program
    {
        static void Main(string[] args)
        {
            var accountsOfType1 = new Dictionary<int, double>();
            accountsOfType1.Add(111111, 100.4);

            var accountsOfType2 = new SortedList<int, double>();
            accountsOfType2.Add(22222, 100d);

            var accountsOfType3 = new SortedDictionary<int, double>();
            accountsOfType3.Add(333, 1000d);
            accountsOfType3.Add(33333, 1.1);

            foreach (var account in accountsOfType3)
            {
                Console.WriteLine($"{account.Key}\t: {account.Value}\tavailable");
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Используя класс SortedList, создайте небольшую коллекцию и выведите на экран значения пар
    // «ключ- значение» сначала в алфавитном порядке, а затем в обратном.
    class Program
    {
        static void Main(string[] args)
        {
            var spanglish = new SortedList();

            spanglish.Add("cero", "zero");
            spanglish.Add("uno", "one");
            spanglish.Add("dos", "two");
            spanglish.Add("tres", "three");
            spanglish.Add("cuatro", "four");

            PrintAllEntries(spanglish);

            Console.WriteLine(new string('-', 30));

            PrintAllEntries(new SortedList(spanglish, new DescendingComparer()));

            Console.ReadKey();
        }

        private static void PrintAllEntries(SortedList sortedList)
        {
            foreach (DictionaryEntry de in sortedList)
            {
                Console.WriteLine($"{de.Key} - {de.Value}");
            }
        }
    }

    public class DescendingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Comparer comparer = new Comparer(CultureInfo.InvariantCulture);
            return comparer.Compare(y, x);
        }
    }
}

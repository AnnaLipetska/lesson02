using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    // Создайте коллекцию типа OrderedDictionary и реализуйте в ней возможность сравнения значений ключей.
    class Program
    {
        static void Main(string[] args)
        {
            var diary = new OrderedDictionary(new DiaryEntryComparer());

            var entry1 = new DiaryEntry(1, Status.SelectedForDevelopment);
            var entry2 = new DiaryEntry(2, Status.InProgress);
            var entry3 = new DiaryEntry(1, Status.ReadyForRelease);

            diary.Add(entry1, "easy");
            diary.Add(entry2, "difficult");

            try
            {
                diary.Add(entry3, "hard and heavy");
            }
            catch (Exception)
            {
                Console.WriteLine("Такой id уже существует, запись не добавлена");
            }

            Console.WriteLine($"Всего в журнале записей: {diary.Count}");

            Console.ReadKey();
        }
    }

    public class DiaryEntry
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        public DiaryEntry(int id, Status status)
        {
            Id = id;
            Status = status;
        }
    }

    public enum Status
    {
        ReadyForRelease,
        CodeReview,
        InTesting,
        WaitingForSupport,
        OnAgreement,
        SelectedForDevelopment,
        InProgress,
        ReadyForMerge
    }

    class DiaryEntryComparer : IEqualityComparer
    {
        public new bool Equals(object a, object b)
        {
            var firstEntry = a as DiaryEntry;
            var secondEntry = b as DiaryEntry;
            return firstEntry.Id == secondEntry.Id;
        }

        public int GetHashCode(object obj)
        {
            return (obj as DiaryEntry).Id;
        }
    }
}

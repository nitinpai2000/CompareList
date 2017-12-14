using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListComparer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person> { new Person { Name = "Nitin", Age = 25 }, new Person { Name = "Pai", Age=26 } };
            List<Person> persons2 = new List<Person> { new Person { Name = "Nitin1", Age = 25 } , new Person { Name = "Pai", Age = 23 } };

            var comparer = new ListComparer<Person>(persons,persons2);
            var added = comparer.GetAddedItems();
            var deleted = comparer.GetDeletedItems(persons, persons2);
            var updated = comparer.GetUpdatedItems();

            System.Console.WriteLine(added.FirstOrDefault().Name);
            System.Console.WriteLine(updated.FirstOrDefault().Name);
            System.Console.WriteLine(deleted.FirstOrDefault().Name);
        }
    }

    public class Person : IComparableItem<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string GetKeysToFindAddedItems()
        {
            return Name;
        }

        public string GetKeysToFindDeletedItems()
        {
            return Name;
        }

        public string GetKeysToFindUpdatedItems()
        {
            return string.Format("{0}{1}",Name,Age);
        }
    }

    

    

}

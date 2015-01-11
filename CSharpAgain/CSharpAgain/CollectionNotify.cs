using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharpAgain
{
    class Person
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "First Name: " + FirstName + "\tLast Name: " + LastName + "\tAge: " + Age;
        }
    }
    class CollectionNotify
    {
        static void Main(string[] args)
        {
            ObservableCollection<Person> person = new ObservableCollection<Person>
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };

            person.CollectionChanged += person_CollectionChanged;

            person.Add(new Person { FirstName = "Fred", LastName = "Smith", Age = 26 });
            person.RemoveAt(0);
        }

        static void person_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action for this event: {0}", e.Action);
            
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
            //throw new NotImplementedException();
        }
    }
}

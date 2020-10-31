using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        //This pattern is used for the inter-object hierarchy and to reach these objects whenever we want.
        //The roles in an institution can have a tree structure.
        static void Main(string[] args)
        {
           
            
            Employee engin=new Employee{Name = "engin"};
            Employee salih = new Employee { Name = "salih" };
            engin.AddSubordinate(salih);
            Employee derin = new Employee { Name = "Derin" };
            derin.AddSubordinate(engin);
            Constractor ali = new Constractor { Name = "ali" };
            derin.AddSubordinate(ali);

            //Such an addition is made to establish hierarchy among employees.
            foreach (var person in derin)
            {
                Console.WriteLine(person.Name);
                foreach (var person1 in engin)
                {
                    Console.WriteLine(person1.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        public string Name { get; set; }
    }

    class Constractor:IPerson
    {

        public string Name { get; set; }
    }
    //We use IEnumerable, where we can use the Foreach function to navigate the hierarchical structure.
    class Employee :IPerson,IEnumerable<IPerson> 
    {
        private List<IPerson> _subordinates=new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;

namespace Prototype
{
    class Program
    {
        //Our aim in prototype design is to minimize object production costs.
        static void Main(string[] args)
        {
            Customer customer=new Customer();
            customer.FirstName = "Engin";
            customer.LastName = "Demirog";
            customer.City = "Ankara";
            customer.Id = 1;


           

            Customer customer2 = (Customer) customer.Clone();
            customer2.FirstName = "salih";
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer2.FirstName);
            //Cloning allows us to minimize newing costs. It is mostly used for this purpose here.
            //A new record is created as customer2 is an unenhanced clon.
            Console.ReadLine();
        }
        public abstract class Person
        {
            public abstract Person Clone();


            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Customer:Person
        {
            public string City { get; set; }
            public override Person Clone()
            {
                return (Person) MemberwiseClone(); // MemberwiseClone()  It is a defined function.
            }
        }
        public class Employee : Person
        {
            public decimal Salary { get; set; }
            public override Person Clone()
            {
                return (Person)MemberwiseClone(); // MemberwiseClone() It is a defined function.
               
            }
        }
    }
   
}

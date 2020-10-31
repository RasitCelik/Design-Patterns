using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        //Observer design pattern is the pattern that allows the subscribed systems to run when
        //there is a process like used to be notified when the price of the product is reduced
        //in a shopping system
        static void Main(string[] args)
        {
            ProductManager productManager=new ProductManager();
            productManager.Attached(new CustomerObserver());
            productManager.Attached(new EmployeeObserver());
            productManager.UpdatePrice();

            Console.ReadLine();
        }

    }

    class ProductManager
    {
         List<Observer> _observers=new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price Changed");
            Notify();
        }

        public void Attached(Observer observer)
        {
            _observers.Add(observer);
        }
        public void Detached(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

   abstract class Observer
   {
       public abstract void Update();
   }

   class CustomerObserver:Observer
   {
       public override void Update()
       {
           Console.WriteLine("Message to Customer : Product price changed");
       }
   }

   class EmployeeObserver:Observer
   {
       public override void Update()
       {
           Console.WriteLine("Message to Employee : Product price changed");
       }
   }
}

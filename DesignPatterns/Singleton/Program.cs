using System;

namespace Singleton
{
    // In Singleton DesignPattern, even when the value of an object changes aims to be used by the user
    // With the same value.For example, if we want to keep the daily user numbers of a website,
    // This value should be the same for each user.
    // It is used for objects that only operate but do not even hold values ​​(such as Manager Object).
    
    
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();

        private CustomerManager()
        {
            
        }

        public static CustomerManager CreateAsSingleton()
        {
            // If the object has not yet been created and more than one user wants to call at the same time
            // Lock command is used to prevent two occurrences. The thread is called Safe Singleton.
            lock (_lockObject) 
            {
                if (_customerManager==null)
                {
                    _customerManager=new CustomerManager();
                }
            }

            return _customerManager;


        }

        public  void Save()
        {
            Console.WriteLine("Saved");
        }

    }
}



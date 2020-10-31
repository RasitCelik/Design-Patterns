using System;

namespace Facade
{
    //Rather than reaching the classes we use for common purposes one by one, the purpose of this pattern is
    //To gather them on a single facade and access them through that facade.
    
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging:Ilogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface Ilogging
    {
        void Log();
    }


    class Caching:ICache
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICache
    {
        void Cache();
    }

    class Autorize:IAutorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    internal interface IAutorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossFacade _crossFacade; //Even when something is added to the CrossFacade class in the future,
                                          //There will be no need to change anything because of the ctor here.
        public CustomerManager()
        {
            _crossFacade=new CrossFacade();
        }

        public void Save()
        {
            _crossFacade.Caching.Cache();
            _crossFacade.Logging.Log();
            _crossFacade.Autorize.CheckUser();
            Console.WriteLine(" Saved");
        }
    }

    class CrossFacade
    {
        public Ilogging Logging;
        public ICache Caching;
        public IAutorize Autorize;

        public CrossFacade()
        {
            Logging=new Logging();
            Caching=new Caching();
            Autorize=new Autorize();
        }

    }


}

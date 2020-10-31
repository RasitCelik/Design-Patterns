using System;

namespace Adapter
{
    //This pattern is briefly especially when different systems need to be integrated into our own systems,
    //Our own system works as if the different system is ours without breaking it.
    //In this example, let's assume that Log4Net plugin (web service or dll) comes from outside and
    //We cannot change it.So we can't implement ILogger.
    //As a solution, the Log4NetAdapter class was created and Log4Net was called in it.

    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager=new ProductManager(new Log4NetAdapter());
            productManager.Save();


            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _iLogger;

        public ProductManager(ILogger iLogger)
        {
            _iLogger = iLogger;
        }

        public void Save()
        {
            _iLogger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class EdLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged {0}",message);
        }
    }
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net {0}",message);
        }
    }

    class Log4NetAdapter:ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net=new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}

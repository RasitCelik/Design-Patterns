using System;

namespace FactoryMethod
{
    //It is one of the most commonly used DesignPattern.The aim is to keep change in software under control.
    class Program
    {
        static void Main(string[] args)
        {
            //In this part, Ioc Container is normally used.
            CustomerManager customerManager =new CustomerManager(new LoggerFactory2()); 
            customerManager.Save();


            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }

    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4Net();
        }

    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log with edlogger");
        }
    }

    public class Log4Net:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log with Log4Net");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
            ILogger iLogger = _loggerFactory.CreateLogger();
            iLogger.Log();
        }
    }

}

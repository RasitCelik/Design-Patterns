using System;

namespace NullObject
{
    //When the project is wanted to be tested, but despite the test,If desired no action other than the correct
    //operation of the test should be done.A hollow stublogger was created and this object was called.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    class NLogLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog");
        }
    }

    class StubLogger:ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock=new object();

        private StubLogger()
        {
        }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger==null)
                {
                    _stubLogger=new StubLogger();
                }
            }

            return _stubLogger;
        }



        public void Log()
        {
            
        }
    }

    class CustomerManagerTest
    {
        public void SaveTest()
        {
            CustomerManager customerManager=new CustomerManager(StubLogger.GetLogger()); 
            // testin loggerlara bağımlı olmaması için içi boş bir stublogger oluşturuldu. Ayrıca tekrar tekrar instance üretmemesi için lock
            //  ifadesi yerleştirildi
            customerManager.Save();
        }
    }
}

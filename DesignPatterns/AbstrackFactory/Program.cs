using System;

namespace AbstrackFactory
{
    //This pattern can be used if we have different business processes according to the conditions.
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager=new ProductManager(new Factory2());
            productManager.GetAll();


            Console.ReadLine();
        }
    }
    public  abstract class Logging
    {
        public abstract void Log(string message);

    }

   public class Log4NetLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
   public class NLogger : Logging
   {
       public override void Log(string message)
       {
           Console.WriteLine("Logged with NLogger");
       }

   }

   public abstract class Caching
   {
       public abstract void Cache(string data);
   }

   public class MemCache:Caching
   {
       public override void Cache(string data)
       {
           Console.WriteLine("Cached with MemCache");
       }
   }
   public class RedisCache : Caching
   {
       public override void Cache(string data)
       {
           Console.WriteLine("Cached with RedisCache");
       }
   }

   public abstract class CrossCuttingConcernsFactory
   {
       public abstract Logging CreateLogger();
       public abstract Caching CreateCaching();

   }
   public class Factory1:CrossCuttingConcernsFactory
   {
       public override Logging CreateLogger()
       {
            return new Log4NetLogger();
       }

       public override Caching CreateCaching()
       {
           return new RedisCache();
       }
   }
   public class Factory2 : CrossCuttingConcernsFactory
   {
       public override Logging CreateLogger()
       {
           return new NLogger();
       }

       public override Caching CreateCaching()
       {
           return new MemCache();
       }
      
   }
   public class ProductManager
   {
       private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
       private Logging _logging;
       private Caching _caching;
       public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
       {
           _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
           _logging = _crossCuttingConcernsFactory.CreateLogger();
           _caching = _crossCuttingConcernsFactory.CreateCaching();
       }

       public void GetAll()
       {
           _logging.Log("Logged");
           _caching.Cache("Data");
           Console.WriteLine("Products Listed!");
       }
   }
}

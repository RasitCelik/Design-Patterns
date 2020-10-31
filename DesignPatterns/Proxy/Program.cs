using System;
using System.Threading;

namespace Proxy // Once the transaction was verified, we used a proxy to avoid waiting over and over again.
{
    class Program
    {
        static void Main(string[] args)
        {
           // CreditManager creditManager=new CreditManager();
           CreditBase creditManager=new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());
            Console.WriteLine(creditManager.Calculate());

            Console.ReadLine();
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate(); 
       
    }

    class CreditManager:CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result*= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy:CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager==null)
            {
                _creditManager=new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }

            return _cachedValue;
        }
    }
}

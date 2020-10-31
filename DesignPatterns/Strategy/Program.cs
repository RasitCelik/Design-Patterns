using System;

namespace Strategy
{
    class Program
    {
        //In this DesingPattern a different loan calculation has been applied for different types of customers
        //of a bank.
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.CreditCalculaterBase=new After2010();
            customerManager.SaveCredit();

            Console.ReadLine();
        }
    }

   abstract class CreditCalculaterBase
   {
       public abstract void Calculate();
   }

   class Before2018:CreditCalculaterBase
   {
       public override void Calculate()
       {
           Console.WriteLine("Credit calculated using before 2010");
       }
   }
   class After2010 : CreditCalculaterBase
   {
       public override void Calculate()
       {
           Console.WriteLine("Credit calculated using after 2010");
       }
   }

   class CustomerManager
   {
       public CreditCalculaterBase CreditCalculaterBase { get; set; }
       public void SaveCredit()
       {
           Console.WriteLine("customer manager business");
           CreditCalculaterBase.Calculate();
       }

   }
}

using System;
using System.Reflection;

namespace Bridge
{
    //The purpose of this pattern is to create and use abstraction techniques
    //if there are changeable parts in an object.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.MessageManagerBase=new EmailSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

   abstract class MessageManagerBase
    {
        public void Save()
        {
            Console.WriteLine("Saved");
        }

        public abstract void Send(Body body);
        
    }

   class MailSender:MessageManagerBase
   {
       public override void Send(Body body)
       {
           Console.WriteLine("{0} was sent via Mailsender",body.Title);
       }
   }

   internal class Body
   {
       public string Title { get; set; }
       public string Text { get; set; }
   }

   class EmailSender:MessageManagerBase
   {
       public override void Send(Body body)
       {
           Console.WriteLine("{0} was sent via EMailsender", body.Title);
        }
   }

   class CustomerManager
   {
       public MessageManagerBase MessageManagerBase { get; set; }
       public void UpdateCustomer()
       {
           MessageManagerBase.Send(new Body{Title = "lag"});
           Console.WriteLine("customer updated");
       }
   }
}

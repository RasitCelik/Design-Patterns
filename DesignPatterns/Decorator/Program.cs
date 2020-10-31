using System;

namespace Decorator
{
    class Program
    {
        //Let's assume we have a car rental company. we want to offer special discounts for some customers
        //During some periods. This pattern can be used for these conditions.
        static void Main(string[] args)
        {
            var personelCar = new PersonalCar {Make = "BMW", Model = "3.20", HirePrice = 2500};
            SpecialOffer specialOffer=new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 90;
            Console.WriteLine(personelCar.HirePrice);
            Console.WriteLine(specialOffer.HirePrice);

            Console.ReadLine();

        }
    }

     abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string  Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

     class PersonalCar:CarBase
     {
         public override string Make { get; set; }
         public override string Model { get; set; }
         public override decimal HirePrice { get; set; }
     }
     class CommercialCar : CarBase
     {
         public override string Make { get; set; }
         public override string Model { get; set; }
         public override decimal HirePrice { get; set; }
     }

     abstract class CarDecoratorBase:CarBase
     {
         private CarBase _carBase;

         protected CarDecoratorBase(CarBase carBase)
         {
             _carBase = carBase;
         }
     }

      class SpecialOffer : CarDecoratorBase
     {
         private readonly CarBase _carBase;
         public int DiscountPercentage { get; set; }
         public SpecialOffer(CarBase carBase) : base(carBase)
         {
             _carBase = carBase;
         }

         public override string Make { get; set; }
         public override string Model { get; set; }
         public override decimal HirePrice {
             get
             {
                 return _carBase.HirePrice * DiscountPercentage / 100;
             }
             set { }
         }
     }
}

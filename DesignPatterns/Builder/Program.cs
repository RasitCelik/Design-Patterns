using System;
using System.Reflection.Metadata;

namespace Builder
{
    class Program
    {
        //The purpose of the pattern is to extract an object as a result of successive operations,
        //Such as making a pizza.
        static void Main(string[] args)
        {
            ProductDirector director=new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CatagoryName);

            Console.ReadLine();
        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CatagoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }




    }


    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void AppliedDiscount();
        public abstract ProductViewModel GetModel(); 
    }

    class NewCustomerProductBuilder:ProductBuilder
    {
        ProductViewModel model=new ProductViewModel();


        public override void GetProductData()
        {
            model.Id = 1;
            model.CatagoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice*(decimal) 0.9;
            model.DiscountApplied=true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CatagoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    public class ProductDirector
    {

        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.AppliedDiscount();
        }
    }
}

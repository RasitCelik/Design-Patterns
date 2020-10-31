using System;
using Ninject;

namespace DependencyInjection
{
    class Program
    {
        //It is a pattern that is used both to remove the dependence of one object on another object and
        //Between layers.
        static void Main(string[] args)
        {
            IKernel kernel=new StandardKernel();
            kernel.Bind<IProductDal>().To<ProductDal2>().InSingletonScope(); //Added with Ioc Container.
            //When IProductdal is requested, it gives Productdal2 instance.
            //InSingletonScope (), on the other hand, gives the same instance if 1000 people want to use it.
            //Provides performance increase.
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();

    }

    class ProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }
    class ProductDal2 : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef2");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business Code
            //ProductDal productDal=new ProductDal(); It is a dependent method, so injection is done here.
            _productDal.Save();
            
        }
    }
}

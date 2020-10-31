using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        //This pattern is the loading of operations such as the robot turning right or stepping back and
        //Forth in a robot programming.If desired, it can be considered as running these functions.
        static void Main(string[] args)
        {
            StockManager stockManager=new StockManager();
            BuyStock buyStock=new BuyStock(stockManager);
            SellStock sellStock=new SellStock(stockManager);

            StockController stockController=new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlaceOrders();

            Console.ReadLine();
        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock:{0},{1} bought!",_name,_quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock:{0},{1} sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();


    }
    class BuyStock:IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }
    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
           _stockManager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders=new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();  //After the processes are run, the inside of the process list is cleared.
        }
    }
}

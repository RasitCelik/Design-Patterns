using System;
using System.Collections.Generic;

namespace Multiton
{
    //This pattern is used to correctly generate instances that meet certain conditions to the right places.
    //For example, if there are 100 requests in a singleton, an instance is generated, while 100 requests and
    //10 conditions (parameters) in a Multiton If there are,
    //10 parameters are generated for 100 requests and 10 instances are given where necessary.
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1=Camera.GetCamera("Nikon");
            Camera camera2 = Camera.GetCamera("Canon");
            Camera camera3 = Camera.GetCamera("Nikon");
            Camera camera4 = Camera.GetCamera("Canon");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            Console.ReadLine();

        }
    }

    class Camera
    {
        static Dictionary<string,Camera> _cameras=new Dictionary<string, Camera>();
       static object _lock=new object();
       public Guid Id { get; set; }
        
        private Camera()
        {
            Id=Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand,new Camera());
                }
            }

            return _cameras[brand];
        }
    }
}

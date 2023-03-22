using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {

             CarTest();
             Console.ReadLine();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            
            foreach (var product in carManager.GetCarDetailDto())
            {
                Console.WriteLine(product.CarName);
                Console.WriteLine(product.BrandName);
                Console.WriteLine(product.DailyPrice);
                Console.WriteLine(product.ColorName);
            }



        }
    }
}

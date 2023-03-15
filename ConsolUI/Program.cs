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
            ICarService _ıCarService = new CarManager(new EFCarDal());

            foreach (var car in _ıCarService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}

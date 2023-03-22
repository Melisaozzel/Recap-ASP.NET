using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
  public class CarManager:ICarService
  {
        ICarDal _ICarDal;

       public CarManager(ICarDal ıCarDal)
       {
           _ICarDal = ıCarDal;
       }
        public List<Car> GetAll()
        {
            return _ICarDal.GetAll();
        }


        public List<Car> GetCarsByBrandId(int id)
        {
            return _ICarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _ICarDal.GetAll(p => p.ColorId == id);

        }

        public void AddWithCondition(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
                _ICarDal.Add(car);
            else
                Console.WriteLine("Araba ismini ve günlük ücreti konrol edin!");

        }

        public List<CarDetailDto> GetCarDetailDto()
        {
          return  _ICarDal.GetCarDetails();
        }
  }
}

using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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
    }
}

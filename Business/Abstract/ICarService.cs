﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICarService
   {
       List<Car> GetAll();
       List<Car> GetCarsByBrandId(int id);
       List<Car> GetCarsByColorId(int id);
       void AddWithCondition(Car car);
   }
}

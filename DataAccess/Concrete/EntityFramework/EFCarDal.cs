using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
namespace DataAccess.Concrete.EntityFramework
{
   public class EFCarDal:EfEntityRepositoryBase<Car,RecapProjectContext>,ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                var result = from car in context.Cars
                    join b in context.Brands on car.BrandId equals b.id
                    join c in context.Colors on car.ColorId equals c.id
                    select new CarDetailDto()
                    {
                        CarName = car.Description, BrandName = b.Name, ColorName = c.Name, DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EFCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapProjectContext context=new RecapProjectContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Add(Car entity)
        {
            using (RecapProjectContext context=new RecapProjectContext()) //IDispossable pattern implementation of c# => Garbage collector 
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;    // EntityState.Added
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RecapProjectContext context=new RecapProjectContext()) //EntityState.Deleted 
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (RecapProjectContext context=new RecapProjectContext()) //EntityState.Modified
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}

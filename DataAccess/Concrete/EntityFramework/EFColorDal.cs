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
    public class EFColorDal : IEntityRepository<Color>
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RecapProjectContext context=new RecapProjectContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Add(Color entity)
        {
            using (RecapProjectContext context=new RecapProjectContext()) //IDispossable pattern implementation of c# => Garbage collector 
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;    // EntityState.Added
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecapProjectContext context=new RecapProjectContext()) //EntityState.Deleted 
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Color entity)
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

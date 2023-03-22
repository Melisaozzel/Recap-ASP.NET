using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;


namespace Core.DataAccess
{
    //Generic constrait
    //where T:class =>> T bir referans tip olabilir
    //where T:class,IEntity =>> T bir Ientity veya ondan extend edilmis bir class olabilir
    // new() =>> new() lenebilir olmalı, yani interface olamaz kısıtı konuldu.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //filter==NULL => filtre yok demek. 
        List<T>GetAll(Expression<Func<T,bool>> filter=null); // Linq ile expression vererek  ürünleri get yapabilirsin
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

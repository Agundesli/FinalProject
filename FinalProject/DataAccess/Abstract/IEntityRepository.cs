using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic Constraint
    //class:Referans Tip olabilir demek.
    //IEntity:IEntity olabilir veya bunu implemente duran bir nesne olabilir.
    //new(): newlenebilir olmalı, Interface newlenemeyeceği için yazılamaz
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter );

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

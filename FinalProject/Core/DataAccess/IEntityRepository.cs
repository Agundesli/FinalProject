using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic Constraint
    //class:Referans Tip olabilir demek.
    //IEntity:IEntity olabilir veya bunu implemente duran bir nesne olabilir.
    //new(): newlenebilir olmalı, Interface newlenemeyeceği için yazılamaz
    //Core katmanı hiç bir yere bağımlı olmamalıdır. Hiçbir katmanı referans almaz
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter );

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    //Select
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //çoğul olan select sorgularında yani birden fazla veri getirteceksen burada IQueryable kullanılır
        IQueryable<T> GetAll(bool tracking = true);
 
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method, bool tracking = true);
        
        //1 tane getir
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method, bool tracking = true);

        //getbyId
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}

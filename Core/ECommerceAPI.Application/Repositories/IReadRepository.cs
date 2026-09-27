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
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method);
        
        //1 tane getir
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method);

        //getbyId
        Task<T> GetByIdAsync(string id);
    }
}

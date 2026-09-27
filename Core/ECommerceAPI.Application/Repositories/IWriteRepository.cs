using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    //Insert Update Delete
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        //create
        Task<bool> CreateAsync(T model);

        //koleksyon olarak create
        Task<bool> CreateAsync(List<T> models);

        //remove
        bool Remove(T model);

        //birden fazla silmek istersek
        bool Remove(List<T> models);

        //belirli ID ye göre silmek istersek
        Task<bool> RemoveAsync(string id);

        //update
        bool Update(T model);

        //Save changes
        Task<int> SaveAsync();
    }
}

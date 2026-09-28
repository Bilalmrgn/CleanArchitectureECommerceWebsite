using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        //1 tane kayıt ekle
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);

            return entityEntry.State == EntityState.Added;
        }

        //1'den fazla kayıt ekle
        public async Task<bool> CreateAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Remove(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        //remove
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            
            if(model != null)
            {
                return Remove(model);
            }
            else
            {
                throw new Exception("Id not found");
            }
        }

        //save changes
        public Task<int> SaveAsync() => _context.SaveChangesAsync();


        //update
        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);

            return entityEntry.State == EntityState.Modified;
        }
    }
}

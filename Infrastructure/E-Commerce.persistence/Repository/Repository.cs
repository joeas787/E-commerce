using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Repository
{
    public class Repository<T, K> (ApplicationDbContext dbContext): IRepository<T, K>
        where T : Entity<K>
    {
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
           return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(K id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().FindAsync(id,cancellationToken);
        }

        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}

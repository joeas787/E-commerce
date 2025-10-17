using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Repository;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{

    private readonly Dictionary<string,object> _repositories = [];

   

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync();
    }

   public IRepository<T, K> GetRepository<T, K>() where T : Entity<K>
    {
        var typeName = typeof(T).Name;

        if (_repositories.TryGetValue(typeName, out object? value))
            return (value as IRepository<T, K>)!;

        var repo = new Repository<T, K>(dbContext);
        _repositories.Add(typeName, repo);
        return repo;
    }
}

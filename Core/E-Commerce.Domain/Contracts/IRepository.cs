using E_Commerce.Domain.Entities;
using E_Commerce.persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts;

public interface IRepository<T,K> where T : Entity<K>
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<T> GetByIdAsync(K id, CancellationToken cancellationToken = default);
    Task<T> GetByAsync(ISpecifications<T> specifications, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(ISpecifications<T> specifications , CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecifications<T>  specifications,CancellationToken cancellationToken = default);

}

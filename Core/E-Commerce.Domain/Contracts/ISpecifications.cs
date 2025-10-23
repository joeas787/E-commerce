using System.Linq.Expressions;

namespace E_Commerce.persistence.Repository
{
    public interface ISpecifications<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
        ICollection<Expression<Func<T, Object>>> Includes { get; } 
        
      public Expression<Func<T, Object>> OrderBy { get; }
      public Expression<Func<T, Object>> OrderByDesc { get; }
        int Skip {  get; }
        int Take { get; }
        bool IsPaginated { get; }

    }
}
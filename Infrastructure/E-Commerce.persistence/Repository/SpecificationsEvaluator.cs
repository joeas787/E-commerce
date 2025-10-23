using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Repository
{
    public static class SpecificationsEvaluator
    {
        public static IQueryable<T> CreateQuery<T>(this IQueryable<T> input,ISpecifications<T> specifications)where T : class
        {


            var query = input;
            if(specifications.Criteria is not null)
                query=query.Where(specifications.Criteria);
            foreach(var include in specifications.Includes)
                  query = query.Include(include);

            if(specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);
            else if(specifications.OrderByDesc is not null)
                query=query.OrderByDescending(specifications.OrderByDesc);

            if(specifications.IsPaginated)
                query=query.Skip(specifications.Skip).Take(specifications.Take);

            return query;
        }

    }
}

using E_Commerce.persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications;

public abstract class BaseSpecifications<T> : ISpecifications<T> where T : class
{ 

  public  BaseSpecifications(Expression<Func<T, bool>> criteria) { 
    
    Criteria = criteria;
    }
    public ICollection<Expression<Func<T, object>>> Includes { get; private set; } = [];

    public Expression<Func<T, bool>> Criteria { get; private set; }
    public Expression<Func<T, object>> OrderBy { get; private set;  }
    public Expression<Func<T, object>> OrderByDesc { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> expression)
    {


        Includes.Add(expression);


    }
    protected void AddOrderBy(Expression<Func<T, object>> expression)
    {

       OrderBy=expression;


    }

    protected void AddOrderByDesc(Expression<Func<T, object>> expression)
    {

        OrderByDesc = expression;


    }

   public int Skip { get; private set; }
    public int Take { get; private set; }
    public bool IsPaginated { get; private set; }

    protected void Paginated(int size,int index)
    {

      IsPaginated = true;

        Skip = (index - 1) * size;
        Take = size;


    }
}

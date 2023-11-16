using Microsoft.EntityFrameworkCore;
using ApiTemp.Models;
using System.Linq.Expressions;
using ApiTemp.Contracts;

namespace ApiTemp.Repository
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected ApiTempContext RepositoryContext { get; set;}
    public RepositoryBase(ApiTempContext repositoryContext)
    {
      this.RepositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll()
    {
      return this.RepositoryContext.Set<T>()
      .AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
      return this.RepositoryContext.Set<T>()
      .Where(expression)
      .AsNoTracking();
    }
  }
}
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Linq.Expressions;
using AnimalShelter.Contracts;

namespace AnimalShelter.Repository
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected AnimalShelterContext RepositoryContext { get; set;}
    public RepositoryBase(AnimalShelterContext repositoryContext)
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
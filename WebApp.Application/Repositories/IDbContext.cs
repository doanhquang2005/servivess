using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;

namespace WebApp.Application.Repositories {
  public interface IDbContext : IDisposable {
    /// <summary>
    /// Returns a System.Data.Entity.DbSet<TEntity> instance for access to entities of the given type in the context and the underlying store.
    /// </summary>
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    /// <summary>
    ///  Gets a System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> object for the given entity providing access to information about the entity and the  ability to perform actions on the entity.
    /// </summary>
    EntityEntry Entry(object entity);

    /// <summary>
    ///  Gets a System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> object for the given entity providing access to information about the entity and the  ability to perform actions on the entity.
    /// </summary>
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Asynchronously saves all changes made in this context to the underlying database.
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
  }
}
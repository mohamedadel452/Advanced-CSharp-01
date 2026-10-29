using System.Collections.Generic;

namespace Advanced_CSharp_01
{
 
    #region IRepository<T> Generic Interface
    /// <summary>
    /// Generic Interface defining standard CRUD repository contract (Q6).
    /// Decouples data access abstractions from concrete implementations and entity models.
    /// </summary>
    /// <typeparam name="T">The entity type managed by the repository.</typeparam>
    public interface IRepository<T>
    {
        #region Methods
        void Add(T entity);
        T? GetById(int id);
        IEnumerable<T> GetAll();
        bool Remove(T entity);
        #endregion
    }
    #endregion
}

using System.Linq.Expressions;

namespace PhotoCaptureApplication.DAL.Interfaces
{
    public interface IDBRepository<T> where T : class
    {
        List<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        IEnumerable<T> ExecWithStoredProcedure(String query, params object[] parameters);
    }
}

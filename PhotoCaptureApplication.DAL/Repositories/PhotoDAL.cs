using PhotoCaptureApplication.DAL.Interfaces;
using PhotoCaptureApplication.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PhotoCaptureApplication.DAL;

namespace PhotoCaptureApplication.DAL.Repositories
{
    public class PhotoDAL : IDBRepository<PhotoModel>
    {
        private readonly PhotoCaptureDataContext _db;

        public PhotoDAL(PhotoCaptureDataContext db)
        {
            this._db = db;
        }

        public void Add(PhotoModel entity)
        {
            _db.Photos.Add(entity);
        }

        public void Delete(PhotoModel entity)
        {
            _db.Photos.Remove(entity);
        }

        public void Edit(PhotoModel entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<PhotoModel> ExecWithStoredProcedure(string query, params object[] parameters)
        {
            return _db.Photos.FromSqlRaw<PhotoModel>(query, parameters).ToList();
        }

        public IQueryable<PhotoModel> FindBy(Expression<Func<PhotoModel, bool>> predicate)
        {
            IQueryable<PhotoModel> query = _db.Photos.Where(predicate);
            return query;
        }

        public List<PhotoModel> GetAll()
        {
            List<PhotoModel> query = _db.Photos.ToList();
            return query;
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}

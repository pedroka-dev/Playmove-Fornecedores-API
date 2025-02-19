
using Fornecedores_Model;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores_ORM
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly SupplierDBContext dbContext;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(SupplierDBContext db)
        {
            dbContext = db;
            dbSet = db.Set<T>();
        }

        public bool Insert(T registro)
        {
            try
            {
                dbSet.Add(registro);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public virtual bool Update(int id, T registro)
        {
            try
            {
                registro.Id = id;
                var entity = dbSet.Find(id);
                dbContext.Entry(entity).CurrentValues.SetValues(registro);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                T registro = SelectById(id);
                if (registro != null)
                {
                    dbSet.Remove(registro);
                    dbContext.SaveChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual T SelectById(int id)
        {
            try
            {
                return dbSet.FirstOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual List<T> SelectAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

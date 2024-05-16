using Microsoft.EntityFrameworkCore;

namespace SchoolWebApp.Data
{

    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private bool disposedValue;


        AppDBContext _appDBContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            _dbSet = appDBContext.Set<T>();
        }

        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            _appDBContext.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            _appDBContext.SaveChanges();
            return true;
        }

        public List<T> Read()
        {
            return _dbSet.ToList();
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            _appDBContext.SaveChanges();
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GenericRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region ctor

        private readonly DbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>(); /*mitonim databasemoon ro haminja set konim*/
        }

        #endregion


        #region Delete

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null) /*goftam age entity null bood yek Exception az noe Arguman bargardoon ke in moshkel dasht . vagarne pakesh kon entitio*/
                throw new ArgumentException("there is no entity");
            _db.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objs = _dbSet.Where(where).AsEnumerable(); /*IQueriable hastesh bayad be Ienumerable tabdil she*/

            foreach (TEntity item in objs)
            {
                _dbSet.Remove(item);
            }
        }

        #endregion


        #region Get

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault(); /*age dasht avalisho barmigardoone age nadasht null barmigardoone*/
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        #endregion

        #region GetAsync

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        #endregion


        #region Insert

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        #endregion

        #region InsertAsync

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        #endregion


        #region Update

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("there is no entity");
            _dbSet.Update(entity);
        }

        #endregion


        #region dispose

        private bool disposed = false; /*mige vaghti in UnitOfWorko ye instance azash sakhti , baraye shoro aya database dispose shode ? ke ghatan nashode*/
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose(); /*migam age dispose shode bood database ro dispose kone va bad meghdaresho true bede va hamintor age meghdar disposing true bood*/
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); /*khodesho seda mizanam chon virtual hastesh*/
            GC.SuppressFinalize(this); /*this yani hamin DbContextam . in GC vaghti hamiche ok bood miad cleanup mikone tamiz mikone */
        }

        ~Repository()
        {
            Dispose(false);
        }

        #endregion
    }
}

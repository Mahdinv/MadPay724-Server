using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new() /*inam az IUnitOfWorkemoon ers bari mikone faghat dar akhar kar ma bayad ye new() bezarim ke in az syntax haye khode microsoft hastesh . badesham IUnitOfWorko implement mikonim*/
    {
        #region ctor

        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }/*ta ghabl az in chon ma az TContext estefade mikardim moshakhas nabood darim az kodom database estefade mikonim . vali bazam ta alan nemidoonim databasemoon kodome khodeoon badan moshakhas mikonim*/


        #endregion

        #region save

        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync(); /*chon void nist gharare ye meghdar bargardoone ke in ye meghdar adadie. fek konam 0 yani error darim 1 yani pass shode*/
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

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}

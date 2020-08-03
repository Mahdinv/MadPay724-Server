using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastructure
{
    interface IRepository<TEntity> where TEntity : class /*kolan repository ba model haye database dar ertebate pas az noe TEntity tariif mishe . va migim ke in Tentity az noe class hastesh*/
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id); /*bar asas Id . chon Idim sabt nist pas yek objecte*/
        void Delete(TEntity entity); /*khod entityo pak mikone(bar asas yek entity)*/
        void Delete(Expression<Func<TEntity,bool>> where); /*bar asas yek shart(condition) pak mikone . chon shartie in modeli tariif mikonim esmesham where mishe(where esme)*/

        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity, bool>> where); /*get by condition . mikhad yedoonaro bargardoone*/
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where); /*get by condition . chon mikhad chan taro bargardoone GetMany gozashtam . to in khat mikhad chantaro bargardoone . to khat bala mikhad yedoonaro bargardoone*/


        //---------------------------------------------------------------

        Task InsertAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
    }
}

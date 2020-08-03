using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext  /*migamm shoma gharare DbContext haro begiri vali chon unitOfWorke maloom nist che DbContexti mikham behet bedam va hamintor maloom nist az chanta database gharare estefade konim pas niaz hastesh bazam generic benevisim . hamintor zamani ke ma transaction databasemoon tamoom shod oon ertebat bein ma va database ro dispose bokonim , methodesho badan khodesh impliment mikone . hamintor ye shart mizarim => migam in <TContext> bayad az noe DbContext bashe*/
    {
        void Save();
        Task<int> SaveAsync(); /*inam az tavabeye ke gharare ma zaman transaction ha azash estefade konim*/
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi.DataModel.UOWGenericRepo
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<PoliticalLeaders> PoliticalRepository { get; }
        IGenericRepository<Volunteers> VolunteersRepository { get; }
        void Save();
        Task SaveAsync();
    }
}

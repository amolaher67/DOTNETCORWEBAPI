using System;
using System.Collections.Generic;
using System.Text;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi.DataModel.UOWGenericRepo
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<PoliticalLeaders> PoliticalRepository { get; }
        void Save();
    }
}

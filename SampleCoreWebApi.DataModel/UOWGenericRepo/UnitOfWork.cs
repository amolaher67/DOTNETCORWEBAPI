using System;
using System.Collections.Generic;
using System.Text;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi.DataModel.UOWGenericRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _electionContext;
        private IGenericRepository<PoliticalLeaders> _politicalRepository;

        public UnitOfWork(DataContext electionContext)
        {
            _electionContext = electionContext;
        }

        public IGenericRepository<PoliticalLeaders> PoliticalRepository
        {
            get
            {
                return _politicalRepository =
                    _politicalRepository ?? new GenericRepository<PoliticalLeaders>(_electionContext);
            }
        }

        public void Save()
        {
            _electionContext.SaveChanges();
        }

        public void Dispose()
        {
            _electionContext?.Dispose();
        }
    }
}

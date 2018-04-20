using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi.DataModel.UOWGenericRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElectionContext _electionContext;
        private IGenericRepository<PoliticalLeaders> _politicalRepository;
        private IGenericRepository<Volunteers> _volunteersRepository;

        public UnitOfWork(ElectionContext electionContext)
        {
            _electionContext = electionContext;
        }

        public IGenericRepository<PoliticalLeaders> PoliticalRepository
        {
            get
            {
                return _politicalRepository = _politicalRepository ?? new GenericRepository<PoliticalLeaders>(_electionContext);
            }
        }

        public IGenericRepository<Volunteers> VolunteersRepository
        {
            get
            {
                return _volunteersRepository = _volunteersRepository ?? new GenericRepository<Volunteers>(_electionContext);
            }
        }

        public void Save()
        {
            _electionContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _electionContext.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _electionContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        
    }
}

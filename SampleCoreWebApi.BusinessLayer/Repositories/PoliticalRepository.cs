using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.BusinessLayer.IRepositories;
using SampleCoreWebApi.DataModel.Models;
using SampleCoreWebApi.DataModel.UOWGenericRepo;
using AutoMapper;

namespace SampleCoreWebApi.BusinessLayer.Repositories
{
    public class PoliticalRepository : IPoliticalRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PoliticalRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<EntityPoliticalLeaders>> GetAllPoliticalLeaders()
        {
            var politicalLeaders = await _unitOfWork.PoliticalRepository.GetAllAsyn();
            return _mapper.Map<ICollection<EntityPoliticalLeaders>>(politicalLeaders);
        }

        public async Task<EntityPoliticalLeaders> ValidatePoliticlLeader(string mobileNumber, string password)
        {
            if (string.IsNullOrEmpty(mobileNumber) || string.IsNullOrEmpty(password)) return null;

            var politicalLeaders = await
                 _unitOfWork.PoliticalRepository.FindFirstAsync(s => s.PoliticalLeaderMobileNumber == mobileNumber && s.PoliticalLeaderMobileNumber == password);

            return politicalLeaders != null ? _mapper.Map<EntityPoliticalLeaders>(politicalLeaders) : null;
        }

    }

}


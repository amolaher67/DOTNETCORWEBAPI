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
    public class VolunteersRepository : IVolunteerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VolunteersRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EntityVolunteers> ValidateUser(string mobileNumber, string password)
        {
            if (string.IsNullOrEmpty(mobileNumber) || string.IsNullOrEmpty(password)) return null;
            var politicalLeaders = await _unitOfWork.VolunteersRepository.FindFirstAsync(s => s.VolunteerMobileNumber == mobileNumber && s.VolunteerPassword == password);
            return politicalLeaders != null ? _mapper.Map<EntityVolunteers>(politicalLeaders) : null;
        }
    }

}


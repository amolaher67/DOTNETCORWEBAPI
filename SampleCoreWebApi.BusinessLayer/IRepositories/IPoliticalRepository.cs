using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.DataModel.Models;


namespace SampleCoreWebApi.BusinessLayer.IRepositories
{
    public interface IPoliticalRepository
    {
        Task<ICollection<Entity_PoliticalLeaders>> GetAllPoliticalLeaders();
    }
}

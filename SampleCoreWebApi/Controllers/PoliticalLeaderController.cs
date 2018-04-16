using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.BusinessLayer.IRepositories;


namespace SampleCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class LeaderController : Controller
    {
        private readonly IPoliticalRepository _politicalRepository;

        public LeaderController(IPoliticalRepository politicalRepository)
        {
            _politicalRepository = politicalRepository;
        }


        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet]
        [Route("GetAllPoliticalLeader")]
        [ProducesResponseType(typeof(Entity_PoliticalLeaders), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllPoliticalLeader()
        {
            try
            {
                var result = await _politicalRepository.GetAllPoliticalLeaders();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

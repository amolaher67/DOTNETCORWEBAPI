using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.BusinessLayer.IRepositories;
using SampleCoreWebApi.LogProvider;


namespace SampleCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class LeaderController : Controller
    {
        private readonly IPoliticalRepository _politicalRepository;
        private readonly ILogger<LeaderController> _logger;

        public LeaderController(IPoliticalRepository politicalRepository, ILogger<LeaderController> logger)
        {
            _politicalRepository = politicalRepository;
            _logger = logger;
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
                if (result != null)
                {
                    return Ok(result);

                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception e)
            {
                throw;

            }
        }
    }
}

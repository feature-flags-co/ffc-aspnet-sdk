using Microsoft.AspNetCore.Mvc;
using System.Net;
using DBMigrationDemo.Repositories;
using DBMigrationDemo.Services;
using DBMigrationDemo.ViewModels;

namespace DBMigrationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeatureFlagsController : ControllerBase
    {

        private readonly ILogger<FeatureFlagsController> _logger;
        private readonly IFeatureFlagService _ffService;

        public FeatureFlagsController(
            ILogger<FeatureFlagsController> logger, 
            IFeatureFlagService ffService)
        {
            _logger = logger;
            _ffService = ffService;
        }

        [HttpPost]
        [Route("createfeatureflag")]
        public async Task<JsonResult> CreateNewFeatureFlag([FromBody]CreateFeatureFlagParam param)
        {
            var newFeatureFlag = await _ffService.CreateFeatureFlagAsync(param);
            Response.StatusCode = (int)HttpStatusCode.Created;
            return new JsonResult(newFeatureFlag);
        }

        [HttpGet]
        [Route("getfeatureflag/{id}")]
        public async Task<FeatureFlagViewModel> GetFeatureFlag(string id)
        {
            return await _ffService.GetFeatureFlagAsync(id);
        }

        [HttpPut]
        [Route("updatefeatureflag")]
        public async Task<JsonResult> UpdateFeatureFlag([FromBody]UpdateFeatureFlagParam param)
        {
            var updatedFeatureFlag = await _ffService.UpsertFeatureFlagAsync(param);
            Response.StatusCode = (int)HttpStatusCode.NoContent;
            return new JsonResult(updatedFeatureFlag);
        }
    }
}
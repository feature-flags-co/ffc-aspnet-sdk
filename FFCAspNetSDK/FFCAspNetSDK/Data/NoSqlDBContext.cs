using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using DBMigrationDemo.Models;
using DBMigrationDemo.ViewModels;

namespace DBMigrationDemo.Data
{
    /// <summary>
    /// For easy demo, i use memory cache to simulate a nosql database
    /// </summary>
    public class NoSqlDBContext
    {
        private readonly IMemoryCache _memoryCache;
        public NoSqlDBContext(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // insert a value to memorycache
        public void Insert(string key, object value)
        {
            _memoryCache.Set(key, value);
        }

        public async Task<FeatureFlagDoc> CreateFeatureFlagAsync(CreateFeatureFlagParam param, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }
            var newFeatureFlag = new FeatureFlagDoc
            {
                Description = param.Description,
                Id = id,
                Name = param.Name,
                Rules = new List<RuleDoc>(),
                Variations = new List<VariationDoc>()
            };
            _memoryCache.Set(param, newFeatureFlag);
            return newFeatureFlag;
        }

        public async Task<FeatureFlagViewModel?> GetFeatureFlagAsync(string id)
        {
            var featureFlag = _memoryCache.Get<FeatureFlagDoc>(id);
            return featureFlag == null ? null : new FeatureFlagViewModel
            {
                Description = featureFlag.Description,
                Id = featureFlag.Id,
                Name = featureFlag.Name,
                Rules = new List<RuleViewModel>(),
                Variations = new List<VariationViewModel>()
            };
        }

        public async Task<FeatureFlagViewModel> UpsertFeatureFlagAsync(UpdateFeatureFlagParam param)
        {
            return new FeatureFlagViewModel
            {
                Id = param.Id,
                Description = param.Description,
                Name = param.Name,
                Rules = new List<RuleViewModel>(),
                Variations = new List<VariationViewModel>()
            };
        }



    }
}

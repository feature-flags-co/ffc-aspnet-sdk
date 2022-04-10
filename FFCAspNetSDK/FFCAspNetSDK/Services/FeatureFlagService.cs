using Microsoft.Extensions.Caching.Memory;
using DBMigrationDemo.Models;
using DBMigrationDemo.Repositories;
using DBMigrationDemo.ViewModels;

namespace DBMigrationDemo.Services
{
    public interface IFeatureFlagService
    {
        Task<FeatureFlagViewModel?> GetFeatureFlagAsync(string id);
        Task<FeatureFlagViewModel> CreateFeatureFlagAsync(CreateFeatureFlagParam param);
        Task<FeatureFlagViewModel> UpsertFeatureFlagAsync(UpdateFeatureFlagParam param);
    }
    public class FeatureFlagService: IFeatureFlagService
    {
        private readonly IFeatureFlagRepository _ffRepo;

        public FeatureFlagService(
            IFeatureFlagRepository ffRepo)
        {
            _ffRepo = ffRepo;
        }

        public async Task<FeatureFlagViewModel> CreateFeatureFlagAsync(CreateFeatureFlagParam param)
        {
            var ff = await _ffRepo.CreateFeatureFlagAsync(param);
            return new FeatureFlagViewModel
            {
                Name = ff.Name,
                Description = ff.Description,
                Id = ff.Id,
                Rules = new List<RuleViewModel>(),
                Variations = new List<VariationViewModel>()
            };
        }

        public async Task<FeatureFlagViewModel?> GetFeatureFlagAsync(string id)
        {
            var ff = await _ffRepo.GetFeatureFlagAsync(id);
            if (ff == null) return null;
            return new FeatureFlagViewModel
            {
                Name = ff.Name,
                Description = ff.Description,
                Id = ff.Id,
                Rules = new List<RuleViewModel>(),
                Variations = new List<VariationViewModel>()
            };
        }

        public async Task<FeatureFlagViewModel> UpsertFeatureFlagAsync(UpdateFeatureFlagParam param)
        {
            return await _ffRepo.UpsertFeatureFlagAsync(param);
        }
    }
}

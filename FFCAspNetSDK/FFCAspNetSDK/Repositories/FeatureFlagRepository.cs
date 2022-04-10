using Microsoft.EntityFrameworkCore;
using DBMigrationDemo.Data;
using DBMigrationDemo.Models;
using DBMigrationDemo.ViewModels;

namespace DBMigrationDemo.Repositories
{
    public interface IFeatureFlagRepository
    {
        Task<FeatureFlag> CreateFeatureFlagAsync(CreateFeatureFlagParam param);
        Task<FeatureFlag?> GetFeatureFlagAsync(string id);
        Task<FeatureFlagViewModel> UpsertFeatureFlagAsync(UpdateFeatureFlagParam param);
    }

    public class FeatureFlagRepository: IFeatureFlagRepository
    {
        private readonly SqlDBContext  _sqlDBContext;

        public FeatureFlagRepository(SqlDBContext sqlDBContext)
        {
            _sqlDBContext = sqlDBContext;
        }

        public async Task<FeatureFlag> CreateFeatureFlagAsync(CreateFeatureFlagParam param)
        {
            var newFeatureFlag = new Models.FeatureFlag
            {
                Name = param.Name,
                Description = param.Description,
                Id = Guid.NewGuid().ToString()
            };
            var createdFlag = await _sqlDBContext.FeatureFlags.AddAsync(newFeatureFlag);
            await _sqlDBContext.SaveChangesAsync();
            return createdFlag.Entity;
        }

        public async Task<FeatureFlag?> GetFeatureFlagAsync(string id)
        {
            return await _sqlDBContext.FeatureFlags.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<FeatureFlagViewModel> UpsertFeatureFlagAsync(UpdateFeatureFlagParam param)
        {
            // for simple demo usage, i didn't do it in a transaction
            // You konw, when we update database which related several tables, it sucks !
            // Here are codes which is complicate.

            //var ff = _sqlDBContext.FeatureFlags.FirstOrDefault(p => p.Id == param.Id) 
            //    ?? throw new Exception("Feature flag not found");

            //var variations = _sqlDBContext.Variations.Where(p => p.FeatureFlagId == ff.Id).ToList();
            //if(variations.Count > 0)
            //    _sqlDBContext.Variations.RemoveRange(variations);
            //if (param.Variations != null && param.Variations.Count > 0)
            //    _sqlDBContext.Variations.AddRange(param.Variations.Select(p => new Variation()
            //    {
            //        FeatureFlagId = ff.Id,
            //        Name = p.Name,
            //        Value = p.Value,
            //        ValueType = p.ValueType
            //    }).ToList());

            //var rules = _sqlDBContext.Rules.Where(p => p.FeatureFlagId == ff.Id).ToList();
            //var updateRules = param.Rules ?? new List<UpdateRuleParam>();
            //var newRules = updateRules.Where(p => string.IsNullOrEmpty(p.Id)).ToList();
            //var removeRules = rules.Where(p => !updateRules.Select(p => p.Id).ToList().Contains(p.Id)).ToList();
            //if (rules.Count > 0)
            //{
            //    for(int i = 0; i < removeRules.Count; i++)
            //    {
            //        var ruleItems = _sqlDBContext.RuleItems.Where(p => p.RuleId == removeRules[i].Id).ToList();
            //        _sqlDBContext.RuleItems.RemoveRange(ruleItems);
            //        _sqlDBContext.Rules.Remove(removeRules[i]);
            //    }
            //    ...
            //}

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

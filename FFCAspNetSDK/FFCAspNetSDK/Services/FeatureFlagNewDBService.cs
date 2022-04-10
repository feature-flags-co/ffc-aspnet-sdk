using DBMigrationDemo.Repositories;
using DBMigrationDemo.ViewModels;

namespace DBMigrationDemo.Services
{
    public interface IFeatureFlagNewDBService
    {
        Task<FeatureFlagViewModel> GetFeatureFlagAsync(string id);
    }
    public class FeatureFlagNewDBService : IFeatureFlagNewDBService
    {

        public FeatureFlagNewDBService()
        {
        }

        public Task<FeatureFlagViewModel> GetFeatureFlagAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

namespace DBMigrationDemo.Models
{
    public class Rule
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int OrderInRules { get; set; }
        public string Description { get; set; }
        public string FeatureFlagId { get; set; }
    }
}

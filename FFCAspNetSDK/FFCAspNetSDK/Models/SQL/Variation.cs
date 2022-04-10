namespace DBMigrationDemo.Models
{
    public class Variation
    {
        public int Id { get; set; }
        public string FeatureFlagId { get; set; }
        public string Name { get; set; }
        public string Value { get;set; }
        public string ValueType { get; set; }
    }
}

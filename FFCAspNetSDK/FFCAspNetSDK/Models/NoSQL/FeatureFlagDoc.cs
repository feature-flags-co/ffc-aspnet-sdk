namespace DBMigrationDemo.Models
{
    public class FeatureFlagDoc
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RuleDoc> Rules { get; set; }
        public List<VariationDoc> Variations { get; set; }
    }

    public class RuleDoc
    {
        public string Id { get; set; }
        public int OrderInRules { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RuleItemDoc> RuleItems { get; set; }
    }

    public class RuleItemDoc
    {
        public string Id { get; set; }
        public string OrderInRule { get; set; }
        public RuleConditionEnum Condition { get; set; }
        public string ConditionProperty { get; set; }
        public string ConditionValue { get; set; }
        public string ConditionValueType { get; set; }
    }

    public class VariationDoc
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}

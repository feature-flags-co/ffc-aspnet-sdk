using DBMigrationDemo.Models;

namespace DBMigrationDemo.ViewModels
{
    public class CreateFeatureFlagParam
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateFeatureFlagParam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UpdateRuleParam> Rules { get; set; }
        public List<UpdateVariationParam> Variations { get; set; }
    }

    public class UpdateRuleParam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UpdateRuleItemParam> RuleItems { get; set; }
    }

    public class UpdateRuleItemParam
    {
        public string Id { get; set; }
        public string OrderInRule { get; set; }
        public RuleConditionEnum Condition { get; set; }
        public string ConditionProperty { get; set; }
        public string ConditionValue { get; set; }
        public string ConditionValueType { get; set; }
    }

    public class UpdateVariationParam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}

using DBMigrationDemo.Models;

namespace DBMigrationDemo.ViewModels
{
    public class FeatureFlagViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RuleViewModel> Rules { get; set; }
        public List<VariationViewModel> Variations { get; set; }
    }

    public class RuleViewModel
    {
        public string Id { get; set; }
        public int OrderInRules { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RuleItemViewModel> RuleItems { get; set; }
    }

    public class RuleItemViewModel
    {
        public RuleConditionEnum Condition { get; set; }
        public string ConditionProperty { get; set; }
        public string ConditionValue { get; set; }
        public string ConditionValueType { get; set; }
    }

    public class VariationViewModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}

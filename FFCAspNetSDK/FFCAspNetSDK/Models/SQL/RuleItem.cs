namespace DBMigrationDemo.Models
{
    public enum RuleConditionEnum
    {
        IsOneOf,
        NotOneOf,
        Contains,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual
    }
    public class RuleItem
    {
        public int Id { get; set; }
        public string RuleId { get; set; }
        public RuleConditionEnum Condition { get;set; }
        public string ConditionProperty { get; set; }
        public string ConditionValue { get; set; }
        public string ConditionValueType { get; set; }   
    }
}

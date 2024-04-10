namespace UM.Application.Common.Extensions
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.MinimumLength(3).MaximumLength(20);
        }
    }
}

using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using UM.SharedKernel.Abstractions;

namespace ArchitectureTests
{
    public class NamingConventionTests : TestBase
    {
        [Fact]
        public void DomainEvents_Should_HaveNameEndingWith_DomainEvent()
        {
            ArchRuleDefinition
                .Classes().That().AreAssignableTo(typeof(DomainEventBase)).And().AreNot(typeof(DomainEventBase))
                .Should().HaveNameEndingWith("DomainEvent")
                .Check(Architecture);
        }
    }
}

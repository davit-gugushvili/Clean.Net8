using ArchitectureTests.Common;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using UM.SharedKernel.Interfaces;

namespace ArchitectureTests
{
    public class NamingConventionTests : TestBase
    {
        [Fact]
        public void DomainEvents_Should_HaveNameEndingWith_DomainEvent()
        {
            ArchRuleDefinition
                .Classes().That().ImplementInterface(typeof(IDomainEvent))
                .Should().HaveNameEndingWith("DomainEvent")
                .Check(Architecture);
        }
    }
}

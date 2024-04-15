using ArchitectureTests.Common;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;

namespace ArchitectureTests
{
    public class DependencyTests : TestBase
    {
        [Fact]
        public void SharedKernel_Should_NotDependOnAny_DomainLayer() 
        {
            ArchRuleDefinition
                .Types().That().Are(SharedKernelLayer)
                .Should().NotDependOnAny(DomainLayer)
                .Check(Architecture);
        }
    }
}

using ArchitectureTests.Common;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using MediatR;

namespace ArchitectureTests
{
    public class InternalModifierTests : TestBase
    {
        [Fact]
        public void RequestHandlers_Should_BeInternal()
        {
            ArchRuleDefinition
                .Classes().That().ImplementInterface(typeof(IRequestHandler<>))
                .Or().ImplementInterface(typeof(IRequestHandler<,>))
                .Should().BeInternal()
                .Check(Architecture);
        }
    }
}

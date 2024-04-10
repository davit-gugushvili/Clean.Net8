using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using Assembly = System.Reflection.Assembly;

namespace ArchitectureTests
{
    public abstract class TestBase
    {
        protected static readonly Assembly SharedKernelAssembly = typeof(UM.SharedKernel.Abstractions.IAggregateRoot).Assembly;
        protected static readonly Assembly DomainAssembly = typeof(UM.Domain.Aggregates.User.User).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(UM.Application.DependencyInjection).Assembly;
        protected static readonly Assembly PersistenceAssembly = typeof(UM.Persistence.DependencyInjection).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(UM.Infrastructure.DependencyInjection).Assembly;
        protected static readonly Assembly APIAssembly = typeof(UM.API.Auth.CurrentUser).Assembly;

        protected static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(
            SharedKernelAssembly,
            DomainAssembly,
            ApplicationAssembly,
            PersistenceAssembly,
            InfrastructureAssembly,
            APIAssembly).Build();

        protected static readonly IObjectProvider<IType> SharedKernelLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(SharedKernelAssembly).As("Shared Kernel Layer");

        protected static readonly IObjectProvider<IType> DomainLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(DomainAssembly).As("Domain Layer");

        protected static readonly IObjectProvider<IType> ApplicationLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(ApplicationAssembly).As("Application Layer");

        protected static readonly IObjectProvider<IType> PersistenceLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(PersistenceAssembly).As("Persistence Layer");

        protected static readonly IObjectProvider<IType> InfrastructureLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(InfrastructureAssembly).As("Infrastructure Layer");

        protected static readonly IObjectProvider<IType> APILayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(APIAssembly).As("API Layer");
    }
}

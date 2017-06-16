using System.Web.Http.Dependencies;
using StructureMap;

namespace PickupGames.Infrastructure.DependencyInjection {
    /// <summary>
    /// Wrapper for IDependencyResolver so that StructureMap plays nicely with built in mvc 4 dependency resolution. 
    /// </summary>
    public class StructureMapDependencyResolver : StructureMapDependencyScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.GetNestedContainer();
            return new StructureMapDependencyResolver(child);
        }
    }
}

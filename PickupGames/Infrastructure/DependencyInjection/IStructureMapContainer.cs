using StructureMap;

namespace PickupGames.Infrastructure.DependencyInjection
{
    public interface IStructureMapContainer
    {
        IContainer Initialize();
    }
}
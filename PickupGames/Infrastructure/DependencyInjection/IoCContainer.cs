using System.Web;
using PickupGames.Controllers.GameManagement;
using PickupGames.Domain.AccountManagement.Repositories;
using PickupGames.Domain.AccountManagement.Services;
using PickupGames.Domain.GameLocationManagement.Repositories;
using PickupGames.Domain.GameLocationManagement.Services;
using PickupGames.Domain.GameManagement.Repositories;
using PickupGames.Domain.GameManagement.Services;
using PickupGames.Infrastructure.Logging;
using StructureMap;

namespace PickupGames.Infrastructure.DependencyInjection
{
    public class IoCContainer : IStructureMapContainer
    {
        //private readonly ServiceSettings _serviceSettings;

        //public IoCContainer(ServiceSettings serviceSettings)
        //{
        //    _serviceSettings = serviceSettings;
        //}

        public IContainer Initialize()
        {
            using (var container = new Container(c =>
            {
                //c.For<HttpContextBase>()
                //    .HttpContextScoped()
                //    .Use(() => new HttpContextWrapper(HttpContext.Current));

                //c.For<ServiceSettings>()
                //    .Singleton()
                //    .Use(() => _serviceSettings);      

                //c.For<IDatabaseAccessor>()
                //    .Use<AdoDatabaseAccessor>()
                //    .Ctor<string>()
                //    .Is(() => _serviceSettings.AzureDbConnectionString);

                //c.For<IServiceAccessor>()
                //    .Use<HttpClientServiceAccessor>();

                c.For<IApplicationLogger>()
                    .Use<MockApplicationLogger>();

                c.For<IAuthService>()
                    .Use<AuthService>();

                c.For<IGameService>()
                    .Use<GameService>();

                c.For<IGameLocationService>()
                    .Use<GameLocationService>();

                c.For<IGamePageViewService>()
                    .Use<GamePageViewService>();

                c.For<IAuthRepository>()
                    .Use<MockAuthRepository>();

                c.For<IGameLocationRepository>()
                    .Use<GameLocationRepository>();

                c.For<IGameRepository>()
                    .Use<MockGameRepository>();

                c.For<ISportRepository>()
                    .Use<MockSportRepository>();

                //c.For<IDepartmentRepository>()
                //    .Use<DepartmentRepository>()
                //    .Ctor<string>()
                //    .Is(() => _serviceSettings.TinCansServiceUri);
            }))
            {
                return container;
            }
        }
    }
}
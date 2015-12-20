using System.Web;

namespace PickupGames.Infrastructure.DependencyInjection
{
    public class IoCContainer : IStructureMapContainer
    {
        private readonly ServiceSettings _serviceSettings;

        public IoCContainer(ServiceSettings serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }

        public IContainer Initialize()
        {
            return new Container(c =>
            {
                c.For<HttpContextBase>()
                    .HttpContextScoped()
                    .Use(() => new HttpContextWrapper(HttpContext.Current));

                c.For<ServiceSettings>()
                    .Singleton()
                    .Use(() => _serviceSettings);      

                c.For<IDatabaseAccessor>()
                    .Use<AdoDatabaseAccessor>()
                    .Ctor<string>()
                    .Is(() => _serviceSettings.AzureDbConnectionString);

                c.For<IServiceAccessor>()
                    .Use<HttpClientServiceAccessor>();

                c.For<IApplicationLogger>()
                    .Use<InternalLog4NetAdapter>();

                c.For<IRosterUploadService>()
                    .Use<RosterUploadService>();

                c.For<IRosterUploadRepository>()
                    .Use<RosterUploadRepository>();

                c.For<IRosterUploadEntryRepository>()
                    .Use<RosterUploadEntryRepository>();

                c.For<IDepartmentRepository>()
                    .Use<DepartmentRepository>()
                    .Ctor<string>()
                    .Is(() => _serviceSettings.TinCansServiceUri);

                c.For<IRoleRepository>()
                    .Use<RoleRepository>()
                    .Ctor<string>()
                    .Is(() => _serviceSettings.TinCansServiceUri);

                c.For<ITeamMemberRepository>()
                    .Use<TeamMemberRepository>()
                    .Ctor<string>()
                    .Is(() => _serviceSettings.TinCansServiceUri);

                c.For<IUserRepository>()
                    .Use<UserRepository>()
                    .Ctor<string>()
                    .Is(() => _serviceSettings.PsIdentityServiceUri);
            });
        }
    }
}
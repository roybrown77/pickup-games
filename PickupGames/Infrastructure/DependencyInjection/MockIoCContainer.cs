using System.Web;

namespace PickupGames.Infrastructure.DependencyInjection
{
    public class MockIoCContainer : IStructureMapContainer
    {
        private readonly ServiceSettings _serviceSettings;
        
        public MockIoCContainer(ServiceSettings serviceSettings)
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

                //c.For<IAuthenticationManager>()
                //    .Use(() => HttpContext.Current.GetOwinContext()
                //        .Authentication);

                //c.For<ObjectCache>()
                //    .Singleton()
                //    .Use(() => MemoryCache.Default);

                c.For<ServiceSettings>()
                    .Singleton()
                    .Use(() => _serviceSettings);
            });
        }        
    }
}
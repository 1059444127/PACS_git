using Funq;
using ServiceStack;
using CStoreService.ServiceInterface;
using CStoreService.Prossesor;
using System.Configuration;

namespace CStoreService
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyWindowService
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("CStoreService", typeof(CStoreRestService).Assembly) {
        }

        public override void OnAfterInit()
        {
            CStoreProcessor.TempFilePath = ConfigurationManager.AppSettings["TempFilePath"];
            CStoreProcessor.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            base.OnAfterInit();
        }

        public override ServiceStackHost Start(string urlBase)
        {
            CStoreProcessor.Start();
            return base.Start(urlBase);
        }


        public override void Stop()
        {
            CStoreProcessor.Stop();
            base.Stop();
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
        }
    }
}

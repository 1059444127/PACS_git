using Funq;
using ServiceStack;
using DicomDcmPicker.ServiceInterface;
using ServiceStack.Auth;
using ServiceStack.Caching;

namespace DicomDcmPicker
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyWindowService
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("DicomDcmPicker", typeof(MainProcessorServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            this.Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[]
            {
                new CustomCredentialsAuthProvider
                {
                    Provider = "customAuthProvider"
                }
            }));


            //this.Plugins.Add(new AuthFeature(() => new AuthUserSession(),
            //    new IAuthProvider[] {
            //        new BasicAuthProvider(),
            //        new CredentialsAuthProvider(),
            //    }));

            //Plugins.Add(new RegistrationFeature());

            //container.Register<ICacheClient>(new MemoryCacheClient());
            //var userRep = new InMemoryAuthRepository();
            //container.Register<IUserAuthRepository>(userRep);

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
        }
    }
}

using Ninject.Modules;

namespace Util.Core.Modules
{
    public class TaskDemoCoreModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IServicerConfigurationProvider>().To<ServicerConfigurationProvider>();
            //Bind<ISessionDataProviderFactory>().To<SessionDataProviderFactory>();
            //Bind<IPaymentDataProviderFactory>().To<PaymentDataProviderFactory>();
            //Bind<IRequestProcessorProviderFactory>().To<RequestProcessorProviderFactory>();
        }
    }
}

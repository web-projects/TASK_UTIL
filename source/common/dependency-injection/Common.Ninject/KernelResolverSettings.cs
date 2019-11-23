using Ninject.Modules;

namespace IPA5.Common.Ninject
{
    public class KernelResolverSettings
    {
        public NinjectModule[] NinjectModules { get; private set; }

        public KernelResolverSettings SetNinjectModules(params NinjectModule[] ninjectModules)
        {
            NinjectModules = ninjectModules;
            return this;
        }
    }
}

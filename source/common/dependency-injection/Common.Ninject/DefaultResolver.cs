using Ninject;
using Ninject.Modules;

namespace IPA5.Common.Ninject
{
    public sealed class DefaultResolver : IKernelModuleResolver
    {
        public IKernel ResolveKernel(params NinjectModule[] modules)
        {
            IKernel kernel = new StandardKernel(modules);
            kernel.Settings.InjectNonPublic = true;
            kernel.Settings.InjectParentPrivateProperties = true;
            return kernel;
        }
    }
}

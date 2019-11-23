using Ninject;

namespace IPA5.Common.Ninject
{
    public class KernelResolver
    {
        private static readonly KernelResolver kernelResolverInstance = new KernelResolver();
        public static KernelResolver SharedInstance => kernelResolverInstance;

        private IKernelModuleResolver kernelModuleResolver;

        private KernelResolver() { }

        public IKernel GetKernel(KernelResolverSettings resolverSettings = null)
        {
            return kernelModuleResolver.ResolveKernel(resolverSettings?.NinjectModules);
        }

        public void SetPreferredResolver(IKernelModuleResolver kernelModuleResolver)
        {
            this.kernelModuleResolver = kernelModuleResolver;
        }
    }
}

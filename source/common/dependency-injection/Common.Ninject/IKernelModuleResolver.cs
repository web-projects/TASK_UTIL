using Ninject;
using Ninject.Modules;

namespace IPA5.Common.Ninject
{
    public interface IKernelModuleResolver
    {
        IKernel ResolveKernel(params NinjectModule[] modules);
    }
}

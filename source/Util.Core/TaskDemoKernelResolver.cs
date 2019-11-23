using System.Collections.Generic;
using IPA5.Common.Ninject;
using Ninject;
using Ninject.Modules;
using Util.Core.Modules;

namespace Util.Core
{
    public class TaskDemoKernelResolver : IKernelModuleResolver
    {
        private const int NumberOfKnownModules = 1;

        public IKernel ResolveKernel(params NinjectModule[] modules)
        {
            List<NinjectModule> moduleList;

            if (modules != null && modules.Length > 0)
            {
                moduleList = new List<NinjectModule>(NumberOfKnownModules + modules.Length);
                moduleList.AddRange(modules);
            }
            else
            {
                moduleList = new List<NinjectModule>(NumberOfKnownModules);
            }

            moduleList.Add(new TaskDemoCoreModule());

            IKernel kernel = new StandardKernel(moduleList.ToArray());
            kernel.Settings.InjectNonPublic = true;
            kernel.Settings.InjectParentPrivateProperties = true;
            return kernel;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace IPA5.Common.Ninject.AspNetCore
{
    public class SelfInjectingController : ControllerBase
    {
        public SelfInjectingController()
        {
            NinjectServiceProxy.LocalKernel.Inject(this);
        }
    }
}

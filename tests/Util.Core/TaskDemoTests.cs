using System;
using Util.Core;
using Util.Core.Interface;
using Xunit;
using Moq;
using Newtonsoft.Json;
using Ninject;

namespace TaskDemoTests
{
    public class TaskDemoTests
    {
        TaskDemo subject;
        Mock<ITaskDemo> mockITaskDemo;

        public TaskDemoTests()
        {
            subject = new TaskDemo("Jonnie");

            mockITaskDemo = new Mock<ITaskDemo>();

            using (IKernel kernel = new TaskDemoKernelResolver().ResolveKernel())
            {
                //kernel.Rebind<IRequestProcessorProviderFactory>().ToConstant(mockFactory.Object);
 
                kernel.Inject(subject);
            }
        }

        [Fact]
        public void TaskDemo_ReturnsTrue_When_NameMatched()
        {
            // Arrange
            string expectedValue = "Jonnie";
            // Act
            string actualValue = subject.Name;
            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}

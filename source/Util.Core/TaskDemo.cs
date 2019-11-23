using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Util.Core.Interface;

namespace Util.Core
{
    public class TaskDemo : ITaskDemo
    {
        public string Name { get; }

        public TaskDemo(string name) => (Name) = (name);

        public async Task RunTaskDemo()
        {
            Console.WriteLine("About to launch a task...");
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000).ConfigureAwait(false);
                throw new InvalidOperationException();
            });
            await Task.Delay(5000);
            Console.WriteLine("Exiting after 5 second delay");
        }
    }
}

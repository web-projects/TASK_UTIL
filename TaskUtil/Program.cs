using System;
using System.Threading.Tasks;

namespace TaskUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTaskDemo().Wait();
        }

        private static async Task RunTaskDemo()
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

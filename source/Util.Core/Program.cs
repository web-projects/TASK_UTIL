using System;
using System.Threading.Tasks;
using Util.Core;

namespace TaskUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskDemo tasker = new TaskDemo("Jonnie");
            tasker.RunTaskDemo().Wait();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DicomDcmProcessor
{
    public static class MainProcessor
    {
        private static bool isRuning = false;
        private static TaskCompletionSource<string> taskSource;

        public static bool IsRunning { get { return isRuning; } }

        public static void Start()
        {
            isRuning = true;
            taskSource = new TaskCompletionSource<string>();
            Task.Factory.StartNew(() => {
                while (isRuning)
                {
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Thread.Sleep(1000);
                }
                taskSource.SetResult(string.Empty);
            });
            Console.WriteLine("MainProcessor Started!");
        }


        public static void Stop()
        {
            isRuning = false;
            var dummy = taskSource.Task.Result;
            Console.WriteLine("MainProcessor Stopped!");

        }
    }
}

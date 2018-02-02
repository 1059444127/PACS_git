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
        private static TaskCompletionSource<string> taskSource;
        private static CancellationTokenSource cancellationTokenSource;
        
        public string BufferFilePath { get; set; }

        public static void Start()
        {
            isRuning = true;
            taskSource = new TaskCompletionSource<string>();
            Task.Factory.StartNew(() => {
                while (cancellationTokenSource.IsCancellationRequested == false)
                {



                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Thread.Sleep(1000);
                }
                taskSource.SetResult(string.Empty);
            }, cancellationTokenSource.Token);
            Console.WriteLine("MainProcessor Started!");
        }


        public static void Stop()
        {
            cancellationTokenSource.Cancel();
            var dummy = taskSource.Task.Result;
            Console.WriteLine("MainProcessor Stopped!");

        }
    }
}

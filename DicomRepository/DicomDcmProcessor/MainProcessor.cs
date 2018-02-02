using Dicom;
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
        
        public static bool IsRunning { get { return cancellationTokenSource.IsCancellationRequested == false; } }



        public static void Start()
        {
            taskSource = new TaskCompletionSource<string>();
            Task.Factory.StartNew(() => {
                while (cancellationTokenSource.IsCancellationRequested == false)
                {
                    //var file = DicomFile.Open("G:\\testXYL.dcm");
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Thread.Sleep(1000);
                }
                taskSource.SetResult(string.Empty);
            }, cancellationTokenSource.Token);
            Console.WriteLine("MainProcessor Started!");
        }


        public static void Stop()
        {
            if (cancellationTokenSource.IsCancellationRequested == false)
                cancellationTokenSource.Cancel();
            var dummy = taskSource.Task.Result;
            Console.WriteLine("MainProcessor Stopped!");

        }
    }
}

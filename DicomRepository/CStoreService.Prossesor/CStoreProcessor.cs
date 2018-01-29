using System;
using System.IO;
using Dicom.Log;
using Dicom.Network;

namespace CStoreService.Prossesor
{
    public static class CStoreProcessor
    {
        private static bool isRunning = false;
        private static string tempFilePath = Directory.GetCurrentDirectory();
        private static int port = 12345;

        public static bool IsRunning { get { return isRunning; } internal set { isRunning = value; } }

        public static string TempFilePath { get { return tempFilePath; } set { tempFilePath = value; } }

        public static int Port { get { return port; } set { port = value; } }

        private static IDicomServer server;

        public static void Start()
        {
            isRunning = true;
            LogManager.SetImplementation(ConsoleLogManager.Instance);
            server = DicomServer.Create<DicomCStoreProvider>(port);
        }


        public static void Stop()
        {
            isRunning = false;
            Console.WriteLine("CStoreProssesor is trying to stop...");
            server.Stop();
            server.Dispose();
            Console.WriteLine("CStoreProssesor Stopped!");
        }
    }
}

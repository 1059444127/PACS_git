using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicom.Log;
using Dicom.Network;

namespace DicomCEchoSCP
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.SetImplementation(ConsoleLogManager.Instance);
            var server = DicomServer.Create<DicomCEchoProvider>(12345);
            Console.WriteLine("SERVER STARTED! PRESS ENTER TO EXIT.");
            Console.ReadLine();
        }
    }
}

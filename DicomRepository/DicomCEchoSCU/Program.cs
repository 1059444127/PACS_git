using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicom.Log;
using Dicom.Network;

namespace DicomCEchoSCU
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.SetImplementation(ConsoleLogManager.Instance);
            var client = new DicomClient();
            for (int i = 0; i < 10; i++)
            {
                client.AddRequest(new DicomCEchoRequest());
            }
            client.Send("127.0.0.1", 12345, false, "TEST_CECHO_SCU", "TEST_CECHO_SCU");
            Console.WriteLine("PRESS ENTER TO EXIT.");
            Console.ReadLine();
        }
    }
}

using Dicom.Log;
using Dicom.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomCStoreSCU
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.SetImplementation(ConsoleLogManager.Instance);
            var client = new DicomClient();
            client.AddRequest(new DicomCStoreRequest(@"DcmFiles\test.dcm"));
            client.Send("127.0.0.1", 12345, false, "TEST_CSTORE_SCU", "TEST_CSTORE_SCP");
            Console.WriteLine("PRESS ENTER TO EXIT.");
            Console.ReadLine();
        }
    }
}

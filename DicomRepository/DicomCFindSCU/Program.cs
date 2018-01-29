using Dicom.Log;
using Dicom.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomCFindSCU
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.SetImplementation(ConsoleLogManager.Instance);
            var client = new DicomClient();
            client.AddRequest(new DicomCFindRequest(DicomQueryRetrieveLevel.Image));
            client.AddRequest(new DicomCFindRequest(DicomQueryRetrieveLevel.Patient));
            client.AddRequest(new DicomCFindRequest(DicomQueryRetrieveLevel.Series));
            client.AddRequest(new DicomCFindRequest(DicomQueryRetrieveLevel.Study));
            client.AddRequest(new DicomCFindRequest(DicomQueryRetrieveLevel.Worklist));
            client.Send("127.0.0.1", 12345, false, "TEST_CFIND_SCU", "TEST_CFIND_SCP");
            Console.WriteLine("PRESS ENTER TO EXIT.");
            Console.ReadLine();
        }
    }
}

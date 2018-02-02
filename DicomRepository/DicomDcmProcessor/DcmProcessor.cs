using Dicom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomDcmProcessor
{
    public class DcmProcessor
    {
        public string BufferPath { get; set; }


        public void Foo()
        {
            var file = DicomFile.Open(BufferPath);
            foreach (var ds in file.Dataset)
            {
                System.IO.File.AppendAllText("G:\\eee.log", ds.ToDcmTag().ToJsonString()+"\r\n");
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DicomDcmProcessor;
using NUnit.Framework;

namespace DicomDcmPicker.Tests
{
    public class DcmProcessorUnitTest
    {

        [Test]
        public void FooTest()
        {
            var foo = new DcmProcessor();
            foo.BufferPath = "G:\\testXYL.dcm";
            foo.Foo();
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomDcmProcessor.Model
{
    public class DcmTag
    {
        public string Name { get; set; }
        public ushort Group { get; set; }
        public ushort Element { get; set; }
        public string ValueRepresentation { get; set; }
        public int ValueMultiplicity { get; set; }
        public string Value { get; set; }

       
    }


}

using Dicom;
using DicomDcmProcessor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomDcmProcessor
{
    public static class CommonExtensions
    {
        public static DcmTag ToDcmTag(this DicomItem dicomItem)
        {
            return new DcmTag
            {
                Element = dicomItem.Tag.Element,
                Group = dicomItem.Tag.Group,
                Name = dicomItem.Tag.DictionaryEntry.Name,
                ValueMultiplicity = dicomItem.Tag.DictionaryEntry.ValueMultiplicity.Multiplicity,
                ValueRepresentation = dicomItem.ValueRepresentation.Code,
                Value = ((DicomStringElement)dicomItem).Encoding.GetString(((DicomElement)dicomItem).Buffer.Data)

            };
        }


        public static string ToJsonString(this DcmTag dcmTag)
        {
            return JsonConvert.SerializeObject(dcmTag);
        }


    }
}

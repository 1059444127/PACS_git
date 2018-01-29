using ServiceStack;

namespace DicomDcmPicker.ServiceModel
{

    [Route("/MainProcessor", "GET")]
    public class MainProcessorStatus : IReturn<MainProcessorResponse>
    {

    }
    

    [Route("/MainProcessor","POST")]
    public class MainProcessorOperation : IReturn<MainProcessorResponse>
    {
        public string Operation { get; set; }
    }

    public class MainProcessorResponse
    {
        public string Result { get; set; }
    }
}

using ServiceStack;
using DicomDcmPicker.ServiceModel;

namespace DicomDcmPicker.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
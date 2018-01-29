using ServiceStack;
using DicomDcmPicker.ServiceModel;
using DicomDcmProcessor;

namespace DicomDcmPicker.ServiceInterface
{
    public class MainProcessorServices:Service
    {
        [Authenticate("customAuthProvider",ApplyTo = ApplyTo.Get)]
        public object GET(MainProcessorStatus request)
        {
            return new MainProcessorResponse { Result = MainProcessor.IsRunning.ToString() };
        }

        
        public object POST(MainProcessorOperation request)
        {
            if (request.Operation.ToUpper() == "STOP")
            {
                if (MainProcessor.IsRunning == false)
                {
                    return new MainProcessorResponse { Result = $"Processor Is Not Running!" };
                }
                MainProcessor.Stop();
                return new MainProcessorResponse { Result = $"Processor Stopped!" };
            }
            else if (request.Operation.ToUpper() == "START")
            {
                if (MainProcessor.IsRunning == true)
                {
                    return new MainProcessorResponse { Result = $"Processor Has been already Runned!" };
                }
                MainProcessor.Start();
                return new MainProcessorResponse { Result = $"Processor Started!" };
            }
            return new MainProcessorResponse { Result = $"Invalid Operation!" };
        }
    }
}

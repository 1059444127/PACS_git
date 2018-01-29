using ServiceStack;
using CStoreService.ServiceModel;
using CStoreService.Prossesor;

namespace CStoreService.ServiceInterface
{
    public class CStoreRestService : Service
    {
        public object GET(CurrentStatusGetRequest request)
        {
            return new CurrentStatusResponse { CurrentStatus = CStoreProcessor.IsRunning ? "Running" : "Ready" };
        }

        public object POST(ServiceOperations request)
        {
            if (request.Operation == OperationType.Start)
            {
                if (CStoreProcessor.IsRunning)
                {
                    return new OperationResult { Message = "Cannot start CStoreProcessor when it is running!",IsSuccess=false };
                }
                CStoreProcessor.Start();
                return new OperationResult { Message = "CStoreProcessor is started successfully", IsSuccess = true };
            }
            if (request.Operation == OperationType.Stop)
            {
                if (CStoreProcessor.IsRunning==false)
                {
                    return new OperationResult { Message = "Cannot stop CStoreProcessor when it has been stopped!", IsSuccess = false };
                }
                CStoreProcessor.Stop();
                return new OperationResult { Message = "CStoreProcessor is stopped successfully", IsSuccess = true };
            }
            return new OperationResult { Message = "Invalid Operation Type", IsSuccess = false };
        }
    }
}
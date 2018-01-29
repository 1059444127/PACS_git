using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CStoreService.ServiceModel
{
    [Route("/Operation","POST")]
    public class ServiceOperations:IReturn<OperationResult>
    {
        public OperationType Operation { get; set; }

    }


    public enum OperationType
    {
        Start = 1,
        Stop = 2
    }



    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ResultJson { get; set; }
    }

}

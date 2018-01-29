using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CStoreService.ServiceModel
{
    [Route("/CurrentStatus","GET")]
    public class CurrentStatusGetRequest:IReturn<CurrentStatusResponse>
    {
    }


    public class CurrentStatusResponse
    {
        public string CurrentStatus { get; set; }
    }
}

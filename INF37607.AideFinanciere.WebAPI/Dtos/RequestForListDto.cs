using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class RequestForListDto
    {
        public string Id { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime OrderDate { get; set; }
       public  decimal OrderTotal { get; set; }
    }
}

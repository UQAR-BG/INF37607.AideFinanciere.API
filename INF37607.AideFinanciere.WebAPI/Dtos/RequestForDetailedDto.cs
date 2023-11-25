using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class RequestForDetailedDto
    {
        public string Id { get; set; }
        public bool IsSubmitted { get; set; }
        DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<RequestItemForDetailedDto> RequestItems { get; set; }
        //public UserForDetailedDto User { get; set; }
    }
}

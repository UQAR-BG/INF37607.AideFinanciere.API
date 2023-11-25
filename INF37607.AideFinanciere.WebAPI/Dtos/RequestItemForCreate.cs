using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class RequestItemForCreateDto
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

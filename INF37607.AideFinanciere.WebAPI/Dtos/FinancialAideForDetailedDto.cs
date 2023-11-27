using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class FinancialForDetailedDto
    {
        public DateOnly PaymentDate { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }

    }
}

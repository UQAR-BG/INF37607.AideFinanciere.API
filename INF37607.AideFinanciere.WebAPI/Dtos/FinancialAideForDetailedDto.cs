using System;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class FinancialAideForDetailedDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }
    }
}

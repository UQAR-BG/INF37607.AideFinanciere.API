using System;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Core
{
    public class FinancialAide : BaseEntity, IAggregateRoot
    {
        public DateTime PaymentDate { get; set; }
        public FinancialAideType Type { get; set; }
        public float Amount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public FinancialAide()
        {
            // exigé par EF
        }

        public FinancialAide(DateTime paymentDate, FinancialAideType type, float amount, int userId)
        {
            PaymentDate = paymentDate;
            Type = type;
            Amount = amount;
            UserId = userId;    
        }
    }
}

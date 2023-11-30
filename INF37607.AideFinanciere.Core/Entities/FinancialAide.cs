using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EAISolutionFrontEnd.Core
{
    public class FinancialAide : BaseEntity, IAggregateRoot
    {
        public DateOnly PaymentDate { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public FinancialAide()
        {
            // exigé par EF
        }

        public FinancialAide(DateOnly paymentDate, string type, float amount, int userId)
        {
            PaymentDate = paymentDate;
            Type = type;
            Amount = amount;
            UserId = userId;    
        }
    }
}

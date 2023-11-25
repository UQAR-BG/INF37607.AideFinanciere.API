using System;
using System.Collections.Generic;
using System.Text;
using EAISolutionFrontEnd.SharedKernel;

namespace EAISolutionFrontEnd.Core
{
    public class RequestItem : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice()
        {
            return UnitPrice * Quantity;
        }
        public RequestItem()
        {
            // exigé par EF
        }

        public RequestItem(string description, int quantity, decimal unitPrice)
        {
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}

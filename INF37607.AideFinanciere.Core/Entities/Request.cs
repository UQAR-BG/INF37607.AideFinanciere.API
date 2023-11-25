using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;

namespace EAISolutionFrontEnd.Core
{
    public class Request : BaseEntity, IAggregateRoot
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public bool IsSubmitted { get; set; } = false;
        public virtual List<RequestItem> RequestItems { get; private set; } = new List<RequestItem>();

        [NotMapped]
        public decimal Total { get; set; } = 0;
        public decimal OrderTotal()
        {
            var total = 0m;
            foreach (var requestItem in RequestItems)
            {
                total += requestItem.TotalPrice();
            }
            return total;
        }
        public User User { get; set; }

        public Request()
        {
            // exigé par EF
        }
        public Request(User user)
        {
            User = user;
        }

        public void AddRequestItem(RequestItem requestItem)
        {
            RequestItems.Add(requestItem);
        }

        public void RemoveRequestItem(RequestItem requestItem)
        {
            RequestItems.Remove(requestItem);
        }

        public Dictionary<int, RequestItem> GetRequestItemsDictionary()
        {

            var requestItemsDictionary = new Dictionary<int, RequestItem>();
            foreach (var requestItem in RequestItems)
            {
                requestItemsDictionary.Add(requestItem.Id, requestItem);
            }

            return requestItemsDictionary;
        }
    }
}

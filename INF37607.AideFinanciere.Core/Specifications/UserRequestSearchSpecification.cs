using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace EAISolutionFrontEnd.Core.Specifications
{
    public class UserRequestSearchSpecification : BaseSpecification<Request>
    {
        public UserRequestSearchSpecification(int? userId, string search, int item, int nbItem) :
          base(BuildCriteria(userId, search))
        {
            ApplyPaging(item, nbItem);
            ApplyOrderBy(x => x.OrderDate);
        }

        protected static Expression<Func<Request, bool>> BuildCriteria(int? userId, string search)
        {
            Expression<Func<Request, bool>> criteria = PredicateBuilder.True<Request>();

            if (userId != null)
            {
                criteria = PredicateBuilder.And<Request>(criteria, x => x.User.Id == userId);
            }

            if (search != null)
            {
                foreach (string word in search.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                {
                    criteria = PredicateBuilder.And<Request>(criteria, x => x.User.LastName.Contains(word) || x.User.FirstName.Contains(word));
                }
            }

            return criteria;
        }

    }
}

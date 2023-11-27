using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string PermanentCode { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CorrespondenceAddress { get; set; }

    }
}

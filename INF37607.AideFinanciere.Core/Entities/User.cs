using System;
using System.Collections.Generic;
using System.Text;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EAISolutionFrontEnd.Core
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PermanentCode { get; set; } = string.Empty;
        public string SocialInsuranceNumber { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CorrespondenceAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public User()
        {
            // exigé par EF
        }

        public User(string firstName, string lastName, string phoneNumber, string correspondenceAddress, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            CorrespondenceAddress = correspondenceAddress;
            Email = email;
        }
        public User(string socialInsuranceNumber, string password, string permanentCode)
        {
            SocialInsuranceNumber = socialInsuranceNumber;
            Password = password;
            PermanentCode = permanentCode;
        }

        public User(string socialInsuranceNumber, string password, string permanentCode, string password1) : this(socialInsuranceNumber, password, permanentCode)
        {
        }
    }
}

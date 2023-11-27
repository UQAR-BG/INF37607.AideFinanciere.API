using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;

namespace EAISolutionFrontEnd.Core
{
    public class Request : BaseEntity, IAggregateRoot
    {
        public User User { get; set; }

        public string Email { get; set; } = string.Empty;
        public string CorrespondenceAddress { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string ImmigrationCode { get; set; } = string.Empty;
        public DateOnly DateStatus { get; set; }
        public string Language { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public string InstitutionCode { get; set; } = string.Empty;
        public string ProgrammeCode { get; set; } = string.Empty;
        public int CreditsNumbers { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateOnly StatusStartingDate { get; set; }
        public float TotalGrossIncome { get; set; }
        public Request()
        {
            // exigé par EF
        }

        public Request(User user, string email, string correspondenceAddress, string citizenship, 
            string immigrationCode, DateOnly dateStatus, string language, string institutionName,
            string institutionCode, string programmeCode, int creditsNumbers, string status,
             DateOnly statusStartingDate, float totalGrossIncome)
        {
            User = user;
            Email = email;
            CorrespondenceAddress = correspondenceAddress;
            Citizenship = citizenship;
            ImmigrationCode = immigrationCode;
            DateStatus = dateStatus;
            Language = language;
            InstitutionName = institutionName;
            InstitutionCode = institutionCode;
            ProgrammeCode = programmeCode;
            CreditsNumbers = creditsNumbers;
            Status = status;
            StatusStartingDate = statusStartingDate;
            TotalGrossIncome = totalGrossIncome;
        }
    }
}

using System;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Core
{
    public class Request : BaseEntity, IAggregateRoot
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string Email { get; set; } = string.Empty;
        public string CorrespondenceAddress { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string ImmigrationCode { get; set; } = string.Empty;
        public DateTime DateStatus { get; set; }
        public string Language { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public string InstitutionCode { get; set; } = string.Empty;
        public string ProgrammeCode { get; set; } = string.Empty;
        public int CreditsNumbers { get; set; }
        public FinancialAideStatus Status { get; set; } = FinancialAideStatus.Pending;
        public DateTime StatusStartingDate { get; set; }
        public float TotalGrossIncome { get; set; }
        public Request()
        {
            // exigé par EF
        }

        public Request(int userId, string email, string correspondenceAddress, string citizenship, 
            string immigrationCode, DateTime dateStatus, string language, string institutionName,
            string institutionCode, string programmeCode, int creditsNumbers, FinancialAideStatus status,
            DateTime statusStartingDate, float totalGrossIncome)
        {
            UserId = userId;
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

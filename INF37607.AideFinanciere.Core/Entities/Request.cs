﻿using System;
using EAISolutionFrontEnd.SharedKernel;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Core
{
    public class Request : BaseEntity, IAggregateRoot
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int? FinancialAidId { get; set; }
        public FinancialAide FinancialAid { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string SecondPhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CorrespondenceAddress { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string ImmigrationCode { get; set; } = string.Empty;
        public DateTime DateStatus { get; set; }
        public string Language { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public string InstitutionCode { get; set; } = string.Empty;
        public string ProgrammeCode { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public int CreditsNumbers { get; set; }
        public FinancialAideStatus Status { get; set; } = FinancialAideStatus.Pending;
        public DateTime StatusStartingDate { get; set; }
        public double TotalGrossIncome { get; set; }
        public Request()
        {
            // exigé par EF
        }

        public Request(int userId, int financialAidId, string email, string phoneNumber, string secondPhoneNumber, string correspondenceAddress, string citizenship, 
            string immigrationCode, DateTime dateStatus, string language, string institutionName,
            string institutionCode, string programmeCode, int creditsNumbers, string maritalStatus, FinancialAideStatus status,
            DateTime statusStartingDate, double totalGrossIncome)
        {
            UserId = userId;
            FinancialAidId = financialAidId;
            Email = email;
            PhoneNumber = phoneNumber;
            SecondPhoneNumber = secondPhoneNumber;
            CorrespondenceAddress = correspondenceAddress;
            Citizenship = citizenship;
            ImmigrationCode = immigrationCode;
            DateStatus = dateStatus;
            Language = language;
            InstitutionName = institutionName;
            InstitutionCode = institutionCode;
            ProgrammeCode = programmeCode;
            CreditsNumbers = creditsNumbers;
            MaritalStatus = maritalStatus;
            Status = status;
            StatusStartingDate = statusStartingDate;
            TotalGrossIncome = totalGrossIncome;
        }

    }
}

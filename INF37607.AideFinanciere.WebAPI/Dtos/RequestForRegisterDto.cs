using System;
using System.ComponentModel.DataAnnotations;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class RequestForRegistereDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SecondPhoneNumber { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string Citizenship { get; set; }
        public string ImmigrationCode { get; set; }
        public DateTime DateStatus { get; set; }
        public string Language { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionCode { get; set; }
        public string ProgrammeCode { get; set; }
        public int CreditsNumbers { get; set; }
        public string MaritalStatus { get; set; }
        public string Status { get; set; }
        public DateTime StatusStartingDate { get; set; }
        public float TotalGrossIncome { get; set; }
    }
}

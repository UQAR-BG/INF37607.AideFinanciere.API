using System;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class RequestForDetailedDto
    {
        public string Email { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string Citizenship { get; set; }
        public string ImmigrationCode { get; set; }
        public DateTime DateStatus { get; set; }
        public string Language { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionCode { get; set; }
        public string ProgrammeCode { get; set; }
        public int CreditsNumbers { get; set; }
        public string Status { get; set; }
        public DateTime StatusStartingDate { get; set; }
        public float TotalGrossIncome { get; set; }

    }
}

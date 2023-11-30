using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class RequestForRegistereDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string Citizenship { get; set; }
        public string ImmigrationCode { get; set; }
        public DateOnly DateStatus { get; set; }
        public string Language { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionCode { get; set; }
        public string ProgrammeCode { get; set; }
        public int CreditsNumbers { get; set; }
        public string Status { get; set; }
        public DateOnly StatusStartingDate { get; set; }
        public float TotalGrossIncome { get; set; }

    }
}

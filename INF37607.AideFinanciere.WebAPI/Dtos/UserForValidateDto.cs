using System;
using System.ComponentModel.DataAnnotations;

namespace EAISolutionFrontEnd.WebAPI.Dtos;

public class UserForValidateDto
{
    [Required]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "Vous devez spécifier le bon format de votre numéro d'assurance social")]
    public string SocialInsuranceNumber { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
}
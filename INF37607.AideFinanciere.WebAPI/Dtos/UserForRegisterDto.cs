using System;
using System.ComponentModel.DataAnnotations;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Vous devez spécifier le bon format de votre numéro d'assurance social")]
        public string SocialInsuranceNumber { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Vous devez spécifier un mot de passe entre 4 et 8 caractères")]
        public string Password { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

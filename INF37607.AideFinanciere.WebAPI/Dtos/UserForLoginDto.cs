using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.WebAPI.Dtos
{
    public class UserForLoginDto
    {
        public string CodePermanent { get; set; }
        public string Password { get; set; }
    }
}

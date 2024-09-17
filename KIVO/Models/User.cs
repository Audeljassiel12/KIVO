using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KIVO.Models
{
    public class User:IdentityUser
    {
        public Paciente? Paciente{ get; set; }

        public Medico? Medico{ get; set; }
        public string VerificationCode {get;set;} = null!;
           public DateTime? VerificationCodeExpiry { get; set; }
    }
}
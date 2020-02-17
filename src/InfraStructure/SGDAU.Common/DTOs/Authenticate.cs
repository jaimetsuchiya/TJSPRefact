using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGDAU.Common
{
    public class Authenticate
    {
        public class Request
        {
            [Display(Name = "ID Cliente")]
            [Required]
            public string ClientId { get; set; }

            [Display(Name = "Login")]
            [Required]
            public string Login { get; set; }

            [Display(Name = "Senha")]
            [Required]
            public string Password { get; set; }
        }

        public class Response
        {
            public JwtData UserData { get; set; }

            public string Token { get; set; }
        }
    }

    public class ChangePassword
    {
        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }


        [Display(Name = "Senha Atual")]
        [Required]
        public string CurrentPassword { get; set; }


        [Display(Name = "Nova Senha")]
        [Required]
        public string NewPassword { get; set; }


        [Display(Name = "Confirmação de Senha")]
        [Required]
        public string PasswordConfirmation { get; set; }

    }

    public class ForgotPassword
    {
        [Display(Name = "E-mail")]
        [EmailAddress()]
        [Required]
        public string Email { get; set; }

        [Display(Name = "CPF")]
        [Required]
        public string CPF { get; set; }
    }

}

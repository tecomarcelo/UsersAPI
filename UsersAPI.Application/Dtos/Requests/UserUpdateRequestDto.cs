using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Application.Dtos.Requests
{
    public class UserUpdateRequestDto
    {
        [Required(ErrorMessage = "Informe o seu nome completo.")]
        [MinLength(8, ErrorMessage = "Informe o nome com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe o nome com no máximo {1} caracteres.")]
        public string? Name { get; set; }
    }
}

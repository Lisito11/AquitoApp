using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AquitoApi.Entities.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El username es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 digitos.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role no fue suministrado.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "El nombre no fue suministrado.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "El apellido no fue suministrado.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Phone es requerido.")]
        [Phone(ErrorMessage ="Phone no es valido")]
        public string Phone { get; set; }
        public int Status { get; set; }


    }
}

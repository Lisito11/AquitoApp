

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquitoWebApp.Entities.ViewModels
{
    public class UserAuthViewModel
    {
        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un correo electronico valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El contraseña es requerida.")]
        public string Password { get; set; }
    }
}
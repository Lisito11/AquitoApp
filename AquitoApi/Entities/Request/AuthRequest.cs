using System.ComponentModel.DataAnnotations;

namespace PasantesBackendApi.Models.Request
{
    public class AuthRequest
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Email no valido enviado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

    }
}

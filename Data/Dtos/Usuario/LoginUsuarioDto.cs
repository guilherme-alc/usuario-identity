using System.ComponentModel.DataAnnotations;

namespace UsuarioIdentity.Data.Dtos.Usuario
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

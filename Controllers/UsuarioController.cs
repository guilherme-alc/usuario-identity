using Microsoft.AspNetCore.Mvc;
using UsuarioIdentity.Data.Dtos.Usuario;

namespace UsuarioIdentity.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController
{
    [HttpGet]
    public IEnumerable<ReadUsuarioDto> RecuperaUsuarios() 
    {
        
    }
    [HttpPost]
    public IActionResult CadastraUsuario(CreateUsuarioDto dto)
    {

    }
}

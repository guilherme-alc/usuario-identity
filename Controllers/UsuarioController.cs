using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioIdentity.Data.Dtos.Usuario;
using UsuarioIdentity.Models;
using UsuarioIdentity.Services;

namespace UsuarioIdentity.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    public UsuarioController(CadastroService cadastroService)
    {
         _cadastroService = cadastroService;
    }

    private CadastroService _cadastroService;

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _cadastroService.Cadastra(dto);
        return Ok("Usuário cadastrado com sucesso!");
    }
}

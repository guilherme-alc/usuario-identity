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
    public UsuarioController(UsuarioService cadastroService)
    {
         _usuarioService = cadastroService;
    }

    private UsuarioService _usuarioService;

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastra(dto);
        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }
}

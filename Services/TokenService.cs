using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioIdentity.Models;

namespace UsuarioIdentity.Services;

public class TokenService
{
    internal void GenerateToken(Usuario usuario)
    {

        Claim[] claims = new Claim[]
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASD91U9DJDASODI02FHDT"));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );
    }
}
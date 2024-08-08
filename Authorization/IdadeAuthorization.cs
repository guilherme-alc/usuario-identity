using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuarioIdentity.Authorization;
public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var dataDeNascimentoClaim = context.User.FindFirst(claim =>
            claim.Type == ClaimTypes.DateOfBirth);

        if(dataDeNascimentoClaim is null) 
            return Task.CompletedTask;

        var dataDeNascimento = Convert.ToDateTime(dataDeNascimentoClaim.Value);

        var idadeUsuario = DateTime.Today.Year - dataDeNascimento.Year;

        if (dataDeNascimento > DateTime.Today.AddYears(-idadeUsuario))
            idadeUsuario--;

        if (idadeUsuario > requirement.Idade)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}

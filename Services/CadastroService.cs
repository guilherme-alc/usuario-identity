using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioIdentity.Data.Dtos.Usuario;
using UsuarioIdentity.Models;

namespace UsuarioIdentity.Services
{
    public class CadastroService
    {
        public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

            if (result.Errors.Any())
                throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }
}

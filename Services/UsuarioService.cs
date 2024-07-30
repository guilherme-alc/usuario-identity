using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioIdentity.Data.Dtos.Usuario;
using UsuarioIdentity.Models;

namespace UsuarioIdentity.Services
{
    public class UsuarioService
    {
        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

            if (result.Errors.Any())
                throw new ApplicationException("Falha ao cadastrar usuário!");
        }
        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!result.Succeeded)
                throw new ApplicationException("Usuário não autenticado!");

            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}

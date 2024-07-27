using AutoMapper;
using UsuarioIdentity.Data.Dtos.Usuario;
using UsuarioIdentity.Models;

namespace UsuarioIdentity.Profiles;

public class UsuarioProfiler : Profile
{
    public UsuarioProfiler()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}

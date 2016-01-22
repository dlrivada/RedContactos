using System.Threading.Tasks;
using ContactosModel.Model;

namespace RedContactos.Service
{
    public interface IServicioMovil
    {
        Task<Usuario> ValidarUsuario(Usuario usuario);
        Task<bool> UsuarioNuevo(string login);
        Task<Usuario> AddUsuario(Usuario usuario);
    }
}
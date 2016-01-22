using System;
using System.Threading.Tasks;
using ContactosModel.Model;
using RedContactos.Util;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace RedContactos.Service
{
    public class ServiciosDatos : IServicioMovil, IDisposable
    {
        private readonly RestClient _client;

        public ServiciosDatos()
        {
            _client = new RestClient(Cadenas.Url);
        }

        public async Task<Usuario> ValidarUsuario(Usuario usuario)
        {
            RestRequest request = new RestRequest("Usuario") {Method = Method.GET};
            request.AddQueryParameter("login", usuario.Login);
            request.AddQueryParameter("password", usuario.Password);
            IRestResponse<Usuario> response = await _client.Execute<Usuario>(request);
            return response.IsSuccess ? response.Data : null;
        }

        public async Task<bool> UsuarioNuevo(string login)
        {
            RestRequest request = new RestRequest("Usuario") { Method = Method.GET };
            request.AddQueryParameter("login", login);
            IRestResponse<bool> response = await _client.Execute<bool>(request);
            return response.IsSuccess && response.Data;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            RestRequest request = new RestRequest("Usuario") { Method = Method.POST };
            request.AddJsonBody(usuario);
            IRestResponse<Usuario> response = await _client.Execute<Usuario>(request);
            return response.IsSuccess ? response.Data : null;
        }

        public void Dispose() 
        {
            _client.Dispose();
        }
    }
}
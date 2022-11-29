using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationPWARest.Context;
using WebApplicationPWARest.DTO;
using WebApplicationPWARest.Modelos;
using WebApplicationPWARest.Repositorios;

namespace WebApplicationPWARest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        RPUsuarios rpCli;

        private readonly ConexionSQL context;
        public LoginController(ConexionSQL context)
        {
            this.context = context;
            rpCli = new RPUsuarios(context);
        }
        [HttpGet("Get")]
        public Usuarios GetUsuariosCredentials(string usuario, string contraseña)
        {
            return rpCli.ObtenerCredenciales(usuario, contraseña); ;
        }
    
    }
}

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
    public class UsuarioController : ControllerBase
    {
        RPUsuarios rpCli;

        private readonly ConexionSQL context;
        public UsuarioController(ConexionSQL context)
        {
            this.context = context;
            rpCli = new RPUsuarios(context);
        }


        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(rpCli.ObtenerClientes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliRet = rpCli.ObtenerCliente(id);

            if (cliRet == null)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("Agregar")]
        public IActionResult Agregar(Usuarios nuevoCliente)
        {
            rpCli.Agregar(nuevoCliente);
            return CreatedAtAction(nameof(Agregar), nuevoCliente);
        }
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(int id,UsuariosDTO nuevoCliente)
        {
            var Respuesta = rpCli.Actualizar(id,nuevoCliente);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(nuevoCliente);
        }
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int Id)
        {
            bool Respuesta = rpCli.Delete(Id);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + Id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(true);
        }
    }
}

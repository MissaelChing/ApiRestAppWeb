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
    public class CheckController : ControllerBase
    {
        RPCheck rpCheck;

        private readonly ConexionSQL context;
        public CheckController(ConexionSQL context)
        {
            this.context = context;
            rpCheck = new RPCheck(context);
        }


        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(rpCheck.ObtenerChecks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliRet = rpCheck.ObtenerCheck(id);

            if (cliRet == null)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("Agregar")]
        public IActionResult Agregar(Check check)
        {
            rpCheck.Agregar(check);
            return CreatedAtAction(nameof(Agregar), check);
        }
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(int id, CheckDTO check)
        {
            var Respuesta = rpCheck.Actualizar(id, check);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(check);
        }
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int Id)
        {
            bool Respuesta = rpCheck.Delete(Id);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + Id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(true);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using WebApplicationPWARest.Context;
using WebApplicationPWARest.DTO;
using WebApplicationPWARest.Modelos;
using WebApplicationPWARest.Repositorios;

namespace WebApplicationPWARest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        RPHorario rpHorarios;

        private readonly ConexionSQL context;
        public HorariosController(ConexionSQL context)
        {
            this.context = context;
            rpHorarios = new RPHorario(context);
        }


        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(rpHorarios.ObtenerHorarios());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliRet = rpHorarios.ObtenerHorario(id);

            if (cliRet == null)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("Agregar")]
        public IActionResult Agregar(Horarios check)
        {
            rpHorarios.Agregar(check);
            return CreatedAtAction(nameof(Agregar), check);
        }
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(int id, HorariosDTO horarios)
        {
            var Respuesta = rpHorarios.Actualizar(id, horarios);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe o no se pudo eliminar.");
                //throw new Response(HttpStatusCode.Created, 'dd');
                return nf;
            }
            return Ok(horarios);
        }
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int Id)
        {
            bool Respuesta = rpHorarios.Delete(Id);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + Id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(true);
        }
    }
}

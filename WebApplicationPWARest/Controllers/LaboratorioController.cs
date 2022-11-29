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
    public class LaboratorioController : ControllerBase
    {
        RPLaboratorio rpLaboratorio;

        private readonly ConexionSQL context;
        public LaboratorioController(ConexionSQL context)
        {
            this.context = context;
            rpLaboratorio = new RPLaboratorio(context);
        }


        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(rpLaboratorio.ObtenerLaboratorios());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliRet = rpLaboratorio.ObtenerLaboratorio(id);

            if (cliRet == null)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("Agregar")]
        public IActionResult Agregar(Laboratorios check)
        {
            rpLaboratorio.Agregar(check);
            return CreatedAtAction(nameof(Agregar), check);
        }
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(int id, LaboratoriosDTO horarios)
        {
            var Respuesta = rpLaboratorio.Actualizar(id, horarios);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(horarios);
        }
        [HttpDelete("Eliminar")]
        public IActionResult Delete(int Id)
        {
            bool Respuesta = rpLaboratorio.Delete(Id);
            if (Respuesta == false)
            {
                var nf = NotFound("El Usuario " + Id.ToString() + " no existe o no se pudo eliminar.");
                return nf;
            }
            return Ok(true);
        }
    }
}

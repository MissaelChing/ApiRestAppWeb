using WebApplicationPWARest.Context;
using WebApplicationPWARest.DTO;
using WebApplicationPWARest.Modelos;

namespace WebApplicationPWARest.Repositorios
{
    public class RPHorario
    {
        private readonly ConexionSQL context;
        public RPHorario(ConexionSQL context)
        {
            this.context = context;

        }
        public IEnumerable<Horarios> ObtenerHorarios()
        {
            return context.Horarios.ToList();
        }

        public Check ObtenerHorario(int id)
        {
            var Horarios = context.Check.Where(cli => cli.id == id);

            return Horarios.FirstOrDefault();
        }

        public bool Agregar(Horarios horarios)
        {
            context.Horarios.Add(horarios);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var Us = context.Horarios.Find(id);
            if (Us == null)
            {
                return false;
            }
            context.Horarios.Remove(Us);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
        public bool Actualizar(int id, HorariosDTO horariosDTO)
        {
            Horarios horarios = new Horarios();
            var Us = context.Horarios.Find(id);
            context.ChangeTracker.Clear();
            horarios.id = id;
            horarios.hora = horariosDTO.hora;
            horarios.user_id = horariosDTO.user_id;
            horarios.dia = horariosDTO.dia;
            horarios.clave_laboratorio = horariosDTO.clave_laboratorio;
            horarios.materia = horariosDTO.materia;
            if (Us == null)
            {
                return false;
            }
            context.Horarios.Update(horarios);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
    }
}

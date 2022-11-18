using WebApplicationPWARest.Context;
using WebApplicationPWARest.DTO;
using WebApplicationPWARest.Modelos;

namespace WebApplicationPWARest.Repositorios
{
    public class RPCheck
    {
        private readonly ConexionSQL context;
        public RPCheck(ConexionSQL context)
        {
            this.context = context;

        }
        public IEnumerable<Check> ObtenerChecks()
        {
            return context.Check.ToList();
        }

        public Check ObtenerCheck(int id)
        {
            var Usuarios = context.Check.Where(cli => cli.id == id);

            return Usuarios.FirstOrDefault();
        }

        public bool Agregar(Check nuevoCliente)
        {
            context.Check.Add(nuevoCliente);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var Us = context.Check.Find(id);
            if (Us == null)
            {
                return false;
            }
            context.Check.Remove(Us);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
        public bool Actualizar(int id, CheckDTO checkDTO)
        {
            Check check = new Check();
            var Us = context.Check.Find(id);
            context.ChangeTracker.Clear();
            check.id = id;
            check.hora_entrada = checkDTO.hora_entrada;
            check.hora_salida = checkDTO.hora_salida;
            check.user_id = checkDTO.user_id;
            check.clave_lab = checkDTO.clave_lab;
            check.status = checkDTO.status;
            if (Us == null)
            {
                return false;
            }
            context.Check.Update(check);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
    }
}


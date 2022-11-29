using WebApplicationPWARest.Context;
using WebApplicationPWARest.DTO;
using WebApplicationPWARest.Modelos;

namespace WebApplicationPWARest.Repositorios
{
    public class RPLaboratorio
    {
        private readonly ConexionSQL context;
        public RPLaboratorio(ConexionSQL context)
        {
            this.context = context;
        }
        public IEnumerable<Laboratorios> ObtenerLaboratorios()
        {
            return context.Laboratorios.ToList();
        }

        public Laboratorios ObtenerLaboratorio(int id)
        {
            var Laboratorios = context.Laboratorios.Where(cli => cli.id == id);

            return Laboratorios.FirstOrDefault();
        }

        public bool Agregar(Laboratorios laboratorios)
        {
            context.Laboratorios.Add(laboratorios);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var Us = context.Laboratorios.Find(id);
            if (Us == null)
            {
                return false;
            }
            context.Laboratorios.Remove(Us);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
        public bool Actualizar(int id, LaboratoriosDTO laboratoriosdto)
        {
            Laboratorios laboratorios = new Laboratorios();
            var Us = context.Laboratorios.Find(id);
            context.ChangeTracker.Clear();
            laboratorios.id = id;
            laboratorios.edificio = laboratoriosdto.edificio;
            laboratorios.clave = laboratoriosdto.clave;
            laboratorios.status = laboratoriosdto.status;
            laboratorios.numero = laboratoriosdto.numero;
            laboratorios.status = laboratoriosdto.status;
            if (Us == null)
            {
                return false;
            }
            context.Laboratorios.Update(laboratorios);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
    }
}

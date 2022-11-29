using System.Linq;
using WebApplicationPWARest.Context;
using WebApplicationPWARest.DTO;
using WebApplicationPWARest.Modelos;

namespace WebApplicationPWARest.Repositorios
{
    public class RPUsuarios
    {
        private readonly ConexionSQL context;
        public RPUsuarios(ConexionSQL context)
        {
            this.context = context;

        }
        public IEnumerable<Usuarios> ObtenerClientes()
        {
            return context.Usuarios.ToList();
        }

        public Usuarios ObtenerCliente(int id)
        {
            var Usuarios = context.Usuarios.Where(cli => cli.id == id);

            return Usuarios.FirstOrDefault();
        }
        public Usuarios ObtenerCredenciales(string usuario, string contraseña)
        {
            var UsuarioEncontrado = context.Usuarios.Where(x => x.usuario == usuario && x.contraseña == contraseña);
            return UsuarioEncontrado.FirstOrDefault(); 
        }

        public bool Agregar(Usuarios nuevoCliente)
        {
            context.Usuarios.Add(nuevoCliente);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var Us = context.Usuarios.Find(id);
            if (Us == null)
            {
                return false;
            }
            context.Usuarios.Remove(Us);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
        public bool Actualizar(int id, UsuariosDTO usuariosdto)
        {
            Usuarios usuarios = new Usuarios();
             var Us = context.Usuarios.Find(id);
            context.ChangeTracker.Clear();
            usuarios.id = id;
            usuarios.apellidomaterno = usuariosdto.apellidomaterno;
            usuarios.apellidopaterno = usuariosdto.apellidopaterno;
            usuarios.nombre = usuariosdto.nombre;
            usuarios.segundonombre = usuariosdto.segundonombre;
            usuarios.usuario = usuariosdto.usuario;
            usuarios.contraseña = usuariosdto.contraseña;

            if (Us == null)
            {
                return false;
            }
            context.Usuarios.Update(usuarios);
            var result = context.SaveChanges();
            if (result < 0)
            {
                return false;
            }
            return true;
        }
    }
}
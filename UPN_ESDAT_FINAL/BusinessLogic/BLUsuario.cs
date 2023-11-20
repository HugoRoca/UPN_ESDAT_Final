using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLUsuario
    {
        private readonly string nombreArchivo = "Usuario";
        private readonly string nombreArchivoRol = "Rol";
        private readonly DataAccess<UsuarioModel> dataUsuario;
        private readonly DataAccess<RolModel> dataRol;

        public BLUsuario()
        {
            dataUsuario = new DataAccess<UsuarioModel>(nombreArchivo);
            dataRol = new DataAccess<RolModel>(nombreArchivoRol);
        }

        public bool Login(string username, string password)
        {
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            if (usuarios.Count == 0) return false;

            return usuarios.Where(x => x.Usuario.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).Any();
        }

        public UsuarioModel ObtenerUsuario(string username, string password)
        {
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            if (usuarios.Count == 0) return new UsuarioModel();

            List<UsuarioModel> retorno = usuarios.Where(x => x.Usuario.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).ToList();

            return retorno.FirstOrDefault();
        }

        public void GuardarRegistro(UsuarioModel usuarioModel)
        {
            dataUsuario.Crear(usuarioModel);
        }

        public void ActualizarRegistro(UsuarioModel usuarioModel)
        {
            dataUsuario.Actualizar(p => p.Id == usuarioModel.Id, usuario =>
            {
                usuario.Usuario = usuarioModel.Usuario;
                usuario.Password = usuarioModel.Password;
                usuario.Nombres = usuarioModel.Nombres;
                usuario.Apellidos = usuarioModel.Apellidos;
                usuario.RolId = usuarioModel.RolId;
            });
        }

        public void EliminarUsuario(int id)
        {
            dataUsuario.Eliminar(p => p.Id == id);
        }

        public List<UsuarioModel> ObtenerUsuarios()
        {
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            if (usuarios.Count == 0) return new List<UsuarioModel>();

            List<RolModel> roles = dataRol.Leer();

            if (roles.Count == 0) return new List<UsuarioModel>();

            foreach (var item in usuarios)
            {
                item.RolDescripcion = roles.Find(x => x.Id == item.RolId).Descripcion ?? "";
            }

            return usuarios;
        }

        public int ObtenerTotalRegistros()
        {
            return dataUsuario.ContarRegistros();
        }
    }
}

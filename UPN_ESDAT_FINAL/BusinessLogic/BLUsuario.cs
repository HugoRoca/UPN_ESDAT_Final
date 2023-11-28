using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLRol representa la lógica de negocios para la entidad 'Rol' y 'Usuario'.
    public class BLUsuario
    {
        // Nombres de archivos para los datos de Usuario y Rol.
        private readonly string nombreArchivo = "Usuario";
        private readonly string nombreArchivoRol = "Rol";

        // Instancias de DataAccess para acceder a los datos de Usuario y Rol.
        private readonly DataAccess<UsuarioModel> dataUsuario;
        private readonly DataAccess<RolModel> dataRol;

        // Constructor de la clase BLUsuario.
        public BLUsuario()
        {
            // Inicializa las instancias de DataAccess para Usuario y Rol con los nombres de archivo respectivos.
            dataUsuario = new DataAccess<UsuarioModel>(nombreArchivo);
            dataRol = new DataAccess<RolModel>(nombreArchivoRol);
        }

        // Método para verificar el inicio de sesión de un usuario.
        public bool Login(string username, string password)
        {
            // Lee todos los datos de Usuario.
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            // Retorna false si no hay usuarios en la lista.
            if (usuarios.Count == 0) return false;

            // Verifica si hay algún usuario con las credenciales proporcionadas.
            return usuarios.Any(x => x.Usuario.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower());
        }

        // Método para obtener un usuario por nombre de usuario y contraseña.
        public UsuarioModel ObtenerUsuario(string username, string password)
        {
            // Lee todos los datos de Usuario.
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            // Retorna un nuevo UsuarioModel si no hay usuarios en la lista.
            if (usuarios.Count == 0) return new UsuarioModel();

            // Filtra la lista de usuarios por las credenciales proporcionadas y la convierte a una lista.
            List<UsuarioModel> retorno = usuarios
                .Where(x => x.Usuario.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower())
                .ToList();

            // Retorna el primer usuario encontrado o un nuevo UsuarioModel si no hay coincidencias.
            return retorno.FirstOrDefault();
        }

        // Método para guardar un nuevo registro de usuario.
        public void GuardarRegistro(UsuarioModel usuarioModel)
        {
            // Utiliza el método Crear de la instancia de DataAccess para insertar un nuevo usuario.
            dataUsuario.Crear(usuarioModel);
        }

        // Método para actualizar un registro de usuario.
        public void ActualizarRegistro(UsuarioModel usuarioModel)
        {
            // Utiliza el método Actualizar de la instancia de DataAccess para modificar los datos del usuario.
            dataUsuario.Actualizar(p => p.Id == usuarioModel.Id, usuario =>
            {
                usuario.Usuario = usuarioModel.Usuario;
                usuario.Password = usuarioModel.Password;
                usuario.Nombres = usuarioModel.Nombres;
                usuario.Apellidos = usuarioModel.Apellidos;
                usuario.RolId = usuarioModel.RolId;
            });
        }

        // Método para eliminar un usuario por su ID.
        public void EliminarUsuario(string id)
        {
            // Utiliza el método Eliminar de la instancia de DataAccess para eliminar un usuario por su ID.
            dataUsuario.Eliminar(p => p.Id == id);
        }

        // Método para obtener todos los usuarios con descripciones de roles.
        public List<UsuarioModel> ObtenerUsuarios()
        {
            // Lee todos los datos de Usuario.
            List<UsuarioModel> usuarios = dataUsuario.Leer();

            // Retorna una lista vacía si no hay usuarios en la lista.
            if (usuarios.Count == 0) return new List<UsuarioModel>();

            // Lee todos los datos de Rol.
            List<RolModel> roles = dataRol.Leer();

            // Retorna una lista vacía si no hay roles en la lista.
            if (roles.Count == 0) return new List<UsuarioModel>();

            // Asigna las descripciones de roles a cada usuario.
            foreach (var item in usuarios)
            {
                item.RolDescripcion = roles.Find(x => x.Id == item.RolId).Descripcion ?? "";
            }

            // Retorna la lista de usuarios con descripciones de roles.
            return usuarios;
        }
    }

}

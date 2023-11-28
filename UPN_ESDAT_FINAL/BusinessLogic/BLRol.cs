using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLRol representa la lógica de negocios para la entidad 'Rol' y 'RolPermiso'.
    public class BLRol
    {
        // Nombres de archivos para los datos de Rol y RolPermiso.
        private readonly string nombreArchivoRol = "Rol";
        private readonly string nombreArchivoRolPermiso = "RolPermiso";

        // Instancias de DataAccess para acceder a los datos de Rol y RolPermiso.
        private readonly DataAccess<RolModel> dataRol;
        private readonly DataAccess<RolPermisoModel> dataRolPermiso;

        // Constructor de la clase BLRol.
        public BLRol()
        {
            // Inicializa las instancias de DataAccess para Rol y RolPermiso con los nombres de archivo respectivos.
            dataRol = new DataAccess<RolModel>(nombreArchivoRol);
            dataRolPermiso = new DataAccess<RolPermisoModel>(nombreArchivoRolPermiso);
        }

        // Método para obtener los permisos de menú asociados a un rol específico.
        public List<RolPermisoModel> ObtenerAccesoMenu(int rolId)
        {
            // Lee todos los datos de RolPermiso y filtra por el IdRol específico.
            return dataRolPermiso.Leer().Where(x => x.IdRol == rolId).ToList();
        }

        // Método para obtener un rol por su ID junto con su descripción.
        public RolModel ObtenerRolDescripcion(int idRol)
        {
            // Lee todos los datos de Rol.
            List<RolModel> rols = dataRol.Leer();

            // Busca un rol en la lista con el ID proporcionado y devuelve el resultado o un nuevo RolModel si no se encuentra.
            return rols.Find(x => x.Id == idRol) ?? new RolModel();
        }

        // Método para actualizar la descripción de un rol.
        public void ActualizarRol(RolModel rolModel)
        {
            // Crea una instancia de RolModel para enviar datos al método Actualizar.
            RolModel enviaDatos = new RolModel();

            // Utiliza el método Actualizar de la instancia de DataAccess para modificar la descripción del rol.
            dataRol.Actualizar(p => p.Id == rolModel.Id, rol =>
            {
                rol.Descripcion = rolModel.Descripcion;
            });
        }

        // Método para insertar un nuevo rol.
        public void InsertarRol(RolModel rolModel)
        {
            // Utiliza el método Crear de la instancia de DataAccess para insertar un nuevo rol.
            dataRol.Crear(rolModel);
        }

        // Método para eliminar un rol por su ID.
        public void EliminarRol(int id)
        {
            // Utiliza el método Eliminar de la instancia de DataAccess para eliminar un rol por su ID.
            dataRol.Eliminar(p => p.Id == id);
        }

        // Método para obtener todos los roles.
        public List<RolModel> ObtenerRoles()
        {
            // Utiliza el método Leer de la instancia de DataAccess para obtener todos los roles.
            return dataRol.Leer();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLRol
    {
        private readonly string nombreArchivoRol = "Rol";
        private readonly string nombreArchivoRolPermiso = "RolPermiso";
        private readonly DataAccess<RolModel> dataRol;
        private readonly DataAccess<RolPermisoModel> dataRolPermiso;

        public BLRol()
        {
            dataRol = new DataAccess<RolModel>(nombreArchivoRol);
            dataRolPermiso = new DataAccess<RolPermisoModel>(nombreArchivoRolPermiso);
        }

        public List<RolPermisoModel> ObtenerAccesoMenu(string rol)
        {
            List<RolModel> roles = dataRol.Leer();
            int rolId = roles.FirstOrDefault(x => x.Descripcion.ToLower() == rol.ToLower()).Id;
            
            return dataRolPermiso.Leer().Where(x=> x.IdRol == rolId).ToList();
        }
    }
}

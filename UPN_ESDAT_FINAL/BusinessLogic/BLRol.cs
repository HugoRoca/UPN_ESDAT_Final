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
        private readonly string nombreArchivo = "Rol";
        private readonly DataAccess<RolModel> dataRol;
        private readonly DataAccess<RolModel> dataRolPermiso;

        public BLRol()
        {
            dataRol = new DataAccess<RolModel>(nombreArchivo);
        }


    }
}

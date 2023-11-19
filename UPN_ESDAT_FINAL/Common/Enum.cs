using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPN_ESDAT_FINAL.Common
{
    public class Enum
    {
        public enum TipoMensaje
        {
            Informativo,
            Advertencia,
            YesNoCancel,
            Error
        }

        public enum AccionBoton
        {
            Nuevo,
            Editar,
            EditarEliminar,
            Default
        }
    }
}

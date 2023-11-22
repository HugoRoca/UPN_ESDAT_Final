using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLEstadoProceso
    {
        private readonly string nombreArchivo = "EstadoProceso";
        private readonly DataAccess<EstadoProcesoModel> _dataEstado;

        public BLEstadoProceso()
        {
            _dataEstado = new DataAccess<EstadoProcesoModel>(nombreArchivo);
        }

        public List<EstadoProcesoModel> ObtenerTodos()
        {
            return _dataEstado.Leer();
        }

        public int ContarRegistros()
        {
            return _dataEstado.ContarRegistros();
        }
    }
}

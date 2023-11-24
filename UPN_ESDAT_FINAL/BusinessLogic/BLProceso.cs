using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLProceso
    {
        private readonly string nombreArchivo = "Proceso";
        private readonly DataAccess<ProcesoModel> _dataProceso;

        public BLProceso()
        {
            _dataProceso = new DataAccess<ProcesoModel>(nombreArchivo);
        }

        public List<ProcesoModel> ObtenerTodos()
        {
            return _dataProceso.Leer();
        }

        public int ContarRegistros()
        {
            return _dataProceso.ContarRegistros();
        }

        public void ActualizarRegistro(ProcesoModel procesoModel)
        {
            _dataProceso.Actualizar(p => p.Id == procesoModel.Id, update =>
            {
                update.DescripcionCorta = procesoModel.DescripcionCorta;
                update.DescripcionLarga = procesoModel.DescripcionLarga;
                update.Estado = procesoModel.Estado;
                update.IdArea = procesoModel.IdArea;
                update.Documentos = procesoModel.Documentos;
            });
        }

        public void EliminarRegistros(int id)
        {
            _dataProceso.Eliminar(p => p.Id == id);
        }

        public void InsertarRegistro(ProcesoModel procesoModel)
        {
            _dataProceso.Crear(procesoModel);
        }

        public List<ProcesoModel> ObtenerPorEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado)) return _dataProceso.Leer();

            return _dataProceso.Buscar(p => p.Estado == estado);
        }
    }
}

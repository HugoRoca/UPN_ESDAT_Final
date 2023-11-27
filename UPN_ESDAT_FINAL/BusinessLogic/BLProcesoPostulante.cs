using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLProcesoPostulante
    {
        private readonly string nombreArchivo = "ProcesoPostulante";
        private readonly DataAccess<ProcesoPostulanteModel> _dataProceso;

        public BLProcesoPostulante()
        {
            _dataProceso = new DataAccess<ProcesoPostulanteModel>(nombreArchivo);
        }

        public void Insertar(ProcesoPostulanteModel procesoPostulanteModel)
        {
            _dataProceso.Crear(procesoPostulanteModel);
        }

        public void ActualizarObservacion(ProcesoPostulanteModel procesoPostulanteModel)
        {
            _dataProceso.Actualizar(p => p.Id == procesoPostulanteModel.Id, pro =>
            {
                pro.Observaciones = procesoPostulanteModel.Observaciones;
            });
        }

        public List<ProcesoPostulanteModel> BuscarPorIdPostulante(string id)
        {
            return _dataProceso.Buscar(p => p.IdPostulante == id);
        }

        public List<ProcesoPostulanteModel> BuscarPorIdProceso(string id)
        {
            return _dataProceso.Buscar(p => p.IdProceso == id);
        }

        public List<ProcesoPostulanteModel> BuscarPorIdPostulanteYProceso(string idPostulante, string idProceso)
        {
            return _dataProceso.Buscar(p => p.IdProceso == idProceso && p.IdPostulante == idPostulante);
        }
    }
}

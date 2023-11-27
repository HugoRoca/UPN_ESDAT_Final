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

        public List<ProcesoPostulanteModel> BuscarPorIdPostulante(int id)
        {
            return _dataProceso.Buscar(p => p.IdPostulante == id);
        }
    }
}

using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLProcesoPostulante representa la lógica de negocios para la entidad 'ProcesoPostulanteModel'.
    public class BLProcesoPostulante
    {
        // Nombre del archivo asociado a la entidad 'ProcesoPostulante'.
        private readonly string nombreArchivo = "ProcesoPostulante";

        // Instancia de la clase DataAccess parametrizada con el modelo 'ProcesoPostulante'.
        private readonly DataAccess<ProcesoPostulanteModel> _dataProceso;

        // Constructor de la clase BLProcesoPostulante
        public BLProcesoPostulante()
        {
            // Se inicializa la instancia de DataAccess con el modelo 'ProcesoPostulanteModel'.
            _dataProceso = new DataAccess<ProcesoPostulanteModel>(nombreArchivo);
        }

        // Método para insertar un nuevo registro de ProcesoPostulanteModel.
        public void Insertar(ProcesoPostulanteModel procesoPostulanteModel)
        {
            // Utiliza el método Crear de la instancia de DataAccess para insertar un nuevo registro de ProcesoPostulanteModel.
            _dataProceso.Crear(procesoPostulanteModel);
        }

        // Método para actualizar las observaciones de un registro de ProcesoPostulanteModel.
        public void ActualizarObservacion(ProcesoPostulanteModel procesoPostulanteModel)
        {
            // Utiliza el método Actualizar de la instancia de DataAccess para modificar las observaciones de un registro de ProcesoPostulanteModel.
            _dataProceso.Actualizar(p => p.Id == procesoPostulanteModel.Id, pro =>
            {
                // Actualiza el campo de observaciones del registro de ProcesoPostulanteModel con el nuevo valor.
                pro.Observaciones = procesoPostulanteModel.Observaciones;
            });
        }

        // Método para buscar registros de ProcesoPostulanteModel por el ID del postulante.
        public List<ProcesoPostulanteModel> BuscarPorIdPostulante(string id)
        {
            // Utiliza el método Buscar de la instancia de DataAccess para obtener registros de ProcesoPostulanteModel que coincidan con el ID del postulante.
            return _dataProceso.Buscar(p => p.IdPostulante == id);
        }

        // Método para buscar registros de ProcesoPostulanteModel por el ID del proceso.
        public List<ProcesoPostulanteModel> BuscarPorIdProceso(string id)
        {
            // Utiliza el método Buscar de la instancia de DataAccess para obtener registros de ProcesoPostulanteModel que coincidan con el ID del proceso.
            return _dataProceso.Buscar(p => p.IdProceso == id);
        }

        // Método para buscar registros de ProcesoPostulanteModel por el ID del postulante y el ID del proceso.
        public List<ProcesoPostulanteModel> BuscarPorIdPostulanteYProceso(string idPostulante, string idProceso)
        {
            // Utiliza el método Buscar de la instancia de DataAccess para obtener registros de ProcesoPostulanteModel que coincidan con el ID del postulante y el ID del proceso.
            return _dataProceso.Buscar(p => p.IdProceso == idProceso && p.IdPostulante == idPostulante);
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLProceso representa la lógica de negocios para la entidad 'ProcesoModel'.
    public class BLProceso
    {
        // Nombre del archivo asociado a la entidad 'ProcesoModel'.
        private readonly string nombreArchivo = "Proceso";

        // Instancia de la clase DataAccess parametrizada con el modelo 'ProcesoModel'.
        private readonly DataAccess<ProcesoModel> _dataProceso;

        // Constructor de la clase BLProceso.
        public BLProceso()
        {
            // Se inicializa la instancia de DataAccess con el modelo 'ProcesoModel'.
            _dataProceso = new DataAccess<ProcesoModel>(nombreArchivo);
        }

        // Método para obtener todos los procesos.
        public List<ProcesoModel> ObtenerTodos()
        {
            // Utiliza el método Leer de la instancia de DataAccess para obtener todos los procesos.
            return _dataProceso.Leer();
        }

        // Método para actualizar la información de un registro de proceso.
        public void ActualizarRegistro(ProcesoModel procesoModel)
        {
            // Utiliza el método Actualizar de la instancia de DataAccess para modificar un registro de proceso.
            _dataProceso.Actualizar(p => p.Id == procesoModel.Id, update =>
            {
                // Actualiza los campos del registro de proceso con los nuevos valores.
                update.DescripcionCorta = procesoModel.DescripcionCorta;
                update.DescripcionLarga = procesoModel.DescripcionLarga;
                update.Estado = procesoModel.Estado;
                update.IdArea = procesoModel.IdArea;
                update.Documentos = procesoModel.Documentos;
            });
        }

        // Método para actualizar el estado de un registro de proceso.
        public void ActualizarEstado(ProcesoModel procesoModel)
        {
            // Utiliza el método Actualizar de la instancia de DataAccess para modificar el estado de un registro de proceso.
            _dataProceso.Actualizar(p => p.Id == procesoModel.Id, update =>
            {
                // Actualiza el campo de estado del registro de proceso con el nuevo valor.
                update.Estado = procesoModel.Estado;
            });
        }

        // Método para eliminar registros de procesos.
        public void EliminarRegistros(string id)
        {
            // Utiliza el método Eliminar de la instancia de DataAccess para borrar registros de procesos.
            _dataProceso.Eliminar(p => p.Id == id);
        }

        // Método para insertar un nuevo registro de proceso.
        public void InsertarRegistro(ProcesoModel procesoModel)
        {
            // Utiliza el método Crear de la instancia de DataAccess para insertar un nuevo registro de proceso.
            _dataProceso.Crear(procesoModel);
        }

        // Método para obtener procesos por estado.
        public List<ProcesoModel> ObtenerPorEstado(string estado)
        {
            // Si el estado es nulo o vacío, devuelve todos los procesos.
            if (string.IsNullOrEmpty(estado)) return _dataProceso.Leer();

            // Devuelve los procesos que coinciden con el estado especificado.
            return _dataProceso.Buscar(p => p.Estado == estado);
        }

        // Método para buscar un registro de proceso por ID.
        public ProcesoModel BuscarPorId(string id)
        {
            // Busca registros de procesos que coincidan con el ID especificado.
            List<ProcesoModel> procesos = _dataProceso.Buscar(p => p.Id == id);

            // Si no se encuentran registros de procesos, devuelve un nuevo ProcesoModel vacío.
            if (!procesos.Any()) return new ProcesoModel();

            // Devuelve el primer registro de proceso que coincide con el ID.
            return procesos.FirstOrDefault();
        }
    }

}
using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLArea representa la lógica de negocios para la entidad 'Area'.
    public class BLArea
    {
        // El nombre del archivo asociado a la entidad 'Area' para operaciones de lectura y escritura.
        private readonly string nombreArchivo = "Area";

        // Instancia de la clase DataAccess parametrizada con el modelo 'AreaModel'.
        private readonly DataAccess<AreaModel> _dataArea;

        // Constructor de la clase BLArea.
        public BLArea()
        {
            // Se inicializa la instancia de DataAccess con el nombre del archivo asociado a 'AreaModel'.
            _dataArea = new DataAccess<AreaModel>(nombreArchivo);
        }

        // Método para obtener todas las áreas.
        public List<AreaModel> ObtenerTodos()
        {
            // Utiliza el método Leer de la instancia de DataAccess para obtener todas las áreas del archivo.
            return _dataArea.Leer();
        }

        // Método para buscar un área por su identificador.
        public AreaModel BuscarPorId(int id)
        {
            // Utiliza el método Buscar de la instancia de DataAccess para buscar áreas que coincidan con el ID.
            List<AreaModel> areas = _dataArea.Buscar(p => p.Id == id);

            // Devuelve el primer resultado si hay coincidencias, de lo contrario, retorna un nuevo objeto AreaModel.
            return areas.FirstOrDefault() ?? new AreaModel();
        }
    }

}

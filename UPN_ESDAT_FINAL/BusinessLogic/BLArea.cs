using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public  class BLArea
    {
        private readonly string nombreArchivo = "Area";
        private readonly DataAccess<AreaModel> _dataArea;

        public BLArea()
        {
            _dataArea = new DataAccess<AreaModel>(nombreArchivo);
        }

        public List<AreaModel> ObtenerTodos()
        {
            return _dataArea.Leer();
        }

        public AreaModel BuscarPorId(int id)
        {
            List<AreaModel> areas = _dataArea.Buscar(p => p.Id == id);

            return areas.FirstOrDefault() ?? new AreaModel();
        }
    }
}

using System.Collections.Generic;
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

        public int ContarRegistros()
        {
            return _dataArea.ContarRegistros();
        }
    }
}

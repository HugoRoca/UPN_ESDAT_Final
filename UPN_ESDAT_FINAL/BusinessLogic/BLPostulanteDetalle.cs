using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLPostulanteDetalle
    {
        public readonly string nombreArchivo = "PostulanteDetalle";
        public readonly DataAccess<PostulanteDetalleModel> _dataPostulante;

        public BLPostulanteDetalle()
        {
            _dataPostulante = new DataAccess<PostulanteDetalleModel>(nombreArchivo);
        }

        public void Insertar(PostulanteDetalleModel postulanteDetalleModel)
        {
            _dataPostulante.Crear(postulanteDetalleModel);
        }

        public void Actualizar(PostulanteDetalleModel postulanteDetalleModel)
        {
            _dataPostulante.Actualizar(po => po.Id == postulanteDetalleModel.Id, postulante =>
            {
                postulante.Observaciones = postulanteDetalleModel.Observaciones;
            });
        }

        public int ContarRegistros()
        {
            return _dataPostulante.ContarRegistros();
        }

        public List<PostulanteDetalleModel> ObtenerDetalle(int idPostulante)
        {
            return _dataPostulante.Buscar(p => p.IdPostulante == idPostulante);
        }
    }
}

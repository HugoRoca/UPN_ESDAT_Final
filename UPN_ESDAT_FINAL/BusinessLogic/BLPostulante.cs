using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLPostulante
    {
        private readonly string nombreArchivo = "Postulante";
        private readonly DataAccess<PostulanteModel> _dataPostulante;

        public BLPostulante()
        {
            _dataPostulante = new DataAccess<PostulanteModel>(nombreArchivo);
        }

        public List<PostulanteModel> ObtenerTodos()
        {
            return _dataPostulante.Leer();
        }

        public int ObtenerTotalRegistros()
        {
            return _dataPostulante.ContarRegistros();
        }

        public void Insertar(PostulanteModel postulanteModel)
        {
            _dataPostulante.Crear(postulanteModel);
        }

        public void Actualizar(PostulanteModel postulanteModel)
        {
            _dataPostulante.Actualizar(p => p.Id == postulanteModel.Id, update =>
            {
                update.Nombres = postulanteModel.Nombres;
                update.Apellidos = postulanteModel.Apellidos;
                update.Celular = postulanteModel.Celular;
                update.Email = postulanteModel.Email;
                update.FechaNacimiento = postulanteModel.FechaNacimiento;
                update.Documentos = postulanteModel.Documentos;
                update.Dni = postulanteModel.Dni;
                update.IdProceso = postulanteModel.IdProceso;
            });
        }

        public void Eliminar(int id)
        {
            _dataPostulante.Eliminar(p => p.Id == id);
        }

        public PostulanteModel BuscarPorDocumento(string documento)
        {
            List<PostulanteModel> postulantes = _dataPostulante.Buscar(p => p.Dni == documento);

            if (!postulantes.Any()) return new PostulanteModel();

            return postulantes.FirstOrDefault(x => x.Dni == documento);
        }
    }
}

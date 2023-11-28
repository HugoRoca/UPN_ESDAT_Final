using System.Collections.Generic;
using System.Linq;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLPostulante representa la lógica de negocios para la entidad 'Postulante'.
    public class BLPostulante
    {
        // El nombre del archivo asociado a la entidad 'Postulante' para operaciones de lectura y escritura.
        private readonly string nombreArchivo = "Postulante";

        // Instancia de la clase DataAccess parametrizada con el modelo 'PostulanteModel'.
        private readonly DataAccess<PostulanteModel> _dataPostulante;

        // Constructor de la clase BLPostulante.
        public BLPostulante()
        {
            _dataPostulante = new DataAccess<PostulanteModel>(nombreArchivo);
        }

        // Método para obtener todos los postulantes.
        public List<PostulanteModel> ObtenerTodos()
        {
            // Utiliza el método Leer de la instancia de DataAccess para obtener todos los postulantes.
            return _dataPostulante.Leer();
        }

        // Método para insertar un nuevo postulante.
        public void Insertar(PostulanteModel postulanteModel)
        {
            // Utiliza el método Crear de la instancia de DataAccess para insertar un nuevo postulante.
            _dataPostulante.Crear(postulanteModel);
        }

        // Método para actualizar la información de un postulante.
        public void Actualizar(PostulanteModel postulanteModel)
        {
            // Utiliza el método Actualizar de la instancia de DataAccess para modificar un postulante.
            _dataPostulante.Actualizar(p => p.Id == postulanteModel.Id, update =>
            {
                // Actualiza los campos del postulante con los nuevos valores.
                update.Nombres = postulanteModel.Nombres;
                update.Apellidos = postulanteModel.Apellidos;
                update.Celular = postulanteModel.Celular;
                update.Email = postulanteModel.Email;
                update.FechaNacimiento = postulanteModel.FechaNacimiento;
                update.Documentos = postulanteModel.Documentos;
                update.Dni = postulanteModel.Dni;
                update.IdProceso = postulanteModel.IdProceso;
                update.Estado = postulanteModel.Estado;
            });
        }

        // Método para actualizar el estado de un postulante.
        public void ActualizarEstado(PostulanteModel postulanteModel)
        {
            // Utiliza el método Actualizar de la instancia de DataAccess para modificar el estado de un postulante.
            _dataPostulante.Actualizar(p => p.Id == postulanteModel.Id, update =>
            {
                // Actualiza los campos relevantes del postulante con los nuevos valores.
                update.IdProceso = postulanteModel.IdProceso;
                update.Estado = postulanteModel.Estado;
            });
        }

        // Método para eliminar un postulante.
        public void Eliminar(string id)
        {
            // Utiliza el método Eliminar de la instancia de DataAccess para borrar un postulante.
            _dataPostulante.Eliminar(p => p.Id == id);
        }

        // Método para buscar un postulante por documento.
        public PostulanteModel BuscarPorDocumento(string documento)
        {
            // Busca postulantes que coincidan con el documento especificado.
            List<PostulanteModel> postulantes = _dataPostulante.Buscar(p => p.Dni == documento);

            // Si no se encuentran postulantes, devuelve un nuevo PostulanteModel vacío.
            if (!postulantes.Any()) return new PostulanteModel();

            // Devuelve el primer postulante que coincide con el documento.
            return postulantes.FirstOrDefault(x => x.Dni == documento);
        }

        // Método para buscar un postulante por ID.
        public PostulanteModel BuscarPorId(string id)
        {
            // Busca postulantes que coincidan con el ID especificado.
            List<PostulanteModel> postulantes = _dataPostulante.Buscar(p => p.Id == id);

            // Si no se encuentran postulantes, devuelve un nuevo PostulanteModel vacío.
            if (!postulantes.Any()) return new PostulanteModel();

            // Devuelve el primer postulante que coincide con el ID.
            return postulantes.FirstOrDefault(x => x.Id == id);
        }
    }
}

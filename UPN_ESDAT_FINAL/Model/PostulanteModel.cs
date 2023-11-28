using System;

namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'PostulanteModel'.
    // Esta clase puede ser utilizada para representar la información de un postulante, como en un sistema de gestión de recursos humanos o en una aplicación de reclutamiento.
    public class PostulanteModel
    {
        // Propiedad pública 'Id' de tipo string.
        // Esta propiedad sirve como identificador único para cada postulante.
        public string Id { get; set; }

        // Propiedad pública 'Nombres' de tipo string.
        // Esta propiedad almacena el o los nombres del postulante.
        public string Nombres { get; set; }

        // Propiedad pública 'Apellidos' de tipo string.
        // Esta propiedad almacena el o los apellidos del postulante.
        public string Apellidos { get; set; }

        // Propiedad pública 'Celular' de tipo string.
        // Esta propiedad almacena el número de teléfono móvil del postulante.
        public string Celular { get; set; }

        // Propiedad pública 'Email' de tipo string.
        // Esta propiedad almacena la dirección de correo electrónico del postulante.
        public string Email { get; set; }

        // Propiedad pública 'FechaNacimiento' de tipo string.
        // Esta propiedad almacena la fecha de nacimiento del postulante.
        public string FechaNacimiento { get; set; }

        // Propiedad pública 'Documentos' de tipo string.
        // Esta propiedad puede utilizarse para almacenar información sobre los documentos presentados por el postulante.
        public string Documentos { get; set; }

        // Propiedad pública 'Dni' de tipo string.
        // Esta propiedad almacena el número de documento de identidad del postulante.
        public string Dni { get; set; }

        // Propiedad pública 'IdProceso' de tipo string.
        // Esta propiedad podría usarse para relacionar al postulante con un proceso de selección o reclutamiento específico.
        public string IdProceso { get; set; }

        // Propiedad pública 'Estado' de tipo string.
        // Esta propiedad puede indicar el estado actual del postulante en el proceso de selección o reclutamiento.
        public string Estado { get; set; }
    }
}

namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'ProcesoPostulanteModel'.
    // Esta clase puede ser utilizada para representar la relación entre un proceso (como un proceso de reclutamiento) y un postulante, incluyendo información relevante sobre esta relación.
    public class ProcesoPostulanteModel
    {
        // Propiedad pública 'Id' de tipo string.
        // Esta propiedad sirve como identificador único para cada instancia de relación entre un proceso y un postulante.
        public string Id { get; set; }

        // Propiedad pública 'IdProceso' de tipo string.
        // Esta propiedad almacena el identificador del proceso en el que está involucrado el postulante.
        public string IdProceso { get; set; }

        // Propiedad pública 'IdPostulante' de tipo string.
        // Esta propiedad almacena el identificador del postulante involucrado en el proceso.
        public string IdPostulante { get; set; }

        // Propiedad pública 'Estado' de tipo string.
        // Esta propiedad puede indicar el estado actual del postulante dentro del proceso (por ejemplo, "aceptado", "rechazado", "en revisión").
        public string Estado { get; set; }

        // Propiedad pública 'Observaciones' de tipo string.
        // Esta propiedad puede utilizarse para almacenar notas o comentarios adicionales sobre la participación del postulante en el proceso.
        public string Observaciones { get; set; }

        // Propiedad pública 'Nombres' de tipo string.
        // Esta propiedad puede almacenar los nombres del postulante. Es útil para tener una referencia rápida al nombre del postulante sin necesidad de consultar otra tabla o clase.
        public string Nombres { get; set; }
    }
}

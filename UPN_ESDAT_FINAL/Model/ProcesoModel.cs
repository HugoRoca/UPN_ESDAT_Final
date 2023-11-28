namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'ProcesoModel'.
    // Esta clase puede ser utilizada para representar un proceso específico, como un proceso de reclutamiento o un proyecto dentro de una organización.
    public class ProcesoModel
    {
        // Propiedad pública 'Id' de tipo string.
        // Esta propiedad sirve como identificador único para cada proceso.
        public string Id { get; set; }

        // Propiedad pública 'DescripcionCorta' de tipo string.
        // Esta propiedad almacena una descripción breve del proceso.
        public string DescripcionCorta { get; set; }

        // Propiedad pública 'DescripcionLarga' de tipo string.
        // Esta propiedad almacena una descripción detallada del proceso.
        public string DescripcionLarga { get; set; }

        // Propiedad pública 'IdArea' de tipo entero.
        // Esta propiedad se utiliza para asociar el proceso con un área específica dentro de la organización, utilizando un identificador numérico.
        public int IdArea { get; set; }

        // Propiedad pública 'Documentos' de tipo string.
        // Esta propiedad puede usarse para almacenar información sobre los documentos relacionados con el proceso.
        public string Documentos { get; set; }

        // Propiedad pública 'Estado' de tipo string.
        // Esta propiedad puede indicar el estado actual del proceso (como "activo", "en espera", "completado", etc.).
        public string Estado { get; set; }

        // Propiedad pública 'Area' de tipo string.
        // Esta propiedad podría usarse para almacenar el nombre o una descripción textual del área asociada con el proceso.
        public string Area { get; set; }
    }
}

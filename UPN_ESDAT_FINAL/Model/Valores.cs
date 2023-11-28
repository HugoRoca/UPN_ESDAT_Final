namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'Valores'.
    // Esta clase es genérica y puede ser utilizada para representar un conjunto de valores o una entidad con un identificador y una descripción.
    // El uso específico de esta clase dependerá del contexto en el que se implemente.
    public class Valores
    {
        // Propiedad pública 'Id' de tipo entero.
        // Esta propiedad sirve como identificador único para cada instancia de la clase.
        // Podría utilizarse para referenciar un elemento específico en una colección o base de datos.
        public int Id { get; set; }

        // Propiedad pública 'Descripcion' de tipo string.
        // Esta propiedad almacena una descripción textual.
        // Puede ser utilizada para proporcionar más detalles sobre la entidad o valor representado por la instancia de la clase.
        public string Descripcion { get; set; }
    }
}

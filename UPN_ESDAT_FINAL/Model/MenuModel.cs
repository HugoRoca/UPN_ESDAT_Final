namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'MenuModel'.
    // Esta clase puede ser utilizada para representar un elemento de menú en una aplicación, con sus propiedades específicas.
    public class MenuModel
    {
        // Propiedad pública 'Id' de tipo entero.
        // Esta propiedad sirve como identificador único para cada elemento del menú.
        public int Id { get; set; }

        // Propiedad pública 'Descripcion' de tipo string.
        // Esta propiedad puede ser utilizada para almacenar una descripción textual del elemento del menú.
        public string Descripcion { get; set; }

        // Propiedad pública 'Formulario' de tipo string.
        // Esta propiedad puede indicar el nombre del formulario o la vista que se abrirá al seleccionar este elemento del menú.
        public string Formulario { get; set; }

        // Propiedad pública 'IdPadre' de tipo entero.
        // Esta propiedad se puede usar para establecer una relación jerárquica entre los elementos del menú,
        // donde 'IdPadre' se refiere al identificador del elemento de menú padre de este elemento.
        public int IdPadre { get; set; }
    }
}

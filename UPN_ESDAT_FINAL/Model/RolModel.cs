namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'RolModel'.
    // Esta clase puede ser utilizada para representar un rol o función dentro de una aplicación, como en sistemas de gestión de usuarios o control de acceso.
    public class RolModel
    {
        // Propiedad pública 'Id' de tipo entero.
        // Esta propiedad sirve como identificador único para cada rol.
        public int Id { get; set; }

        // Propiedad pública 'Descripcion' de tipo string.
        // Esta propiedad almacena una descripción textual del rol.
        // Por ejemplo, puede describir las responsabilidades o permisos asociados con el rol.
        public string Descripcion { get; set; }
    }
}

namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'RolPermisoModel'.
    // Esta clase puede ser utilizada para representar la relación entre un rol y un permiso en una aplicación, particularmente en sistemas de gestión de acceso o control de usuarios.
    public class RolPermisoModel
    {
        // Propiedad pública 'IdRol' de tipo entero.
        // Esta propiedad almacena el identificador del rol al que se le asigna el permiso.
        // Un rol es un conjunto de permisos o accesos asignados a un grupo de usuarios.
        public int IdRol { get; set; }

        // Propiedad pública 'IdMenu' de tipo entero.
        // Esta propiedad almacena el identificador del menú o funcionalidad a la que se le asigna el permiso.
        // Esto podría referirse a un elemento específico de la interfaz de usuario, como una opción de menú.
        public int IdMenu { get; set; }

        // Propiedad pública 'DescripcionMenu' de tipo string.
        // Esta propiedad proporciona una descripción del menú o funcionalidad asociada al permiso.
        // Esto es útil para entender a qué se refiere el permiso sin necesidad de referenciar otras tablas o clases.
        public string DescripcionMenu { get; set; }
    }
}

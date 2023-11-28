namespace UPN_ESDAT_FINAL.Model
{
    // Definición de la clase pública 'UsuarioModel'.
    // Esta clase puede ser utilizada para representar la información de un usuario en una aplicación, especialmente en contextos donde se manejan autenticación y autorización.
    public class UsuarioModel
    {
        // Propiedad pública 'Id' de tipo string.
        // Esta propiedad sirve como identificador único para cada usuario.
        public string Id { get; set; }

        // Propiedad pública 'Usuario' de tipo string.
        // Esta propiedad almacena el nombre de usuario utilizado para la autenticación en el sistema.
        public string Usuario { get; set; }

        // Propiedad pública 'Password' de tipo string.
        // Esta propiedad almacena la contraseña del usuario. Debería ser almacenada de forma segura, idealmente encriptada o hasheada.
        public string Password { get; set; }

        // Propiedad pública 'RolId' de tipo entero.
        // Esta propiedad almacena el identificador del rol asignado al usuario, que define sus permisos y accesos dentro de la aplicación.
        public int RolId { get; set; }

        // Propiedad pública 'Nombres' de tipo string.
        // Esta propiedad almacena los nombres del usuario.
        public string Nombres { get; set; }

        // Propiedad pública 'Apellidos' de tipo string.
        // Esta propiedad almacena los apellidos del usuario.
        public string Apellidos { get; set; }

        // Propiedad pública 'RolDescripcion' de tipo string.
        // Esta propiedad proporciona una descripción textual del rol asignado al usuario, facilitando la comprensión del tipo de acceso y permisos que tiene.
        public string RolDescripcion { get; set; }
    }
}

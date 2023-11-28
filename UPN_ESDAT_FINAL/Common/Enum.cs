namespace UPN_ESDAT_FINAL.Common
{
    // Clase que contiene enumeraciones utilizadas en la aplicación.
    public class Enum
    {
        // Enumeración que define extensiones de archivos.
        public enum Extension
        {
            // Extensión para archivos PDF.
            PDF,

            // Extensión para archivos Word.
            Word
        }

        // Enumeración que define tipos de mensajes.
        public enum TipoMensaje
        {
            // Mensaje informativo.
            Informativo,

            // Mensaje de advertencia.
            Advertencia,

            // Mensaje con opciones Yes/No/Cancel.
            YesNoCancel,

            // Mensaje de error.
            Error
        }

        // Enumeración que define acciones de botones.
        public enum AccionBoton
        {
            // Acción para un nuevo elemento.
            Nuevo,

            // Acción para editar un elemento.
            Editar,

            // Acción para editar o eliminar un elemento.
            EditarEliminar,

            // Acción por defecto.
            Default
        }
    }

}

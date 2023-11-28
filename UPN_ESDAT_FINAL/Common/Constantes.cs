using System.Collections.Generic;

namespace UPN_ESDAT_FINAL.Common
{
    // Clase que contiene constantes utilizadas en la aplicación.
    public class Constantes
    {
        // Clase interna que define constantes relacionadas con el menú.
        public static class Menu
        {
            // Cadena que especifica las opciones de menú siempre accesibles.
            public const string AlwaysAccess = "&Archivo, Cerrar Sesión, &Salir, &Ventanas, &Nueva ventana";
        }

        // Clase interna que define constantes relacionadas con el estado de procesos.
        public static class EstadoProceso
        {
            // Constante que representa el estado activo.
            public const string Activo = "ACTIVO";

            // Constante que representa el estado en pausa.
            public const string EnPausa = "EN PAUSA";

            // Constante que representa el estado inhabilitado.
            public const string Inhabilitar = "INHABILITADO";

            // Constante que representa el estado finalizado.
            public const string Finalizado = "FINALIZADO";
        }

        // Clase interna que define constantes relacionadas con las carpetas.
        public static class Carpetas
        {
            // Constante que representa la carpeta de postulantes.
            public const string Postulante = "Postulante";

            // Constante que representa la carpeta de procesos.
            public const string Proceso = "Proceso";
        }

        // Clase interna que define constantes relacionadas con el estado de postulantes.
        public static class EstadoPostulante
        {
            // Constante que representa el estado en proceso.
            public const string EnProceso = "EN PROCESO";

            // Constante que representa el estado en evaluación psicotécnica.
            public const string EnEvaluacionPsicotecnica = "EN EVALUACION PSICOTENICA";

            // Constante que representa el estado en entrevista técnica.
            public const string EnEntrevistaTecnica = "EN ESTREVISTA TÉCNICA";

            // Constante que representa el estado en entrevista personal.
            public const string EnEntrevistaPersonal = "EN ENTREVISTA PERSONAL";

            // Constante que representa el estado apto.
            public const string Apto = "APTO";

            // Constante que representa el estado no apto.
            public const string NoApto = "NO APTO";

            // Constante que representa el estado contratado.
            public const string Contratado = "CONTRATADO";
        }
    }

}

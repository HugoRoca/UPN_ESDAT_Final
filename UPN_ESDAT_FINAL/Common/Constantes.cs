using System.Collections.Generic;

namespace UPN_ESDAT_FINAL.Common
{
    public class Constantes
    {
        public static class Menu
        {
            public const string AlwaysAccess = "&Archivo, Cerrar Sesión, &Salir, &Ventanas, &Nueva ventana";
        }

        public static class EstadoProceso
        {
            public const string Activo = "ACTIVO";
            public const string EnPausa = "EN PAUSA";
            public const string Inhabilitar = "INHABILITADO";
            public const string Finalizado = "FINALIZADO";
        }

        public static class Carpetas
        {
            public const string Postulante = "Postulante";
            public const string Proceso = "Proceso";
        }

        public static class EstadoPostulante
        {
            public const string EnProceso = "EN PROCESO";
            public const string EnEvaluacionPsicotecnica = "EN EVALUACION PSICOTENICA";
            public const string EnEntrevistaTecnica = "EN ESTREVISTA TÉCNICA";
            public const string EnEntrevistaPersonal = "EN ENTREVISTA PERSONAL";
            public const string Apto = "APTO";
            public const string NoApto = "NO APTO";
            public const string Contratado = "CONTRATADO";

        }
    }
}

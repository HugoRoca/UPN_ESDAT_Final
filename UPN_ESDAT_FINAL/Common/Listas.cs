using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL.Common
{
    // Clase que proporciona listas predefinidas utilizadas en la aplicación.
    public class Listas
    {
        // Método que devuelve una lista de estados de proceso.
        public List<Valores> EstadosProceso()
        {
            // Lista para almacenar los estados de proceso.
            List<Valores> estados = new List<Valores>
            {
                // Agregar estados a la lista.
                new Valores { Descripcion = Constantes.EstadoProceso.Activo, Id = 1 },
                new Valores { Descripcion = Constantes.EstadoProceso.EnPausa, Id = 2 },
                new Valores { Descripcion = Constantes.EstadoProceso.Inhabilitar, Id = 3 },
                new Valores { Descripcion = Constantes.EstadoProceso.Finalizado, Id = 4 }
            };

            // Devolver la lista de estados de proceso.
            return estados;
        }

        // Método que devuelve una lista de todos los estados de un postulante.
        public List<Valores> EstadosPostulanteTodos()
        {
            // Lista para almacenar los estados de un postulante.
            List<Valores> estados = new List<Valores>
            {
                // Agregar estados a la lista.
                new Valores { Descripcion = Constantes.EstadoPostulante.EnProceso, Id = 1 },
                new Valores { Descripcion = Constantes.EstadoPostulante.EnEvaluacionPsicotecnica, Id = 2 },
                new Valores { Descripcion = Constantes.EstadoPostulante.EnEntrevistaTecnica, Id = 3 },
                new Valores { Descripcion = Constantes.EstadoPostulante.EnEntrevistaPersonal, Id = 4 },
                new Valores { Descripcion = Constantes.EstadoPostulante.Apto, Id = 5 },
                new Valores { Descripcion = Constantes.EstadoPostulante.NoApto, Id = 6 },
                new Valores { Descripcion = Constantes.EstadoPostulante.Contratado, Id = 7 }
            };

            // Devolver la lista de estados de un postulante.
            return estados;
        }
    }

}

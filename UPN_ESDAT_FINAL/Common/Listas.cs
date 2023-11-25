using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL.Common
{
    public class Listas
    {
        public List<Valores> EstadosProceso()
        {
            List<Valores> estados = new List<Valores>();

            estados.Add(new Valores { Descripcion = Constantes.EstadoProceso.Activo, Id = 1 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoProceso.EnPausa, Id = 2 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoProceso.Inhabilitar, Id = 3 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoProceso.Finalizado, Id = 4 });

            return estados;
        }

        public List<Valores> EstadosPostulante()
        {
            List<Valores> estados = new List<Valores>();

            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.EnProceso, Id = 1 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.EnEvaluacionPsicotecnica, Id = 2 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.EnEntrevistaTecnica, Id = 3 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.EnEntrevistaPersonal, Id = 4 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.Apto, Id = 5 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.NoApto, Id = 6 });
            estados.Add(new Valores { Descripcion = Constantes.EstadoPostulante.Contratado, Id = 7 });

            return estados;
        }
    }
}

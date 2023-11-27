using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;
using static UPN_ESDAT_FINAL.Common.Constantes;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmListaProcesoPostulante : Form
    {
        BLProcesoPostulante _blProcesoPostulante = new BLProcesoPostulante();
        BLProceso _blProceso = new BLProceso();
        BLPostulante _blPostulante = new BLPostulante();
        Utils _utils = new Utils();

        string _idProceso = "";
        string _proceso = "";
        string _estado = "";

        List<ProcesoPostulanteModel> listaPostulante = new List<ProcesoPostulanteModel>();

        public FrmListaProcesoPostulante(string idProceso, string proceso, string estado)
        {
            InitializeComponent();
            _idProceso = idProceso;
            _proceso = proceso;
            _estado = estado;
        }

        private void FrmListaProcesoPostulante_Load(object sender, EventArgs e)
        {
            txtProceso.Text = _proceso;
            lblEstado.Text = _estado;

            switch (_estado)
            {
                case Constantes.EstadoProceso.EnPausa:
                    lblEstado.BackColor = Color.LemonChiffon;
                    btnPausarProceso.Text = "Habilitar Proceso";
                    btnPausarProceso.Visible = true;
                    break;
                case Constantes.EstadoProceso.Inhabilitar:
                    lblEstado.BackColor = Color.IndianRed;
                    break;
                case Constantes.EstadoProceso.Finalizado:
                    lblEstado.BackColor = Color.LightGreen;
                    break;
                case Constantes.EstadoProceso.Activo:
                    btnFinalizarProceso.Visible = true;
                    btnInhabilitarProceso.Visible = true;
                    btnPausarProceso.Visible = true;
                    break;
            }

            listaPostulante = _blProcesoPostulante.BuscarPorIdProceso(_idProceso);

            // el método GroupBy agrupa los elementos de la lista por el campo IdPostulante.
            // Luego, el método Select se utiliza para seleccionar el último elemento de cada grupo,
            // lo que esencialmente elimina los duplicados basados en el campo IdPostulante.
            listaPostulante = listaPostulante.GroupBy(x => x.IdPostulante).Select(g => g.Last()).ToList();

            foreach (var item in listaPostulante)
            {
                var postulante = _blPostulante.BuscarPorId(item.IdPostulante);

                if (string.IsNullOrEmpty(postulante.Id)) continue;

                item.Nombres = $"{postulante.Nombres} {postulante.Apellidos}";
            }

            List<string> _ocultarColumnas = new List<string> { "IdProceso", "IdPostulante", "Id", "Observaciones" };
            Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
                { "Estado", 200 },
                { "Nombres", 250 }
            };
            Dictionary<string, string> _botones = new Dictionary<string, string>
            {
                { "btnVerEstado", "Ver Estados" }
            };

            _utils.CargarDatosEnGridView(dgvPostulantes, listaPostulante, _ocultarColumnas, true, _tamanioColumnas, null, _botones);
        }

        private void btnFinalizarProceso_Click(object sender, EventArgs e)
        {
            if (!listaPostulante.Any(x => x.Estado == Constantes.EstadoPostulante.Contratado))
            {
                _utils.MostrarMensaje("Ningún postulante ha sido contrado, para finalizar el proceso esto es indispensable.", Common.Enum.TipoMensaje.Informativo);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnInhabilitarProceso_Click(object sender, EventArgs e)
        {
            if (_utils.MostrarMensaje("¿Esta seguro de inhabilitar el proceso? Este paso desvinculará todos los postulantes.", Common.Enum.TipoMensaje.YesNoCancel))
            {
                _blProceso.ActualizarEstado(new ProcesoModel { Id = _idProceso, Estado = Constantes.EstadoProceso.Inhabilitar});

                foreach (var item in listaPostulante)
                {
                    _blPostulante.ActualizarEstado(new PostulanteModel { Id = item.IdPostulante, IdProceso = item.IdProceso, Estado = "" });
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnPausarProceso_Click(object sender, EventArgs e)
        {
            string mensaje = _estado == Constantes.EstadoProceso.EnPausa? "activar" : "pausar";

            if (_utils.MostrarMensaje($"¿Esta seguro de {mensaje} el proceso?", Common.Enum.TipoMensaje.YesNoCancel))
            {
                string estado = _estado == Constantes.EstadoProceso.EnPausa ? Constantes.EstadoProceso.Activo : Constantes.EstadoProceso.EnPausa;

                _blProceso.ActualizarEstado(new ProcesoModel { Id = _idProceso, Estado = estado });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

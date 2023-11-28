using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmAsignarProcesoPostulante : Form
    {
        BLProceso _blProceso = new BLProceso();
        BLPostulante _blPostulante = new BLPostulante();
        BLProcesoPostulante _blProcesoPostulante = new BLProcesoPostulante();

        Utils _utils = new Utils();
        Listas _listas = new Listas();

        PostulanteModel _postulante;
        List<ProcesoPostulanteModel> listaProcesoPostulante = new List<ProcesoPostulanteModel>();
        List<string> _ocultarColumnas = new List<string> { "Id", "IdArea", "Documentos", "DescripcionLarga", "Area" };
        Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
            { "DescripcionCorta", 250 },
            { "Area", 150 }
        };
        Dictionary<string, string> _botones = new Dictionary<string, string>
        {
            { "btnAsignar", "Asignar" }
        };

        public FrmAsignarProcesoPostulante(PostulanteModel postulanteModel)
        {
            InitializeComponent();
            _postulante = postulanteModel;
        }

        private void FrmAsignarProcesoPostulante_Load(object sender, EventArgs e)
        {
            try
            {
                lblPostulante.Text = $"{_postulante.Nombres} {_postulante.Apellidos}";
                lblDocumento.Text = _postulante.Dni;
                txtCV.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Postulante, _postulante.Id, Common.Enum.Extension.PDF);

                if (string.IsNullOrEmpty(_postulante.IdProceso))
                {
                    PostulanteSinProceso();
                    return;
                }

                // Postulante cuando ya tiene asignado un proceso
                ProcesoModel proceso = _blProceso.BuscarPorId(_postulante.IdProceso);

                if (string.IsNullOrEmpty(proceso.Id))
                {
                    _utils.MostrarMensaje("Hubo un problema al encontrar el proceso asignado", Common.Enum.TipoMensaje.Advertencia);
                    this.Close();
                }

                switch (proceso.Estado)
                {
                    case Constantes.EstadoProceso.Activo:
                    case Constantes.EstadoProceso.EnPausa:
                        ProcesoActivo();
                        break;
                    case Constantes.EstadoProceso.Finalizado:
                        ProcesoFinalizado();
                        break;
                }
            }
            catch (Exception ex)
            {
                _utils.MostrarMensaje($"Ocurrió un error, {ex.Message}", Common.Enum.TipoMensaje.Error);
            }
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            FrmVerDocumentoPDF frmVerDocumentoPDF = new FrmVerDocumentoPDF(txtCV.Text);
            frmVerDocumentoPDF.ShowDialog();
        }

        private void dgvProcesos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //846; 332
            foreach (var kvp in _botones)
            {
                string nombreBoton = kvp.Key;

                if (e.RowIndex >= 0 && e.ColumnIndex == dgvProcesos.Columns[nombreBoton].Index)
                {
                    // Manejar el clic del botón, pasando la fila correspondiente
                    // Puedes acceder a la fila de datos usando listaModel[e.RowIndex]
                    // Realiza la lógica de manejo del botón según tus necesidades
                    DataGridViewRow filaSeleccionada = dgvProcesos.Rows[e.RowIndex];

                    // Obtener los valores de las celdas en la fila seleccionada
                    string idProceso = filaSeleccionada.Cells["Id"].Value.ToString();

                    ProcesoModel procesoModel = _blProceso.BuscarPorId(idProceso);

                    FrmCrearProcesos frmCrearProcesos = new FrmCrearProcesos(procesoModel, _postulante, true);
                    frmCrearProcesos.Size = new System.Drawing.Size(846, 332);

                    if (frmCrearProcesos.ShowDialog() != DialogResult.OK) return;

                    _utils.MostrarMensaje("Postulante enlazado a proceso!", Common.Enum.TipoMensaje.Informativo);

                    ProcesoActivo();
                }
            }
        }

        private void PostulanteSinProceso()
        {
            List<ProcesoModel> procesos = _blProceso.ObtenerPorEstado(Constantes.EstadoProceso.Activo);

            _utils.CargarDatosEnGridView(dgvProcesos, procesos, _ocultarColumnas, false, _tamanioColumnas, null, _botones);
        }

        private void ProcesoFinalizado()
        {
            this.Close();
            FrmProcesoPostulante frmProcesoPostulante = new FrmProcesoPostulante(_postulante, true);
            frmProcesoPostulante.ShowDialog();
        }

        private void ProcesoActivo()
        {
            this.Close();
            FrmProcesoPostulante frmProcesoPostulante = new FrmProcesoPostulante(_postulante);
            frmProcesoPostulante.ShowDialog();
        }

        private void btnVerProceso_Click(object sender, EventArgs e)
        {
            ProcesoModel procesoModel = _blProceso.BuscarPorId(_postulante.IdProceso);

            FrmCrearProcesos frmCrearProcesos = new FrmCrearProcesos(procesoModel, _postulante, true, true);
            frmCrearProcesos.Size = new System.Drawing.Size(846, 332);
            frmCrearProcesos.ShowDialog();
        }
    }
}

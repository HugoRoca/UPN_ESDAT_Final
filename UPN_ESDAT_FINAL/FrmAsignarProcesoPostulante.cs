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
        BLPostulanteDetalle _blPostulanteDetalle = new BLPostulanteDetalle();
        Utils _utils = new Utils();
        Listas _listas = new Listas();

        List<PostulanteDetalleModel> listaPosDet = new List<PostulanteDetalleModel>();
        PostulanteModel _postulante;
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
            lblPostulante.Text = $"{_postulante.Nombres} {_postulante.Apellidos}";
            lblDocumento.Text = _postulante.Dni;
            txtCV.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Postulante, _postulante.Id, Common.Enum.Extension.PDF);

            if (_postulante.IdProceso == 0)
            {
                procesoEnProceso();
                return;
            }

            // Postulante cuando ya tiene asignado un proceso
            ProcesoModel proceso = _blProceso.BuscarPorId(_postulante.IdProceso);

            if (proceso.Id == 0)
            {
                _utils.MostrarMensaje("Hubo un problema al encontrar el proceso asignado", Common.Enum.TipoMensaje.Advertencia);
                this.Close();
            }

            switch (proceso.Estado)
            {
                case Constantes.EstadoProceso.Activo:
                    ProcesoActivo();
                    break;
                case Constantes.EstadoProceso.Finalizado:
                    ProcesoFinalizado();
                    break;
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
                    int idProceso = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());

                    ProcesoModel procesoModel = _blProceso.BuscarPorId(idProceso);

                    FrmCrearProcesos frmCrearProcesos = new FrmCrearProcesos(procesoModel, _postulante, true);
                    frmCrearProcesos.Size = new System.Drawing.Size(846, 332);

                    if (frmCrearProcesos.ShowDialog() != DialogResult.OK) return;

                    _utils.MostrarMensaje("Postulante enlazado a proceso!", Common.Enum.TipoMensaje.Informativo);

                    ProcesoActivo();
                }
            }
        }


        private void procesoEnProceso()
        {
            List<ProcesoModel> procesos = _blProceso.ObtenerPorEstado(Constantes.EstadoProceso.Activo);

            _utils.CargarDatosEnGridView(dgvProcesos, procesos, _ocultarColumnas, false, _tamanioColumnas, null, _botones);
        }

        private void ProcesoFinalizado()
        {
            panelNoTieneProceso.Visible = false;
            panelSiTieneProceso.Visible = false;
            panelProcesoContrado.Location = new System.Drawing.Point(14, 149);
        }

        private void ProcesoActivo()
        {
            panelNoTieneProceso.Visible = false;
            panelProcesoContrado.Visible = false;
            panelSiTieneProceso.Location = new System.Drawing.Point(14, 149);

            CargarEstadosPostulante();

            CargarGriViewEstados();

            txtObservaciones.Focus();
        }

        private void CargarGriViewEstados()
        {
            listaPosDet = _blPostulanteDetalle.ObtenerDetalle(_postulante.Id);

            List<string> _ocultarColumnas = new List<string> { "Id", "IdProceso", "IdPostulante" };
            List<string> _ordenColumnas = new List<string> { "Estado", "Observaciones" };
            Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
                { "Observaciones", 150 }
            };

            _utils.CargarDatosEnGridView(dgvEstadosPostulante, listaPosDet, _ocultarColumnas, true, _tamanioColumnas, _ordenColumnas, null);
        }

        private void CargarEstadosPostulante()
        {
            List<Valores> estados = _listas.EstadosPostulanteReclutador();

            cbEstados.DataSource = estados;
            cbEstados.DisplayMember = "Descripcion";
            cbEstados.ValueMember = "Id";
        }

        private void btnVerProceso_Click(object sender, EventArgs e)
        {
            ProcesoModel procesoModel = _blProceso.BuscarPorId(_postulante.IdProceso);

            FrmCrearProcesos frmCrearProcesos = new FrmCrearProcesos(procesoModel, _postulante, true);
            frmCrearProcesos.Size = new System.Drawing.Size(846, 332);
            frmCrearProcesos.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PostulanteDetalleModel posDet = new PostulanteDetalleModel();
            posDet.Id = _utils.GenerarId(_blPostulanteDetalle.ContarRegistros());
            posDet.IdPostulante = _postulante.Id;
            posDet.IdProceso = _postulante.IdProceso;
            posDet.Observaciones = txtObservaciones.Text;
            posDet.Estado = cbEstados.Text;

            PostulanteDetalleModel postulante = listaPosDet.FirstOrDefault(x => x.Estado == posDet.Estado) ?? new PostulanteDetalleModel();

            if (postulante.Id > 0)
            {
                if (_utils.MostrarMensaje("Solo debe existir un estado único por proceso, ¿Desea reemplazarlo?", Common.Enum.TipoMensaje.YesNoCancel))
                {
                    posDet.Id = postulante.Id;
                    posDet.Observaciones = posDet.Observaciones;

                    _blPostulanteDetalle.Actualizar(posDet);
                }
            } else
            {
                _blPostulanteDetalle.Insertar(posDet);
            }

            txtObservaciones.Clear();
            txtObservaciones.Focus();

            CargarGriViewEstados();
        }
    }
}

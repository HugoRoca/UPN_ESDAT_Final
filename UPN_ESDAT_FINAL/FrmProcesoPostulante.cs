using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmProcesoPostulante : Form
    {
        BLPostulante _blPostulante = new BLPostulante();
        BLProceso _blProceso = new BLProceso();
        BLProcesoPostulante _blProcesoPostulante = new BLProcesoPostulante();
        BLArea _blArea = new BLArea();
        Listas _listas = new Listas();
        Utils _utils = new Utils();

        PostulanteModel _postulanteModel = new PostulanteModel();
        List<ProcesoPostulanteModel> listaProcesoPostulante = new List<ProcesoPostulanteModel>();

        public FrmProcesoPostulante(PostulanteModel postulanteModel)
        {
            InitializeComponent();
            _postulanteModel = postulanteModel;
        }

        private void FrmProcesoPostulante_Load(object sender, EventArgs e)
        {
            txtObservacion.Focus();

            CargarEstadosPostulante();

            CargarGriViewEstados();

            txtIdPostulante.Text = _postulanteModel.Id;
            txtNombres.Text = _postulanteModel.Nombres;
            txtApellidos.Text = _postulanteModel.Apellidos;
            txtCelular.Text = _postulanteModel.Celular;
            txtDNICE.Text = _postulanteModel.Dni;
            txtCV.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Postulante, _postulanteModel.Id, Common.Enum.Extension.PDF);
            txtEmail.Text = _postulanteModel.Email;
            DateTime.ParseExact(_postulanteModel.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            ProcesoModel proceso = _blProceso.BuscarPorId(_postulanteModel.IdProceso);

            txtIdProceso.Text = proceso.Id;
            txtDescripcionCorta.Text = proceso.DescripcionCorta;
            txtDescripcionLarga.Text = proceso.DescripcionLarga;
            txtEstado.Text = proceso.Estado;
            txtDocumento.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Proceso, proceso.Id, Common.Enum.Extension.PDF);            
            txtArea.Text = _blArea.BuscarPorId(proceso.IdArea)?.Descripcion ?? "";
        }

        private void CargarEstadosPostulante()
        {
            List<Valores> estados = _listas.EstadosPostulanteTodos();

            cbEstado.DataSource = estados;
            cbEstado.DisplayMember = "Descripcion";
            cbEstado.ValueMember = "Id";
        }

        private void CargarGriViewEstados()
        {
            listaProcesoPostulante = _blProcesoPostulante.BuscarPorIdPostulanteYProceso(_postulanteModel.Id, _postulanteModel.IdProceso);

            List<string> _ocultarColumnas = new List<string> { "Id", "IdProceso", "IdPostulante", "Nombres" };
            List<string> _ordenColumnas = new List<string> { "Estado", "Observaciones" };
            Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
                { "Estado", 200 },
                { "Observaciones", 1000 }
            };

            _utils.CargarDatosEnGridView(dgvEstados, listaProcesoPostulante, _ocultarColumnas, true, _tamanioColumnas, _ordenColumnas, null);
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            FrmVerDocumentoPDF frmVerDocumentoPDF = new FrmVerDocumentoPDF(txtCV.Text);
            frmVerDocumentoPDF.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmVerDocumentoPDF frmVerDocumentoPDF = new FrmVerDocumentoPDF(txtDocumento.Text);
            frmVerDocumentoPDF.ShowDialog();
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            FrmVerDocumentoPDF frmVerDocumentoPDF = new FrmVerDocumentoPDF(txtDocumento.Text);
            frmVerDocumentoPDF.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProcesoModel procesoModel = _blProceso.BuscarPorId(_postulanteModel.IdProceso);

            if (procesoModel.Estado != Constantes.EstadoProceso.Activo)
            {
                _utils.MostrarMensaje("Para registrar estados el proceso debe estar activo!", Common.Enum.TipoMensaje.Informativo);
                return;
            }

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                _utils.MostrarMensaje("Debe completar el campo observaciones!", Common.Enum.TipoMensaje.Informativo);
                return;
            }

            ProcesoPostulanteModel posDet = new ProcesoPostulanteModel();
            posDet.Id = _utils.GenerarId();
            posDet.IdPostulante = _postulanteModel.Id;
            posDet.IdProceso = _postulanteModel.IdProceso;
            posDet.Observaciones = txtObservacion.Text;
            posDet.Estado = cbEstado.Text;

            ProcesoPostulanteModel postulante = listaProcesoPostulante.FirstOrDefault(x => x.Estado == posDet.Estado) ?? new ProcesoPostulanteModel();

            if (!string.IsNullOrEmpty(postulante.Id))
            {
                if (_utils.MostrarMensaje("Solo debe existir un estado único por proceso, ¿Desea reemplazarlo?", Common.Enum.TipoMensaje.YesNoCancel))
                {
                    posDet.Id = postulante.Id;
                    posDet.Observaciones = posDet.Observaciones;

                    _blProcesoPostulante.ActualizarObservacion(posDet);
                }
            }
            else
            {
                _blProcesoPostulante.Insertar(posDet);

                _postulanteModel.Estado = posDet.Estado;

                _blPostulante.ActualizarEstado(_postulanteModel);
            }

            txtObservacion.Clear();
            txtObservacion.Focus();

            CargarGriViewEstados();
        }
    }
}

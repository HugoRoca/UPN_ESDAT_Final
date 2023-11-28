using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmCrearProcesos : Form
    {
        BLArea _blArea = new BLArea();
        BLProceso _blProceso = new BLProceso();
        BLPostulante _blPostulante = new BLPostulante();
        BLProcesoPostulante _blProcesoPostulante = new BLProcesoPostulante();
        
        Utils _utils = new Utils();
        Listas _listas = new Listas();

        bool _desdeFrmAsignar = false;
        bool _soloVer = false;
        ProcesoModel _procesoModel = new ProcesoModel();
        PostulanteModel _postulanteModel = new PostulanteModel();
        Common.Enum.AccionBoton accion = Common.Enum.AccionBoton.Default;
        List<AreaModel> areas = new List<AreaModel>();
        List<Valores> estados = new List<Valores>();
        List<string> _ocultarColumnas = new List<string> { "Id", "IdArea" };
        List<string> _ordenColumnas = new List<string> { "Estado", "DescripcionCorta", "DescripcionLarga", "Documentos", "Area" };
        Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
            { "DescripcionCorta", 200 },
            { "DescripcionLarga", 400 }
        };

        public FrmCrearProcesos(ProcesoModel procesoModel, PostulanteModel postulanteModel, bool desdeFrmAsignar = false, bool soloVer = false)
        {
            InitializeComponent();
            _procesoModel = procesoModel;
            _postulanteModel = postulanteModel;
            _desdeFrmAsignar = desdeFrmAsignar;
            _soloVer = soloVer;
        }

        private void FrmCrearProcesos_Load(object sender, EventArgs e)
        {
            CargarCombo();
            TextboxAccion(false);

            if (_desdeFrmAsignar && string.IsNullOrEmpty(_postulanteModel.IdProceso))
            {
                txtIdProceso.Text = _procesoModel.Id.ToString();
                txtDescripcionCorta.Text = _procesoModel.DescripcionCorta;
                txtDescripcionLarga.Text = _procesoModel.DescripcionLarga;
                cbArea.SelectedIndex = _procesoModel.IdArea;
                txtDocumento.Text = _procesoModel.Documentos;

                cbEstado.SelectedIndex = estados.FirstOrDefault(x => x.Descripcion == _procesoModel.Estado).Id;

                if (!string.IsNullOrEmpty(txtDocumento.Text))
                {
                    txtDocumento.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Proceso, txtIdProceso.Text, Common.Enum.Extension.PDF);
                    btnVerPdf.Visible = true;
                    btnVerPdf.Enabled = true;
                }

                btnEliminar.Visible = false;
                btnGuardar.Visible = false;
                btnNuevo.Visible = false;

                if (_soloVer)
                {
                    lblProcesoFinalizado.Visible = true;
                    btnAsignarProceso.Text = "Cerrar";
                }

                btnAsignarProceso.Visible = true;

                return;
            }

            CargarGrid();

            cbArea.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }

        private List<ProcesoModel> ModelDatos(List<ProcesoModel> procesos)
        {
            foreach (var item in procesos)
            {
                item.Area = areas.Find(x => x.Id == item.IdArea)?.Descripcion ?? "";
            }

            return procesos;
        }

        private void TextboxAccion(bool valor, bool limpiar = true)
        {
            if (limpiar)
            {
                txtIdProceso.Clear();
                txtDescripcionCorta.Clear();
                txtDescripcionLarga.Clear();
                txtDocumento.Clear();
                cbArea.SelectedIndex = 0;
                cbEstado.SelectedIndex = 1;
            }

            txtDescripcionCorta.Enabled = valor;
            txtDescripcionLarga.Enabled = valor;
            cbEstado.Enabled = false;
            cbArea.Enabled = valor;
            btnSubir.Enabled = valor;
            btnVerPdf.Enabled = valor;

            txtDescripcionCorta.Focus();
        }

        private void CargarCombo()
        {
            estados = _listas.EstadosProceso();

            estados.Insert(0, new Valores { Descripcion = "Seleccione una opción", Id = 0 });

            List<AreaModel> areas = _blArea.ObtenerTodos();

            areas.Insert(0, new AreaModel { Descripcion = "Seleccione una opción", Id = 0 });

            // Asignar la lista de items al ComboBox
            cbEstado.DataSource = estados;
            cbArea.DataSource = areas;

            // Configurar las propiedades DisplayMember y ValueMember
            cbEstado.DisplayMember = "Descripcion";
            cbEstado.ValueMember = "Id";

            cbArea.DisplayMember = "Descripcion";
            cbArea.ValueMember = "Id";
        }

        private void CargarGrid()
        {
            List<ProcesoModel> procesos = _blProceso.ObtenerTodos();
            areas = _blArea.ObtenerTodos();

            procesos = ModelDatos(procesos);

            _utils.CargarDatosEnGridView(dgvProceso, procesos, _ocultarColumnas, false, _tamanioColumnas, _ordenColumnas);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnVerPdf.Visible = false;
            if (btnNuevo.Text == "Nuevo")
            {
                TextboxAccion(true);

                txtIdProceso.Text = _utils.GenerarId().ToString();

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Nuevo);

                cbEstado.SelectedIndex = 1;
            }
            else
            {
                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);
                TextboxAccion(false);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (accion == Common.Enum.AccionBoton.EditarEliminar)
            {
                TextboxAccion(true, false);
                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Editar);
                return;
            }

            if (!_utils.ValidarCamposGroupBox(gbDatosProceso))
            {
                _utils.MostrarMensaje("Debe de completar todos los campos!", Common.Enum.TipoMensaje.Error);
                return;
            }

            ProcesoModel procesoModel = new ProcesoModel();
            procesoModel.Id = txtIdProceso.Text;
            procesoModel.DescripcionCorta = txtDescripcionCorta.Text;
            procesoModel.DescripcionLarga = txtDescripcionLarga.Text;
            procesoModel.IdArea = (int)cbArea.SelectedValue;
            procesoModel.Estado = cbEstado.Text;

            // Documento
            procesoModel.Documentos = _utils.CopiarArchivo(txtDocumento.Text, Common.Enum.Extension.PDF, procesoModel.Id, Constantes.Carpetas.Proceso);

            switch (accion)
            {
                case Common.Enum.AccionBoton.Nuevo:
                    _blProceso.InsertarRegistro(procesoModel);
                    break;
                case Common.Enum.AccionBoton.Editar:
                    _blProceso.ActualizarRegistro(procesoModel);
                    break;
                case Common.Enum.AccionBoton.EditarEliminar:
                    TextboxAccion(true, false);
                    accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Editar);
                    return;
                case Common.Enum.AccionBoton.Default:
                    break;
                default:
                    break;
            }

            _utils.MostrarMensaje("Datos registrados correctamente!", Common.Enum.TipoMensaje.Informativo);

            CargarGrid();

            accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);

            TextboxAccion(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un valor en el cuadro de texto txtIdProceso
            if (!string.IsNullOrEmpty(txtIdProceso.Text))
            {
                if (!_utils.MostrarMensaje("¿Está seguro que desea eliminar le registro?", Common.Enum.TipoMensaje.YesNoCancel)) return;
                
                // Obtener los valores de las celdas en la fila seleccionada
                string Id = txtIdProceso.Text;

                _blProceso.EliminarRegistros(Id);

                CargarGrid();

                _utils.MostrarMensaje("Registro eliminado correctamente!", Common.Enum.TipoMensaje.Informativo);
            }
            else
            {
                _utils.MostrarMensaje("Seleccione un valor de la lista!", Common.Enum.TipoMensaje.Informativo);
            }
        }

        private void dgvProceso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (accion == Common.Enum.AccionBoton.Default || accion == Common.Enum.AccionBoton.EditarEliminar))
            {
                DataGridViewRow filaSeleccionada = dgvProceso.Rows[e.RowIndex];

                // Obtener los valores de las celdas en la fila seleccionada
                // Mostrar los valores en TextBox
                txtIdProceso.Text = filaSeleccionada.Cells["Id"].Value.ToString();
                txtDescripcionCorta.Text = filaSeleccionada.Cells["DescripcionCorta"].Value.ToString();
                txtDescripcionLarga.Text = filaSeleccionada.Cells["DescripcionLarga"].Value.ToString();
                cbArea.SelectedIndex = int.Parse(filaSeleccionada.Cells["IdArea"].Value.ToString());
                txtDocumento.Text = filaSeleccionada.Cells["Documentos"].Value.ToString();

                int estadoId = estados.Find(x => x.Descripcion == filaSeleccionada.Cells["Estado"].Value.ToString())?.Id ?? 0;
                cbEstado.SelectedIndex = estadoId;

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.EditarEliminar);

                if (!string.IsNullOrEmpty(txtDocumento.Text))
                {
                    txtDocumento.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Proceso, txtIdProceso.Text, Common.Enum.Extension.PDF);
                    btnVerPdf.Visible = true;
                }
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            // Configurar el diálogo para buscar archivos PDF
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF|*.pdf";
            openFileDialog.Title = "Seleccionar archivo PDF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mostrar la ruta seleccionada en el cuadro de texto
                txtDocumento.Text = openFileDialog.FileName;
                btnVerPdf.Visible = true;
            }
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            FrmVerDocumentoPDF frmVerDocumentoPDF = new FrmVerDocumentoPDF(txtDocumento.Text);
            frmVerDocumentoPDF.ShowDialog();
        }

        private void btnAsignarProceso_Click(object sender, EventArgs e)
        {
            if (_soloVer)
            {
                this.Close();
                return;
            }

            bool message = _utils.MostrarMensaje("¿Esta seguro de asignar este proceso al postulante?", Common.Enum.TipoMensaje.YesNoCancel);

            this.DialogResult = DialogResult.Cancel;

            if (message)
            {
                _postulanteModel.IdProceso = _procesoModel.Id;
                _blPostulante.Actualizar(_postulanteModel);

                _postulanteModel.IdProceso = _procesoModel.Id;
                _blPostulante.Actualizar(_postulanteModel);

                _blProcesoPostulante.Insertar(new ProcesoPostulanteModel
                {
                    Id = _utils.GenerarId(),
                    IdPostulante = _postulanteModel.Id,
                    IdProceso = _procesoModel.Id,
                    Estado = Constantes.EstadoPostulante.EnProceso,
                    Observaciones = $"Se vincula a proceso {_procesoModel.DescripcionCorta}"
                });

                _postulanteModel.Estado = Constantes.EstadoPostulante.EnProceso;

                _blPostulante.Actualizar(_postulanteModel);

                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}

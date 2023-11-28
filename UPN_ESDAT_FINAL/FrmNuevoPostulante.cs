using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmNuevoPostulante : Form
    {
        BLPostulante _blPostulante = new BLPostulante();
        Utils _utils = new Utils();

        Common.Enum.AccionBoton accion = Common.Enum.AccionBoton.Default;

        List<string> _ocultarColumnas = new List<string> { "Id", "Documentos", "IdProceso", "Estado" };
        List<string> _ordenColumnas = new List<string>();
        Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
            { "Nombres", 150 },
            { "Apellidos", 150 },
            { "Email", 200 }
        };

        bool _cerrarDespuesGuardar = false;
        string _documento = "";

        public FrmNuevoPostulante(bool cerrarDespuesGuardar = false, string documento = "")
        {
            InitializeComponent();
            _cerrarDespuesGuardar = cerrarDespuesGuardar;
            _documento = documento;
        }

        private void TextboxAccion(bool valor, bool limpiar = true)
        {
            if (limpiar)
            {
                txtIdPostulante.Clear();
                txtNombres.Clear();
                txtApellidos.Clear();
                txtEmail.Clear();
                txtCelular.Clear();
                txtCV.Clear();
                txtDNICE.Clear();
            }

            txtIdPostulante.Enabled = valor;
            txtNombres.Enabled = valor;
            txtApellidos.Enabled = valor;
            txtEmail.Enabled = valor;
            txtCelular.Enabled = valor;
            txtCV.Enabled = valor;
            txtDNICE.Enabled = valor;
            btnSubir.Enabled = valor;
            btnVerPdf.Enabled = valor;

            txtNombres.Focus();
        }

        private void FrmNuevoPostulante_Load(object sender, EventArgs e)
        {
            if (_cerrarDespuesGuardar)
            {
                TextboxAccion(true);

                txtIdPostulante.Text = _utils.GenerarId().ToString();
                txtDNICE.Text = _documento;
                txtDNICE.ReadOnly = true;

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Nuevo);

                return;
            }

            List<PostulanteModel> postulantes = _blPostulante.ObtenerTodos();

            _utils.CargarDatosEnGridView(dgvPostulante, postulantes, _ocultarColumnas, false, _tamanioColumnas, _ordenColumnas);

            TextboxAccion(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnVerPdf.Visible = false;
            if (btnNuevo.Text == "Nuevo")
            {
                TextboxAccion(true);

                txtIdPostulante.Text = _utils.GenerarId().ToString();

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Nuevo);
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

            if (!_utils.ValidarCamposGroupBox(gbDatos))
            {
                _utils.MostrarMensaje("Debe de completar todos los campos!", Common.Enum.TipoMensaje.Error);
                return;
            }

            PostulanteModel postulanteModel = new PostulanteModel();
            postulanteModel.Id = txtIdPostulante.Text;
            postulanteModel.Nombres = txtNombres.Text;
            postulanteModel.Apellidos = txtApellidos.Text;
            postulanteModel.Celular = txtCelular.Text;
            postulanteModel.Email = txtEmail.Text;
            postulanteModel.FechaNacimiento = dtpFechaNac.Value.ToString("yyyy-MM-dd");
            postulanteModel.Dni = txtDNICE.Text;

            // Documento
            postulanteModel.Documentos = _utils.CopiarArchivo(txtCV.Text, Common.Enum.Extension.PDF, postulanteModel.Id, Constantes.Carpetas.Postulante);

            switch (accion)
            {
                case Common.Enum.AccionBoton.Nuevo:
                    _blPostulante.Insertar(postulanteModel);
                    break;
                case Common.Enum.AccionBoton.Editar:
                    _blPostulante.Actualizar(postulanteModel);
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

            if (_cerrarDespuesGuardar)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            List<PostulanteModel> postulantes = _blPostulante.ObtenerTodos();

            _utils.CargarDatosEnGridView(dgvPostulante, postulantes, _ocultarColumnas, false, _tamanioColumnas, _ordenColumnas);

            accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);

            TextboxAccion(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un valor en el cuadro de texto txtIdProceso
            if (!string.IsNullOrEmpty(txtIdPostulante.Text))
            {
                if (!_utils.MostrarMensaje("¿Está seguro que desea eliminar le registro?", Common.Enum.TipoMensaje.YesNoCancel)) return;
                
                // Obtener los valores de las celdas en la fila seleccionada
                string Id = txtIdPostulante.Text;

                _blPostulante.Eliminar(Id);

                List<PostulanteModel> postulantes = _blPostulante.ObtenerTodos();

                _utils.CargarDatosEnGridView(dgvPostulante, postulantes, _ocultarColumnas, false, _tamanioColumnas, _ordenColumnas);

                _utils.MostrarMensaje("Registro eliminado correctamente!", Common.Enum.TipoMensaje.Informativo);
            }
            else
            {
                _utils.MostrarMensaje("Seleccione un valor de la lista!", Common.Enum.TipoMensaje.Informativo);
            }
        }

        private void dgvPostulante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (accion == Common.Enum.AccionBoton.Default || accion == Common.Enum.AccionBoton.EditarEliminar))
            {
                DataGridViewRow filaSeleccionada = dgvPostulante.Rows[e.RowIndex];

                // Obtener los valores de las celdas en la fila seleccionada
                // Mostrar los valores en TextBox
                txtIdPostulante.Text = filaSeleccionada.Cells["Id"].Value.ToString();
                txtNombres.Text = filaSeleccionada.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = filaSeleccionada.Cells["Apellidos"].Value.ToString();
                txtCelular.Text = filaSeleccionada.Cells["Celular"].Value.ToString();
                txtEmail.Text = filaSeleccionada.Cells["Email"].Value.ToString();
                txtCV.Text = filaSeleccionada.Cells["Documentos"].Value.ToString();
                dtpFechaNac.Value = DateTime.ParseExact(filaSeleccionada.Cells["FechaNacimiento"].Value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                txtDNICE.Text = filaSeleccionada.Cells["Dni"].Value.ToString();

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.EditarEliminar);

                if (!string.IsNullOrEmpty(txtCV.Text))
                {
                    txtCV.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Postulante, txtIdPostulante.Text, Common.Enum.Extension.PDF);
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
                txtCV.Text = openFileDialog.FileName;
                btnVerPdf.Visible = true;
            }
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            FrmVerDocumentoPDF frmVerDocumentoPDF = new FrmVerDocumentoPDF(txtCV.Text);
            frmVerDocumentoPDF.ShowDialog();
        }

        private void txtDNICE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

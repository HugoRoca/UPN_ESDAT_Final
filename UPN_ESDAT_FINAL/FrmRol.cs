using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmRol : Form
    {
        BLRol _blRol = new BLRol();
        Utils _utils = new Utils();
        Common.Enum.AccionBoton accion = Common.Enum.AccionBoton.Nuevo;

        public FrmRol()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text == "Nuevo")
            {
                int nuevoId = _blRol.ObtenerTotalRegistros();
                txtIdRol.Text = _utils.GenerarId(nuevoId).ToString();

                txtDescripcion.Enabled = true;
                txtDescripcion.Clear();
                txtDescripcion.Focus();

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Nuevo);
            }
            else
            {
                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);
                txtIdRol.Clear();
                txtDescripcion.Clear();
                txtDescripcion.Enabled = false;
            }           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdRol.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                _utils.MostrarMensaje("Debe de completar todos los campos!", Common.Enum.TipoMensaje.Informativo);
            }

            RolModel rolModel = new RolModel();
            rolModel.Id = int.Parse(txtIdRol.Text);
            rolModel.Descripcion = txtDescripcion.Text;

            switch (accion)
            {
                case Common.Enum.AccionBoton.Nuevo:
                    _blRol.InsertarRol(rolModel);
                    break;
                case Common.Enum.AccionBoton.Editar:
                    _blRol.ActualizarRol(rolModel);
                    break;
                case Common.Enum.AccionBoton.EditarEliminar:
                    txtDescripcion.Enabled = true;
                    accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Editar);
                    return;
                case Common.Enum.AccionBoton.Default:
                    break;
                default:
                    break;
            }

            _utils.MostrarMensaje("Datos registrados correctamente!", Common.Enum.TipoMensaje.Informativo);

            List<RolModel> rolModels = _blRol.ObtenerRoles();

            _utils.CargarDatosEnGridView(dgvRoles, rolModels, new List<string> { "Id" }, true);
            accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);

            txtIdRol.Clear();
            txtDescripcion.Clear();
            txtDescripcion.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un valor en el cuadro de texto tstRolId
            if (!string.IsNullOrEmpty(txtIdRol.Text))
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvRoles.SelectedRows[0];

                // Obtener los valores de las celdas en la fila seleccionada
                int Id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());

                _blRol.EliminarRol(Id);

                List<RolModel> rolModels = _blRol.ObtenerRoles();

                _utils.CargarDatosEnGridView(dgvRoles, rolModels, new List<string> { "Id" }, true);
            }
            else
            {
                _utils.MostrarMensaje("Seleccione un valor de la lista!", Common.Enum.TipoMensaje.Informativo);
            }
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            List<RolModel> rolModels = _blRol.ObtenerRoles();

            _utils.CargarDatosEnGridView(dgvRoles, rolModels, new List<string> { "Id" }, true);

            txtDescripcion.Enabled = false;
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvRoles.Rows[e.RowIndex];

                // Obtener los valores de las celdas en la fila seleccionada
                // Mostrar los valores en TextBox
                txtIdRol.Text = filaSeleccionada.Cells["Id"].Value.ToString();
                txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.EditarEliminar);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmUsuario : Form
    {
        BLUsuario _blUsuario = new BLUsuario();
        BLRol _blRol = new BLRol();
        Utils _utils = new Utils();

        Common.Enum.AccionBoton accion = Common.Enum.AccionBoton.Nuevo;

        List<RolModel> _Roles = new List<RolModel>();

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void TextboxAccion(bool valor, bool limpiar = true)
        {
            if (limpiar)
            {
                txtId.Clear();
                txtUsuario.Clear();
                txtPassword.Clear();
                txtNombres.Clear();
                txtApellidos.Clear();
                cbRol.SelectedIndex = 0;
            }

            txtUsuario.Enabled = valor;
            txtPassword.Enabled = valor;
            txtNombres.Enabled = valor;
            txtApellidos.Enabled = valor;
            cbRol.Enabled = valor;

            txtUsuario.Focus();
        }

        private void CargarCombo()
        {
            // Agregar el elemento predeterminado al inicio de la lista
            _Roles.Insert(0, new RolModel { Descripcion = "Seleccione una opción", Id = -1 });

            // Asignar la lista de items al ComboBox
            cbRol.DataSource = _Roles;
            // Configurar las propiedades DisplayMember y ValueMember
            cbRol.DisplayMember = "Descripcion";
            cbRol.ValueMember = "Id";
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            List<UsuarioModel> usuarios = _blUsuario.ObtenerUsuarios();
            _Roles = _blRol.ObtenerRoles();

            _utils.CargarDatosEnGridView(dgvUsuario, usuarios, new List<string> { "Id", "Password", "RolId" }, true);

            CargarCombo();
            TextboxAccion(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text == "Nuevo")
            {
                int nuevoId = _blUsuario.ObtenerTotalRegistros();

                TextboxAccion(true);

                txtId.Text = _utils.GenerarId(nuevoId).ToString();

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
            if (!_utils.ValidarCamposGroupBox(gbDatos))
            {
                _utils.MostrarMensaje("Debe de completar todos los campos!", Common.Enum.TipoMensaje.Error);
                return;
            }

            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Id = int.Parse(txtId.Text);
            usuarioModel.Usuario = txtUsuario.Text;
            usuarioModel.Password = txtPassword.Text;
            usuarioModel.Nombres = txtNombres.Text;
            usuarioModel.Apellidos = txtApellidos.Text;
            usuarioModel.RolId = (int)cbRol.SelectedValue;

            switch (accion)
            {
                case Common.Enum.AccionBoton.Nuevo:
                    _blUsuario.GuardarRegistro(usuarioModel);
                    break;
                case Common.Enum.AccionBoton.Editar:
                    _blUsuario.ActualizarRegistro(usuarioModel);
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

            List<UsuarioModel> usuarios = _blUsuario.ObtenerUsuarios();

            _utils.CargarDatosEnGridView(dgvUsuario, usuarios, new List<string> { "Id", "Password", "RolId" }, true);
            accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);

            TextboxAccion(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un valor en el cuadro de texto tstRolId
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                // Obtener los valores de las celdas en la fila seleccionada
                int Id = int.Parse(txtId.Text);

                _blRol.EliminarRol(Id);

                List<UsuarioModel> usuarios = _blUsuario.ObtenerUsuarios();

                _utils.CargarDatosEnGridView(dgvUsuario, usuarios, new List<string> { "Id", "Password", "RolId" }, true);
            }
            else
            {
                _utils.MostrarMensaje("Seleccione un valor de la lista!", Common.Enum.TipoMensaje.Informativo);
            }
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvUsuario.Rows[e.RowIndex];

                // Obtener los valores de las celdas en la fila seleccionada
                // Mostrar los valores en TextBox
                txtId.Text = filaSeleccionada.Cells["Id"].Value.ToString();
                txtUsuario.Text = filaSeleccionada.Cells["Usuario"].Value.ToString();
                txtPassword.Text = filaSeleccionada.Cells["Password"].Value.ToString();
                txtNombres.Text = filaSeleccionada.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = filaSeleccionada.Cells["Apellidos"].Value.ToString();
                cbRol.SelectedIndex = int.Parse(filaSeleccionada.Cells["RolId"].Value.ToString());

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.EditarEliminar);
            }
        }
    }
}

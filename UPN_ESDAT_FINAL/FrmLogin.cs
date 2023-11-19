using System;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BLUsuario _usuario = new BLUsuario();

            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar datos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioModel usuarioLogin = _usuario.ObtenerUsuario(txtUsuario.Text, txtPassword.Text);

            if (usuarioLogin == null || !(usuarioLogin.Usuario.Equals(txtUsuario.Text.ToUpper())))
            {
                MessageBox.Show("Usuario y/o contraseña inválida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BLRol bLRol = new BLRol();
            Utils utils = new Utils();

            RolModel rol = bLRol.ObtenerRolDescripcion(usuarioLogin.RolId);

            if (rol == null || rol.Descripcion == "")
            {
                utils.MostrarMensaje("No tienes configurado un Rol, contactate con el administrador!", Common.Enum.TipoMensaje.Error);
                return;
            }

            this.Hide();

            FrmPrincipal frmPrincipal = new FrmPrincipal(usuarioLogin);
            frmPrincipal.Text = $".::. Principal - Bienvenido {usuarioLogin.Usuario}";
            frmPrincipal.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

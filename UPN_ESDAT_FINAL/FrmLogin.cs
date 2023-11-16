using System;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
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
                MessageBox.Show("Debe ingresar datos!", "Error", MessageBoxButtons.OK);
                return;
            }

            UsuarioModel usuarioLogin = _usuario.ObtenerUsuario(txtUsuario.Text, txtPassword.Text);

            if (!(usuarioLogin.Usuario.Equals(txtUsuario.Text)))
            {
                MessageBox.Show("Acceso fallido", "Error", MessageBoxButtons.OK);
                return;
            }

            this.Visible = false;

            FrmPrincipal frmPrincipal = new FrmPrincipal(usuarioLogin);
            frmPrincipal.Show();
        }
    }
}

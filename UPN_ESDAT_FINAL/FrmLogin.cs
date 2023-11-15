using System;
using System.Windows.Forms;

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
            /*
            BLUsuario usuario = new BLUsuario();

            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar datos!", "Error", MessageBoxButtons.OK);
                return;
            }

            if (!usuario.Login(txtUsuario.Text, txtPassword.Text))
            {
                MessageBox.Show("Acceso fallido", "Error", MessageBoxButtons.OK);
                return;
            }
            */
            this.Visible = false;

            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.Show();
        }
    }
}

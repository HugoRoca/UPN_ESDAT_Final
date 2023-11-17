using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmPrincipal : Form
    {
        private readonly UsuarioModel _usuarioModel;
        public FrmPrincipal(UsuarioModel usuarioModel)
        {
            InitializeComponent();
            this._usuarioModel = usuarioModel;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            BLRol bLRol = new BLRol();

            tsslState.Text = $"HOLA {_usuarioModel.Nombres} {_usuarioModel.Apellidos} | ROL: {_usuarioModel.Rol}";

            List<RolPermisoModel> permisos = bLRol.ObtenerAccesoMenu(_usuarioModel.Rol);

            foreach (var item in menuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem toolStrip = (ToolStripMenuItem)item;

                    toolStrip.Visible = false;

                    if (Constantes.Menu.AlwaysAccess.Contains(toolStrip.Text)) toolStrip.Visible = true;

                    foreach (var permiso in permisos)
                    {
                        if (toolStrip.Text.ToLower() == permiso.DescripcionMenu.ToLower())
                        {
                            toolStrip.Visible = true;
                        }
                    }
                }
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Actions Menu
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();

            this.Hide();
        }
        #endregion
    }
}

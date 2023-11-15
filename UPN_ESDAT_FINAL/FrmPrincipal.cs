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
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            BLRol bLRol = new BLRol();

            List<RolPermisoModel> permisos = bLRol.ObtenerAccesoMenu("RECLUTA");

            foreach (var item in menuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem toolStrip = (ToolStripMenuItem)item;

                    /*
                    foreach (var permiso in permisos)
                    {
                        if (toolStrip.Text == permiso.IdMenu)
                        {
                            toolStrip.Visible = false;
                        }
                    }*/
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

        private void CallFrmLogin_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }
        #endregion

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

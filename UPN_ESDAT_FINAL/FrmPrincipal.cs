using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            foreach (var item in menuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem toolStrip = (ToolStripMenuItem)item;

                    if (toolStrip.Text == "&Archivo")
                    {
                        toolStrip.Visible = false;
                    }
                }
            }
            //MenuStrip strip = new MenuStrip();

            //ToolStripMenuItem fileItem = new ToolStripMenuItem("&Permisos");

            //// Create an array of ToolStripMenuItems
            //ToolStripMenuItem[] col = new ToolStripMenuItem[4];

            //// Populate the list with menus named "Menu 1" through "Menu 4"
            //for (int i = 0; i < 4; i++)
            //{
            //    col[i] = new ToolStripMenuItem("Menu " + (i + 1));

            //    // Make first item checked
            //    if (i == 0)
            //    {
            //        col[i].Checked = true;
            //    }

            //    // Disable second item
            //    if (i == 1)
            //    {
            //        col[i].Enabled = false;
            //    }

            //    // Set the image on the third item
            //    if (i == 2)
            //    {
            //        col[i].Image = Image.FromFile("C:\\Users\\hugor\\Downloads\\log_upn.png");
            //    }
            //}

            //var xxx = "CallFrmLogin_Click";
            //// Create menu item containing icon and a collection
            //ToolStripMenuItem collectionMenu = new ToolStripMenuItem("Collection", Image.FromFile("C:\\Users\\hugor\\Downloads\\login.png"), col);
            //ToolStripMenuItem usuarioMenu = new ToolStripMenuItem("Usuarios", Image.FromFile("C:\\Users\\hugor\\Downloads\\login.png"), xxx);
            //ToolStripMenuItem rolMenu = new ToolStripMenuItem("Roles");

            //fileItem.DropDownItems.Add(collectionMenu);
            //fileItem.DropDownItems.Add(usuarioMenu);
            //fileItem.DropDownItems.Add(rolMenu);

            //strip.Items.Add(fileItem);

            //this.Controls.Add(strip);
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

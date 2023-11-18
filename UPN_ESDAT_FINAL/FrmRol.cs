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
    public partial class FrmRol : Form
    {
        BLRol _blRol = new BLRol();

        public FrmRol()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            List<RolModel> rolModels = _blRol.ObtenerRoles();
        
            BindingList<RolModel> bindingRol = new BindingList<RolModel>(rolModels);

            dgvRoles.DataSource = bindingRol;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvRoles.AutoResizeColumns();
            dgvRoles.AllowUserToResizeColumns = true;
            dgvRoles.AllowUserToOrderColumns = true;
        }
    }
}

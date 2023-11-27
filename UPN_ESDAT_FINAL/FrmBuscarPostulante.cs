using System;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmBuscarPostulante : Form
    {
        BLPostulante _blPostulante = new BLPostulante();
        Utils _utils = new Utils();

        public FrmBuscarPostulante()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PostulanteModel postulante = _blPostulante.BuscarPorDocumento(txtDocumento.Text);

            if (postulante == null || string.IsNullOrEmpty(postulante.Dni))
            {
                if (!_utils.MostrarMensaje("El postulante no existe, ¿Desea registrarlo?", Common.Enum.TipoMensaje.YesNoCancel)) return;

                FrmNuevoPostulante frmNuevoPostulante = new FrmNuevoPostulante(true, txtDocumento.Text);
                frmNuevoPostulante.Size = new System.Drawing.Size(676, 274);
                frmNuevoPostulante.ShowDialog();    
            }

            postulante = _blPostulante.BuscarPorDocumento(txtDocumento.Text);

            FrmAsignarProcesoPostulante frmAsignarProcesoPostulante = new FrmAsignarProcesoPostulante(postulante);
            // Se asigna tamaño
            frmAsignarProcesoPostulante.Size = new System.Drawing.Size(500, 460);
            frmAsignarProcesoPostulante.ShowDialog();
        }

        private void FrmBuscarPostulante_Load(object sender, EventArgs e)
        {
            txtDocumento.Focus();
        }
    }
}

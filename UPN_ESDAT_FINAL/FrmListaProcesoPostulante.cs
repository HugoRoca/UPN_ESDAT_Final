using System;
using System.Drawing;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.Common;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmListaProcesoPostulante : Form
    {
        int _idProceso = 0;
        string _proceso = "";
        string _estado = "";

        public FrmListaProcesoPostulante(int idProceso, string proceso, string estado)
        {
            InitializeComponent();
            _idProceso = idProceso;
            _proceso = proceso;
            _estado = estado;
        }

        private void FrmListaProcesoPostulante_Load(object sender, EventArgs e)
        {
            txtProceso.Text = _proceso;
            lblEstado.Text = _estado;

            switch (_estado)
            {
                case Constantes.EstadoProceso.EnPausa:
                    lblEstado.BackColor = Color.LemonChiffon;
                    break;
                case Constantes.EstadoProceso.Inhabilitar:
                    lblEstado.BackColor = Color.IndianRed;
                    break;
                case Constantes.EstadoProceso.Finalizado:
                    lblEstado.BackColor = Color.LightGreen;
                    break;
            }
        }
    }
}

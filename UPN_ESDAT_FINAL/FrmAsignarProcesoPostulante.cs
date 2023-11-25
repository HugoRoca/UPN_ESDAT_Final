using System;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmAsignarProcesoPostulante : Form
    {
        BLProceso _blProceso = new BLProceso();
        Utils _utils = new Utils();

        PostulanteModel _postulante;

        public FrmAsignarProcesoPostulante(PostulanteModel postulanteModel)
        {
            InitializeComponent();
            _postulante = postulanteModel;
        }

        private void FrmAsignarProcesoPostulante_Load(object sender, EventArgs e)
        {
            // Se asigna tamaño
            this.Size = new System.Drawing.Size(500, 425);

            lblPostulante.Text = $"{_postulante.Nombres} {_postulante.Apellidos}";
            lblDocumento.Text = _postulante.Dni;
            txtCV.Text = _utils.ObtenerRutaArchivo(Constantes.Carpetas.Postulante, _postulante.Id, Common.Enum.Extension.PDF);

            if (_postulante.IdProceso == 0)
            {

            }

            ProcesoModel proceso = _blProceso.BuscarPorId(_postulante.IdProceso);


        }
    }
}

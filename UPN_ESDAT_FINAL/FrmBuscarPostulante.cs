using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
            try
            {
                if (rbDni.Checked)
                {
                    BuscarPorDNI(txtDocumento.Text);
                }
                else if (rbNombre.Checked)
                {
                    List<PostulanteModel> lista = _blPostulante.ObtenerTodos();
                    lista = lista.Where(item =>
                        item.Nombres.ToLower().Contains(txtDocumento.Text.ToLower()) ||
                        item.Apellidos.ToLower().Contains(txtDocumento.Text.ToLower())
                    ).ToList();

                    if (!lista.Any())
                    {
                        _utils.MostrarMensaje("No hay datos que coincidan con el texto de búsqueda.", Common.Enum.TipoMensaje.Informativo);
                        return;
                    }

                    FrmListaPostulante frmListaPostulante = new FrmListaPostulante(lista);
                    if (frmListaPostulante.ShowDialog() == DialogResult.OK)
                    {
                        BuscarPorDNI(frmListaPostulante._ValorRetornado);
                    }
                }
            }
            catch (Exception ex)
            {
                _utils.MostrarMensaje($"Ocurrió un error, {ex.Message}", Common.Enum.TipoMensaje.Error);
            }
        }

        private void BuscarPorDNI(string documento)
        {
            if (string.IsNullOrEmpty(documento)) {
                _utils.MostrarMensaje("Debe ingresar un valor en el campo documento!", Common.Enum.TipoMensaje.Informativo);
                return;
            }

            bool esValido = Regex.IsMatch(documento, "^[0-9]+$");

            if (!esValido)
            {
                _utils.MostrarMensaje("Debe ingresar solo números!", Common.Enum.TipoMensaje.Informativo);
                return;
            }

            PostulanteModel postulante = _blPostulante.BuscarPorDocumento(documento);

            if (postulante == null || string.IsNullOrEmpty(postulante.Dni))
            {
                if (!_utils.MostrarMensaje("El postulante no existe, ¿Desea registrarlo?", Common.Enum.TipoMensaje.YesNoCancel)) return;

                FrmNuevoPostulante frmNuevoPostulante = new FrmNuevoPostulante(true, documento);
                frmNuevoPostulante.Size = new System.Drawing.Size(676, 274);

                if (frmNuevoPostulante.ShowDialog() != DialogResult.OK) return;
            }
            postulante = _blPostulante.BuscarPorDocumento(documento);

            FrmAsignarProcesoPostulante frmAsignarProcesoPostulante = new FrmAsignarProcesoPostulante(postulante);
            // Se asigna tamaño
            frmAsignarProcesoPostulante.ShowDialog();
        }

        private void FrmBuscarPostulante_Load(object sender, EventArgs e)
        {
            txtDocumento.Focus();
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtDocumento.Clear();
            txtDocumento.Focus();
        }

        private void rbDni_CheckedChanged(object sender, EventArgs e)
        {
            txtDocumento.Clear();
            txtDocumento.Focus();
        }
    }
}

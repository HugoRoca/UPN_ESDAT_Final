using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmListaPostulante : Form
    {
        // Propiedad para almacenar el valor a retornar
        public string _ValorRetornado { get; private set; }

        Utils _utils = new Utils();

        List<PostulanteModel> _postulantes;
        List<string> _ocultarColumnas = new List<string> { "Id", "Documentos", "IdProceso", "FechaNacimiento", "Email", "Celular" };
        Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
            { "Nombres", 180 },
            { "Estado", 165},
            { "Apellidos", 200 },
            { "Seleccionar", 1000 }
        };
        Dictionary<string, string> _botones = new Dictionary<string, string>
        {
            { "btnSeleccionar", "Seleccionar" }
        };

        public FrmListaPostulante(List<PostulanteModel> postulantes)
        {
            InitializeComponent();
            _postulantes = postulantes;
        }

        private void FrmListaPostulante_Load(object sender, EventArgs e)
        {
            _utils.CargarDatosEnGridView(dgvPostulantes, _postulantes, _ocultarColumnas, false, _tamanioColumnas, null, _botones);
        }

        private void dgvPostulantes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Obtener el estado de la fila actual
            string idProceso = dgvPostulantes.Rows[e.RowIndex].Cells["IdProceso"].Value.ToString();
            string estado = dgvPostulantes.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

            // Establecer el color de fondo de la fila según el estado
            if (!string.IsNullOrEmpty(idProceso))
            {
                if (estado == Constantes.EstadoPostulante.Contratado)
                {
                    dgvPostulantes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dgvPostulantes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
            }
        }

        private void dgvPostulantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var kvp in _botones)
            {
                string nombreBoton = kvp.Key;

                if (e.RowIndex >= 0 && e.ColumnIndex == dgvPostulantes.Columns[nombreBoton].Index)
                {
                    // Manejar el clic del botón, pasando la fila correspondiente
                    // Puedes acceder a la fila de datos usando listaModel[e.RowIndex]
                    // Realiza la lógica de manejo del botón según tus necesidades
                    DataGridViewRow filaSeleccionada = dgvPostulantes.Rows[e.RowIndex];

                    // Obtener los valores de las celdas en la fila seleccionada
                    // Mostrar los valores en TextBox
                    string documento = filaSeleccionada.Cells["Dni"].Value.ToString();
                    string estado = filaSeleccionada.Cells["Estado"].Value.ToString();

                    if (estado == Constantes.EstadoPostulante.Contratado)
                    {
                        _utils.MostrarMensaje("El postulante ya esta contratado!", Common.Enum.TipoMensaje.Informativo);
                        return;
                    }

                    this._ValorRetornado = documento;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}

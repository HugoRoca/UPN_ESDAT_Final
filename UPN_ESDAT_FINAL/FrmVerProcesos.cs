using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmVerProcesos : Form
    {
        BLProceso _blProceso = new BLProceso();
        BLArea _blArea = new BLArea();
        Utils _utils = new Utils();
        Listas _listas = new Listas();

        List<AreaModel> areas = new List<AreaModel>();
        List<Valores> estados = new List<Valores>();
        List<string> _ocultarColumnas = new List<string> { "Id", "IdArea", "Documentos" };
        List<string> _ordenColumnas = new List<string> { "Ver Proceso", "Estado", "DescripcionCorta", "DescripcionLarga", "Area" };
        Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
            { "DescripcionCorta", 250 },
            { "DescripcionLarga", 550 },
            { "Area", 150 }
        };
        Dictionary<string, string> _botones = new Dictionary<string, string>
        {
            { "btnVerProceso", "Ver Proceso" }
        };

        public FrmVerProcesos()
        {
            InitializeComponent();
        }

        private void FrmVerProcesos_Load(object sender, EventArgs e)
        {
            estados = _listas.EstadosProceso();

            estados.Insert(0, new Valores { Descripcion = "Seleccione una opción", Id = 0 });

            // Asignar la lista de items al ComboBox
            cbEstado.DataSource = estados;

            // Configurar las propiedades DisplayMember y ValueMember
            cbEstado.DisplayMember = "Descripcion";
            cbEstado.ValueMember = "Id";

            List<ProcesoModel> procesos = _blProceso.ObtenerTodos();
            areas = _blArea.ObtenerTodos();

            foreach (var item in procesos)
            {
                item.Area = areas.Find(x => x.Id == item.IdArea)?.Descripcion ?? "";
            }

            _utils.CargarDatosEnGridView(dgvProceso, procesos, _ocultarColumnas, true, _tamanioColumnas, _ordenColumnas, _botones);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string estado = cbEstado.SelectedIndex <= 0 ? "" : cbEstado.Text;

            List<ProcesoModel> procesos = _blProceso.ObtenerPorEstado(estado);

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string filtro = txtBuscar.Text;
                procesos = procesos.Where(item => item.DescripcionCorta.ToLower().Contains(filtro.ToLower())).ToList();
            }

            foreach (var pro in procesos)
            {
                pro.Area = areas.Find(x => x.Id == pro.IdArea)?.Descripcion ?? "";
            }

            _utils.CargarDatosEnGridView(dgvProceso, procesos, _ocultarColumnas, true, _tamanioColumnas, _ordenColumnas, _botones);
        }

        private void dgvProceso_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Obtener el estado de la fila actual
            string estado = dgvProceso.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

            // Establecer el color de fondo de la fila según el estado
            switch (estado)
            {
                case Constantes.EstadoProceso.EnPausa:
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LemonChiffon;
                    break;
                case Constantes.EstadoProceso.Finalizado:
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case Constantes.EstadoProceso.Inhabilitar:
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
                    break;
                default:
                    // Restablecer el color de fondo si el estado no coincide con ninguna condición anterior
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }

        private void dgvProceso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var kvp in _botones)
            {
                string nombreBoton = kvp.Key;

                if (e.RowIndex >= 0 && e.ColumnIndex == dgvProceso.Columns[nombreBoton].Index)
                {
                    // Manejar el clic del botón, pasando la fila correspondiente
                    // Puedes acceder a la fila de datos usando listaModel[e.RowIndex]
                    // Realiza la lógica de manejo del botón según tus necesidades
                    DataGridViewRow filaSeleccionada = dgvProceso.Rows[e.RowIndex];

                    // Obtener los valores de las celdas en la fila seleccionada
                    // Mostrar los valores en TextBox
                    string proceso = filaSeleccionada.Cells["DescripcionCorta"].Value.ToString();
                    string estado = filaSeleccionada.Cells["Estado"].Value.ToString();
                    string idProceso = filaSeleccionada.Cells["Id"].Value.ToString();

                    FrmListaProcesoPostulante frmListaProcesoPostulante = new FrmListaProcesoPostulante(idProceso, proceso, estado);
                    
                    if (frmListaProcesoPostulante.ShowDialog() == DialogResult.OK)
                    {
                        btnBuscar_Click(sender, e);
                    }
                }
            }
        }
    }
}

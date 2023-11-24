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

        List<AreaModel> areas = new List<AreaModel>();
        List<EstadoProcesoModel> estados =  new List<EstadoProcesoModel>();
        List<string> _ocultarColumnas = new List<string> { "Id", "IdArea", "Documentos" };
        List<string> _ordenColumnas = new List<string> { "Estado", "DescripcionCorta", "DescripcionLarga", "Documentos", "Area" };
        Dictionary<string, int> _tamanioColumnas = new Dictionary<string, int> {
            { "DescripcionCorta", 300 },
            { "DescripcionLarga", 650 }
        };

        public FrmVerProcesos()
        {
            InitializeComponent();
        }

        private void CargaEstados()
        {
            // Agregar el elemento predeterminado al inicio de la lista
            estados.Insert(0, new EstadoProcesoModel { Descripcion = "TODOS", Id = 0 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.Activo, Id = 1 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.EnPausa, Id = 2 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.Inhabilitar, Id = 3 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.Finalizado, Id = 4 });
        }

        private void FrmVerProcesos_Load(object sender, EventArgs e)
        {
            CargaEstados();

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

            _utils.CargarDatosEnGridView(dgvProceso, procesos, _ocultarColumnas, true, _tamanioColumnas, _ordenColumnas);
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

            _utils.CargarDatosEnGridView(dgvProceso, procesos, _ocultarColumnas, true, _tamanioColumnas, _ordenColumnas);
        }

        private void dgvProceso_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Obtener el estado de la fila actual
            string estado = dgvProceso.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

            // Establecer el color de fondo de la fila según el estado
            switch (estado)
            {
                case Constantes.EstadoProceso.EnPausa:
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
                    break;
                case Constantes.EstadoProceso.Finalizado:
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SpringGreen;
                    break;
                case Constantes.EstadoProceso.Inhabilitar:
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.HotPink;
                    break;
                default:
                    // Restablecer el color de fondo si el estado no coincide con ninguna condición anterior
                    dgvProceso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }
    }
}

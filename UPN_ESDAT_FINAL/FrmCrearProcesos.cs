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
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmCrearProcesos : Form
    {
        BLArea _blArea = new BLArea();
        

        public FrmCrearProcesos()
        {
            InitializeComponent();
        }

        private void FrmCrearProcesos_Load(object sender, EventArgs e)
        {
            
            
            CargarCombo();
        }

        private void CargarCombo()
        {
            List<EstadoProcesoModel> estados = new List<EstadoProcesoModel>();
            List<AreaModel> areas = _blArea.ObtenerTodos();

            // Agregar el elemento predeterminado al inicio de la lista
            estados.Insert(0, new EstadoProcesoModel { Descripcion = "Seleccione una opción", Id = -1 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.Activo, Id = 1 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.EnPausa, Id = 2 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.Inhabilitar, Id = 3 });
            estados.Add(new EstadoProcesoModel { Descripcion = Constantes.EstadoProceso.Finalizado, Id = 4 });

            areas.Insert(0, new AreaModel { Descripcion = "Seleccione una opción", Id = -1 });

            // Asignar la lista de items al ComboBox
            cbEstado.DataSource = estados;
            cbArea.DataSource = areas;

            // Configurar las propiedades DisplayMember y ValueMember
            cbEstado.DisplayMember = "Descripcion";
            cbEstado.ValueMember = "Id";

            cbArea.DisplayMember = "Descripcion";
            cbArea.ValueMember = "Id";
        }
    }
}

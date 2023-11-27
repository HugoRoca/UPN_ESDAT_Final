using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.BusinessLogic;
using UPN_ESDAT_FINAL.Common;
using UPN_ESDAT_FINAL.Model;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmRol : Form
    {
        BLRol _blRol = new BLRol();
        BLMenu _blMenu = new BLMenu();

        Utils _utils = new Utils();

        Common.Enum.AccionBoton accion = Common.Enum.AccionBoton.Nuevo;

        public FrmRol()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text == "Nuevo")
            {
                txtIdRol.Text = _utils.GenerarId().ToString();

                txtDescripcion.Enabled = true;
                txtDescripcion.Clear();
                txtDescripcion.Focus();

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Nuevo);
            }
            else
            {
                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);
                txtIdRol.Clear();
                txtDescripcion.Clear();
                txtDescripcion.Enabled = false;
            }           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdRol.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                _utils.MostrarMensaje("Debe de completar todos los campos!", Common.Enum.TipoMensaje.Informativo);
            }

            RolModel rolModel = new RolModel();
            rolModel.Id = int.Parse(txtIdRol.Text);
            rolModel.Descripcion = txtDescripcion.Text;

            List<TreeNode> nodosMarcados = ObtenerNodosMarcados(tvOpciones);

            switch (accion)
            {
                case Common.Enum.AccionBoton.Nuevo:
                    _blRol.InsertarRol(rolModel);
                    break;
                case Common.Enum.AccionBoton.Editar:
                    _blRol.ActualizarRol(rolModel);
                    break;
                case Common.Enum.AccionBoton.EditarEliminar:
                    txtDescripcion.Enabled = true;
                    accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Editar);
                    return;
                case Common.Enum.AccionBoton.Default:
                    break;
                default:
                    break;
            }

            _utils.MostrarMensaje("Datos registrados correctamente!", Common.Enum.TipoMensaje.Informativo);

            List<RolModel> rolModels = _blRol.ObtenerRoles();

            _utils.CargarDatosEnGridView(dgvRoles, rolModels, new List<string> { "Id" }, true);
            accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.Default);

            txtIdRol.Clear();
            txtDescripcion.Clear();
            txtDescripcion.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un valor en el cuadro de texto tstRolId
            if (!string.IsNullOrEmpty(txtIdRol.Text))
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvRoles.SelectedRows[0];

                // Obtener los valores de las celdas en la fila seleccionada
                int Id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());

                _blRol.EliminarRol(Id);

                List<RolModel> rolModels = _blRol.ObtenerRoles();

                _utils.CargarDatosEnGridView(dgvRoles, rolModels, new List<string> { "Id" }, true);
            }
            else
            {
                _utils.MostrarMensaje("Seleccione un valor de la lista!", Common.Enum.TipoMensaje.Informativo);
            }
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            List<RolModel> rolModels = _blRol.ObtenerRoles();

            _utils.CargarDatosEnGridView(dgvRoles, rolModels, new List<string> { "Id" }, true);

            txtDescripcion.Enabled = false;

            CargarDatosEnTreeView(0);
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvRoles.Rows[e.RowIndex];

                // Obtener los valores de las celdas en la fila seleccionada
                // Mostrar los valores en TextBox
                txtIdRol.Text = filaSeleccionada.Cells["Id"].Value.ToString();
                txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();

                CargarDatosEnTreeView(int.Parse(txtIdRol.Text));

                accion = _utils.Botones(btnNuevo, btnGuardar, btnEliminar, Common.Enum.AccionBoton.EditarEliminar);
            }
        }

        private void CargarDatosEnTreeView(int idRol)
        {
            tvOpciones.Nodes.Clear();

            // Obtener datos simulados (puedes reemplazar esto con tu lógica para obtener datos reales)
            List<MenuModel> listaMenus = _blMenu.Obtener();
            List<RolPermisoModel> permisosRol = _blRol.ObtenerAccesoMenu(idRol);

            // Construir el árbol y agregarlo al TreeView
            foreach (var menu in listaMenus)
            {
                if (menu.IdPadre == 0) // Es un nodo padre
                {
                    TreeNode nodoPadre = ConstruirNodoConPermisos(menu, permisosRol, listaMenus);
                    tvOpciones.Nodes.Add(nodoPadre);
                }
            }

            tvOpciones.ExpandAll();
        }

        private TreeNode ConstruirNodoConPermisos(MenuModel menu, List<RolPermisoModel> permisosRol, List<MenuModel> listaMenus)
        {
            TreeNode nodoPadre = new TreeNode(menu.Descripcion);

            // Verificar si el menú actual tiene permisos asignados al rol
            if (TienePermiso(menu.Id, permisosRol))
            {
                // El rol tiene permisos para este menú, así que lo marcamos
                nodoPadre.Checked = true;
            }

            // Construir nodos hijos recursivamente
            ConstruirNodosHijosConPermisos(menu.Id, nodoPadre, permisosRol, listaMenus);

            return nodoPadre;
        }

        private void ConstruirNodosHijosConPermisos(int idPadre, TreeNode nodoPadre, List<RolPermisoModel> permisosRol, List<MenuModel> listaMenus)
        {
            // Obtener los menús hijos para el nodo padre actual
            List<MenuModel> hijos = ObtenerMenusHijos(idPadre, listaMenus);

            foreach (var menu in hijos)
            {
                TreeNode nodoHijo = ConstruirNodoConPermisos(menu, permisosRol, listaMenus);

                // Agregar el nodo hijo al nodo padre
                nodoPadre.Nodes.Add(nodoHijo);

                // Llamada recursiva para construir nodos hijos de este nodo hijo
                ConstruirNodosHijosConPermisos(menu.Id, nodoHijo, permisosRol, listaMenus);
            }
        }

        private List<MenuModel> ObtenerMenusHijos(int idPadre, List<MenuModel> listaMenus)
        {
            // Lógica para obtener los menús hijos de un nodo padre específico
            // Puedes reemplazar esto con tu lógica real para obtener los menús hijos de la base de datos, por ejemplo.
            return listaMenus.Where(x => x.IdPadre == idPadre).ToList();
        }

        private bool TienePermiso(int idMenu, List<RolPermisoModel> permisosRol)
        {
            // Verificar si el rol tiene permisos para el menú específico
            return permisosRol.Any(permiso => permiso.IdMenu == idMenu);
        }

        private List<TreeNode> ObtenerNodosMarcados(TreeView treeView)
        {
            List<TreeNode> nodosMarcados = new List<TreeNode>();

            // Recorrer todos los nodos del árbol
            foreach (TreeNode nodoPadre in treeView.Nodes)
            {
                ObtenerNodosMarcadosRecursivo(nodoPadre, nodosMarcados);
            }

            return nodosMarcados;
        }

        private void ObtenerNodosMarcadosRecursivo(TreeNode nodo, List<TreeNode> nodosMarcados)
        {
            // Verificar si el nodo actual está marcado
            if (nodo.Checked)
            {
                nodosMarcados.Add(nodo);
            }

            // Llamada recursiva para los nodos hijos
            foreach (TreeNode nodoHijo in nodo.Nodes)
            {
                ObtenerNodosMarcadosRecursivo(nodoHijo, nodosMarcados);
            }
        }
    }
}

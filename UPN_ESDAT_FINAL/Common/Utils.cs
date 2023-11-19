using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;

namespace UPN_ESDAT_FINAL.Common
{
    public class Utils
    {
        public int GenerarId(int id)
        {
            return id + 1;
        }

        public Enum.AccionBoton Botones(Button btnNuevo, Button btnGuardar, Button btnEliminar, Enum.AccionBoton _enum)
        {
            switch (_enum)
            {
                case Enum.AccionBoton.Nuevo:
                case Enum.AccionBoton.Editar:
                    btnNuevo.Text = "Cancelar";
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    break;
                case Enum.AccionBoton.EditarEliminar:
                    btnNuevo.Text = "Cancelar";
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                    break;
                case Enum.AccionBoton.Default:
                    btnNuevo.Text = "Nuevo";
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    break;
            }

            return _enum;
        }

        public bool EsNuevo(Button button)
        {
            return button.Text == "Nuevo";
        }

        public bool MostrarMensaje(string texto, Enum.TipoMensaje _enum)
        {
            switch (_enum)
            {
                case Enum.TipoMensaje.Informativo:
                    MessageBox.Show(texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Enum.TipoMensaje.Advertencia:
                    MessageBox.Show(texto, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Enum.TipoMensaje.Error:
                    MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Enum.TipoMensaje.YesNoCancel:
                    DialogResult dialogResult = MessageBox.Show(texto, "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    return dialogResult == DialogResult.Yes;
                default:
                    break;
            }

            return true;
        }

        public void MostrarDatosEnGridView<T>(DataGridView dataGridView, List<T> listaModel)
        {
            // Limpiar las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            // Obtener las propiedades del tipo T
            PropertyInfo[] propiedades = typeof(T).GetProperties();

            // Iterar sobre la lista y agregar las filas al DataGridView
            foreach (var item in listaModel)
            {
                DataGridViewRow fila = new DataGridViewRow();

                // Iterar sobre las propiedades y agregar celdas a la fila
                foreach (var propiedad in propiedades)
                {
                    DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
                    celda.Value = propiedad.GetValue(item)?.ToString() ?? ""; // Manejar valores nulos

                    fila.Cells.Add(celda);
                }

                // Agregar la fila al DataGridView
                dataGridView.Rows.Add(fila);
            }
        }
    }
}

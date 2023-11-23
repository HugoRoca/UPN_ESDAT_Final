using System.Collections.Generic;
using System.Linq;
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

        public string GenerarFormatoDocumento(int id, string nombre)
        {
            // Definir la cantidad máxima de ceros a la izquierda
            int cantidadCeros = 6; // Puedes ajustar este valor según tus necesidades

            // Formatear el número con ceros a la izquierda
            string formatoId = id.ToString($"D{cantidadCeros}");

            // Combinar el formato y el nombre
            string resultado = $"P{formatoId}_{nombre}";

            return resultado;
        }

        public Enum.AccionBoton Botones(Button btnNuevo, Button btnGuardar, Button btnEliminar, Enum.AccionBoton _enum)
        {
            switch (_enum)
            {
                case Enum.AccionBoton.Nuevo:
                case Enum.AccionBoton.Editar:
                    btnNuevo.Text = "Cancelar";
                    btnGuardar.Enabled = true;
                    btnGuardar.Text = "Guardar";
                    btnEliminar.Enabled = false;
                    break;
                case Enum.AccionBoton.EditarEliminar:
                    btnNuevo.Text = "Nuevo";
                    btnGuardar.Text = "Editar";
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                    break;
                case Enum.AccionBoton.Default:
                    btnNuevo.Text = "Nuevo";
                    btnGuardar.Text = "Guardar";
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

        public bool ValidarCamposGroupBox(GroupBox groupBox)
        {
            // Verificar que todos los TextBox no estén vacíos
            bool todosTextBoxNoVacios = groupBox.Controls.OfType<TextBox>().All(textBox => !string.IsNullOrEmpty(textBox.Text));

            // Verificar que el ComboBox tenga un índice seleccionado
            bool comboBoxSeleccionado = groupBox.Controls.OfType<ComboBox>().Any(comboBox => comboBox.SelectedIndex > 0);

            // Devolver true si todos los TextBox no están vacíos y el ComboBox tiene un índice seleccionado
            return todosTextBoxNoVacios && comboBoxSeleccionado;
        }

        public void CargarDatosEnGridView<T>(DataGridView dataGridView, List<T> listaModel, 
            List<string> columnasOcultar = null, bool ultimaColumnaFill = false,
            Dictionary<string, int> tamanosColumnas = null, List<string> ordenColumnas = null)
        {
            // Limpiar filas existentes
            dataGridView.Rows.Clear();

            // Limpiar columnas existentes
            dataGridView.Columns.Clear();

            // Obtener las propiedades del primer elemento en la lista
            PropertyInfo[] propiedades = listaModel.First().GetType().GetProperties();

            // Configurar las columnas del DataGridView basándose en las propiedades
            foreach (var propiedad in propiedades)
            {
                // Agregar columnas al DataGridView con el nombre de la propiedad
                dataGridView.Columns.Add(propiedad.Name, propiedad.Name);
            }

            // Agregar filas al DataGridView basándose en los elementos de la lista
            foreach (var item in listaModel)
            {
                DataGridViewRow fila = new DataGridViewRow();

                foreach (var propiedad in propiedades)
                {
                    DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
                    celda.Value = propiedad.GetValue(item)?.ToString() ?? ""; // Manejar valores nulos
                    fila.Cells.Add(celda);
                }

                dataGridView.Rows.Add(fila);
            }

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            // dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle1;

            columnasOcultar = columnasOcultar ?? new List<string>();

            if (columnasOcultar.Count > 0)
            {
                // Ocultar las columnas en la lista
                foreach (string columna in columnasOcultar)
                {
                    if (dataGridView.Columns.Contains(columna))
                    {
                        dataGridView.Columns[columna].Visible = false;
                    }
                }
            }

            // Ajustar la última columna para ocupar todo el espacio disponible
            if (dataGridView.Columns.Count > 0 && ultimaColumnaFill)
            {
                dataGridView.Columns[dataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Ordenar las columnas según la lista proporcionada
            if (ordenColumnas != null && ordenColumnas.Count > 0)
            {
                foreach (string columna in ordenColumnas)
                {
                    if (dataGridView.Columns.Contains(columna))
                    {
                        dataGridView.Columns[columna].DisplayIndex = ordenColumnas.IndexOf(columna);
                    }
                }
            }

            // Establecer tamaños personalizados para las columnas
            if (tamanosColumnas != null && tamanosColumnas.Count > 0)
            {
                foreach (var kvp in tamanosColumnas)
                {
                    if (dataGridView.Columns.Contains(kvp.Key))
                    {
                        dataGridView.Columns[kvp.Key].Width = kvp.Value;
                    }
                }
            }
        }
    }
}

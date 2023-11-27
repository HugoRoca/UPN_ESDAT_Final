using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace UPN_ESDAT_FINAL.Common
{
    public class Utils
    {
        public string GenerarId()
        {
            Guid uniqueId = Guid.NewGuid();
            return uniqueId.ToString();
        }

        public string GenerarFormatoDocumento(string id, string nombre)
        {
            // Combinar el formato y el nombre
            string resultado = $"P{id}_{nombre}";

            return resultado;
        }

        public string ObtenerRutaArchivo(string carpeta, string id, Enum.Extension extension)
        {
            // Combina la carpeta base con la ruta relativa al archivo
            //string carpetaBase = AppDomain.CurrentDomain.BaseDirectory;
            //string rutaDestino = carpetaBase + @"\Files\Proceso\";

            string rutaDestino = Path.Combine(Application.StartupPath, "Files", carpeta);
            string ext = "";
            // Se selecciona extension
            switch (extension)
            {
                case Enum.Extension.PDF:
                    ext = "pdf";
                    break;
                case Enum.Extension.Word:
                    ext = "docx";
                    break;
                default:
                    break;
            }

            carpeta = $"{this.GenerarFormatoDocumento(id, carpeta)}.{ext}";

            return Path.Combine(rutaDestino, carpeta);
        }

        public string CopiarArchivo(string documento, Enum.Extension extension, string id = "", string nombreCarpetaArchivo = "")
        {
            // Combina la carpeta base con la ruta relativa al archivo
            string rutaDestino = Path.Combine(Application.StartupPath, "Files", nombreCarpetaArchivo);

            // Obtener el nombre del archivo seleccionado
            string nombreArchivo = Path.GetFileName(documento);

            string ext = "";
            // Se selecciona extension
            switch (extension)
            {
                case Enum.Extension.PDF:
                    ext = "pdf";
                    break;
                case Enum.Extension.Word:
                    ext = "docx";
                    break;
                default:
                    break;
            }

            // Generar un nuevo nombre para el archivo (puedes personalizar esta lógica)
            string nuevoNombre = $"{this.GenerarFormatoDocumento(id, nombreCarpetaArchivo)}.{ext}";
           
            // Construir la ruta completa de destino
            string rutaCompletaDestino = Path.Combine(rutaDestino, nuevoNombre);
           
            // Copiar el archivo a la nueva ubicación con el nuevo nombre
            // Si existe lo sobre escribe
            File.Copy(documento, rutaCompletaDestino, true);

            return nuevoNombre;
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

        public bool ValidarCamposGroupBox(GroupBox groupBox)
        {
            // Verificar que todos los TextBox no estén vacíos
            bool todosTextBoxNoVacios = groupBox.Controls.OfType<TextBox>().All(textBox => !string.IsNullOrEmpty(textBox.Text));

            // Verificar si existen combos
            bool existenCombos = groupBox.Controls.OfType<ComboBox>().Any();

            // Verificar que el ComboBox tenga un índice seleccionado (cualquier índice mayor o igual a 0)
            bool comboBoxSeleccionado = true;

            if (existenCombos)
            {
                comboBoxSeleccionado = groupBox.Controls.OfType<ComboBox>().All(comboBox => comboBox.SelectedIndex > 0);
            }

            // Devolver true si todos los TextBox no están vacíos y el ComboBox tiene un índice seleccionado
            return todosTextBoxNoVacios && comboBoxSeleccionado;
        }

        /// <summary>
        /// Configura y carga datos en un DataGridView, incluyendo columnas dinámicas,
        /// ocultar columnas, ajuste de tamaño de columnas, orden de columnas,
        /// y botones dinámicos con funciones asociadas al hacer clic.
        /// </summary>
        /// <typeparam name="T">Tipo de elementos en la lista de datos</typeparam>
        /// <param name="dataGridView">DataGridView a configurar y llenar</param>
        /// <param name="listaModel">Lista de datos a cargar en el DataGridView</param>
        /// <param name="columnasOcultar">Lista de nombres de columnas a ocultar</param>
        /// <param name="ultimaColumnaFill">Indica si la última columna debe ocupar todo el espacio disponible</param>
        /// <param name="tamanosColumnas">Diccionario con tamaños personalizados para columnas</param>
        /// <param name="ordenColumnas">Lista de nombres de columnas en el orden deseado</param>
        /// <param name="funcionesBotones">Diccionario que asocia funciones a nombres de columnas de botones</param
        public void CargarDatosEnGridView<T>(
            DataGridView dataGridView, 
            List<T> listaModel, 
            List<string> columnasOcultar = null, 
            bool ultimaColumnaFill = false,
            Dictionary<string, int> tamanosColumnas = null, 
            List<string> ordenColumnas = null,
            Dictionary<string, string> funcionesBotones = null)
        {
            dataGridView.MultiSelect = false;
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


            // Limpiar filas existentes
            dataGridView.Rows.Clear();

            if (!listaModel.Any()) return;
            
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

            // Agregar columnas de botones si se proporcionan
            if (funcionesBotones != null && funcionesBotones.Count > 0)
            {
                foreach (var kvp in funcionesBotones)
                {
                    string nombreBoton = kvp.Key;
                    string textoBoton = kvp.Value;

                    // Agregar columna de botón al DataGridView
                    DataGridViewButtonColumn botonColumn = new DataGridViewButtonColumn
                    {
                        Name = nombreBoton,
                        HeaderText = textoBoton,
                        Text = textoBoton,
                        UseColumnTextForButtonValue = true
                    };

                    dataGridView.Columns.Add(botonColumn);
                }
            }

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
                        if (kvp.Value == 1000) dataGridView.Columns[kvp.Key].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        else
                        {
                            dataGridView.Columns[kvp.Key].Width = kvp.Value;
                        }
                    }
                }
            }
        }
    }
}

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
        // Método que genera un identificador único global (GUID) y devuelve su representación como cadena.
        public string GenerarId()
        {
            // Crear un nuevo GUID que representa un identificador único global.
            Guid uniqueId = Guid.NewGuid();

            // Convertir el GUID a su representación como cadena y devolverlo.
            return uniqueId.ToString();
        }

        // Método que genera un formato de documento combinando un identificador y un nombre.
        // El formato resultante sigue el patrón "P{id}_{nombre}".
        public string GenerarFormatoDocumento(string id, string nombre)
        {
            // Combinar el formato y el nombre utilizando la interpolación de cadenas.
            string resultado = $"P{id}_{nombre}";

            // Devolver el formato del documento resultante.
            return resultado;
        }

        // Método que obtiene la ruta completa de un archivo en una carpeta específica.
        // La ruta se construye combinando la carpeta, un identificador, una extensión y la ruta de destino base.
        public string ObtenerRutaArchivo(string carpeta, string id, Enum.Extension extension)
        {
            // Obtener la ruta de destino base utilizando la ubicación de la aplicación.
            string rutaDestino = Path.Combine(Application.StartupPath, "Files", carpeta);

            // Inicializar una cadena para la extensión del archivo.
            string ext = "";

            // Seleccionar la extensión correspondiente según el tipo de extensión proporcionado.
            switch (extension)
            {
                case Enum.Extension.PDF:
                    ext = "pdf";
                    break;
                case Enum.Extension.Word:
                    ext = "docx";
                    break;
                default:
                    // Manejar cualquier otro caso de extensión.
                    break;
            }

            // Combinar el formato del documento (incluido el identificador y la carpeta) con la extensión.
            carpeta = $"{this.GenerarFormatoDocumento(id, carpeta)}.{ext}";

            // Combinar la carpeta y el nombre del archivo con la ruta de destino para obtener la ruta completa del archivo.
            return Path.Combine(rutaDestino, carpeta);
        }

        /// <summary>
        /// Método para copiar archivos de una ruta original a otra con un destino definido
        /// </summary>
        /// <param name="documento">Ruta original del archivo</param>
        /// <param name="extension">Esta a base de Enum, tiene 2 opciones actualmente</param>
        /// <param name="id">Id o guid que va tener de nombre del documento</param>
        /// <param name="nombreCarpetaArchivo">Indica el nombre de la carpetala cual sera el destino</param>
        /// <returns></returns>
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

        /// <summary>
        /// Configura el estado y el texto de los botones 'Nuevo', 'Guardar' y 'Eliminar' en una interfaz de usuario.
        /// El comportamiento y el texto de los botones se ajustan según el valor de una enumeración específica que representa la acción actual o deseada.
        /// </summary>
        /// <param name="btnNuevo">Botón 'Nuevo' en la interfaz de usuario.</param>
        /// <param name="btnGuardar">Botón 'Guardar' en la interfaz de usuario.</param>
        /// <param name="btnEliminar">Botón 'Eliminar' en la interfaz de usuario.</param>
        /// <param name="_enum">Enumeración de tipo Enum.AccionBoton que indica el estado o acción deseada.</param>
        /// <returns>La enumeración de tipo Enum.AccionBoton que fue pasada como parámetro.</returns>
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

        /// <summary>
        /// Muestra un mensaje en una ventana emergente con un estilo y botones que varían según el tipo de mensaje.
        /// </summary>
        /// <param name="texto">El texto a mostrar en el mensaje.</param>
        /// <param name="_enum">Enumeración de tipo Enum.TipoMensaje que indica el tipo de mensaje a mostrar.</param>
        /// <returns>
        /// Retorna 'true' en la mayoría de los casos.
        /// Para el tipo de mensaje 'YesNoCancel', retorna 'true' si la respuesta es 'Yes' y 'false' en otros casos.
        /// </returns>
        public bool MostrarMensaje(string texto, Enum.TipoMensaje _enum)
        {
            switch (_enum)
            {
                case Enum.TipoMensaje.Informativo:
                    // Muestra un mensaje informativo con un botón 'OK' y un icono de información.
                    MessageBox.Show(texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case Enum.TipoMensaje.Advertencia:
                    // Muestra un mensaje de advertencia con un botón 'OK' y un icono de advertencia.
                    MessageBox.Show(texto, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case Enum.TipoMensaje.Error:
                    // Muestra un mensaje de error con un botón 'OK' y un icono de error.
                    MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Enum.TipoMensaje.YesNoCancel:
                    // Muestra un mensaje con opciones 'Yes', 'No' y 'Cancel' y un icono de pregunta.
                    // Retorna 'true' si se selecciona 'Yes' y 'false' en caso contrario.
                    DialogResult dialogResult = MessageBox.Show(texto, "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    return dialogResult == DialogResult.Yes;

                default:
                    // No hace nada si el tipo de mensaje no está definido.
                    break;
            }

            return true;
        }


        /// <summary>
        /// Valida los controles dentro de un GroupBox, asegurándose de que todos los TextBox no estén vacíos
        /// y que, en caso de existir ComboBoxes, todos tengan un ítem seleccionado.
        /// </summary>
        /// <param name="groupBox">El GroupBox cuyos controles se van a validar.</param>
        /// <returns>
        /// Retorna 'true' si todos los TextBox no están vacíos y, en caso de existir ComboBoxes, todos tienen un ítem seleccionado.
        /// Retorna 'false' en caso contrario.
        /// </returns>
        public bool ValidarCamposGroupBox(GroupBox groupBox)
        {
            // Verificar que todos los TextBox no estén vacíos.
            // Utiliza LINQ para iterar sobre todos los controles de tipo TextBox dentro del GroupBox,
            // y verifica que todos tengan texto (no estén vacíos).
            bool todosTextBoxNoVacios = groupBox.Controls.OfType<TextBox>().All(textBox => !string.IsNullOrEmpty(textBox.Text));

            // Verificar si existen ComboBoxes dentro del GroupBox.
            // Utiliza LINQ para comprobar si hay al menos un ComboBox en los controles del GroupBox.
            bool existenCombos = groupBox.Controls.OfType<ComboBox>().Any();

            // Inicializa la variable para verificar si el ComboBox tiene un ítem seleccionado.
            // Por defecto, es 'true' para manejar el caso en que no existan ComboBoxes.
            bool comboBoxSeleccionado = true;

            // Si existen ComboBoxes, verificar que todos tengan un índice seleccionado.
            // El índice seleccionado debe ser mayor o igual a 0 para ser considerado válido.
            if (existenCombos)
            {
                comboBoxSeleccionado = groupBox.Controls.OfType<ComboBox>().All(comboBox => comboBox.SelectedIndex >= 0);
            }

            // Devuelve 'true' si todos los TextBox no están vacíos y, en caso de existir ComboBoxes, todos tienen un índice seleccionado.
            // De lo contrario, devuelve 'false'.
            return todosTextBoxNoVacios && comboBoxSeleccionado;
        }


        /// <summary>
        /// Carga una lista de datos en un DataGridView, configurando aspectos como columnas a ocultar, 
        /// tamaños de columnas, orden de columnas, y botones personalizados.
        /// </summary>
        /// <typeparam name="T">El tipo de datos de la lista que se va a cargar en el DataGridView.</typeparam>
        /// <param name="dataGridView">El DataGridView que se va a configurar y llenar.</param>
        /// <param name="listaModel">La lista de datos que se va a cargar en el DataGridView.</param>
        /// <param name="columnasOcultar">Lista opcional de nombres de columnas a ocultar.</param>
        /// <param name="ultimaColumnaFill">Indica si la última columna debe ajustarse para ocupar el espacio restante.</param>
        /// <param name="tamanosColumnas">Diccionario opcional con los tamaños personalizados para las columnas.</param>
        /// <param name="ordenColumnas">Lista opcional que define el orden de las columnas.</param>
        /// <param name="funcionesBotones">Diccionario opcional que define columnas adicionales de botones.</param>
        public void CargarDatosEnGridView<T>(
            DataGridView dataGridView, 
            List<T> listaModel, 
            List<string> columnasOcultar = null, 
            bool ultimaColumnaFill = false,
            Dictionary<string, int> tamanosColumnas = null, 
            List<string> ordenColumnas = null,
            Dictionary<string, string> funcionesBotones = null)
        {
            // Configuración inicial del DataGridView, como deshabilitar la selección múltiple,
            // deshabilitar la adición y eliminación de filas por el usuario, y configurar el estilo visual.
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

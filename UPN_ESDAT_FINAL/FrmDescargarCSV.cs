using System;
using System.IO;
using System.Windows.Forms;
using UPN_ESDAT_FINAL.Common;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmDescargarCSV : Form
    {
        Utils _utils = new Utils();

        public FrmDescargarCSV()
        {
            InitializeComponent();
        }

        private void FrmDescargarCSV_Load(object sender, EventArgs e)
        {
            // Seleccionamos por defecto el valor con índice 1
            cbArchivos.SelectedIndex = 1;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            // Ruta del archivo CSV en la raíz de la aplicación
            string rutaArchivoCSV = Path.Combine(Application.StartupPath, "Files", "CSV", cbArchivos.Text + ".csv");
            
            // Verificar si el archivo existe antes de continuar
            if (File.Exists(rutaArchivoCSV))
            {
                // Configurar el cuadro de diálogo para guardar archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";

                // Creamos un nombre único usando guid
                Guid uniqueId = Guid.NewGuid();

                saveFileDialog.FileName = $"{cbArchivos.Text}-{uniqueId}.csv";

                // Mostrar el cuadro de diálogo y verificar si el usuario hizo clic en "Guardar"
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Copiar el contenido del archivo CSV al archivo seleccionado por el usuario
                        File.Copy(rutaArchivoCSV, saveFileDialog.FileName, true);
                        _utils.MostrarMensaje("Archivo descargado con éxito.", Common.Enum.TipoMensaje.Informativo);
                    }
                    catch (Exception ex)
                    {
                        _utils.MostrarMensaje($"Error al descargar el archivo: {ex.Message}", Common.Enum.TipoMensaje.Error);
                    }
                }
            }
            else
            {
                _utils.MostrarMensaje($"El archivo no existe!", Common.Enum.TipoMensaje.Error);
            }
        }
    }
}

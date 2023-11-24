using System;
using System.IO;
using System.Windows.Forms;

namespace UPN_ESDAT_FINAL
{
    public partial class FrmVerDocumentoPDF : Form
    {
        string _fileName = string.Empty;

        public FrmVerDocumentoPDF(string fileName)
        {
            InitializeComponent();
            this._fileName = fileName;
        }

        private void FrmVerDocumentoPDF_Load(object sender, EventArgs e)
        {
            if (File.Exists(this._fileName))
            {
                axAcroPDF1.LoadFile(this._fileName);
            }
        }
    }
}

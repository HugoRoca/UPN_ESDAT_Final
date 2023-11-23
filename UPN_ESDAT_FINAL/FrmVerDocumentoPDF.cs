using Patagames.Pdf.Net;
using Patagames.Pdf.Net.Controls.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                pdfViewer1.LoadDocument(this._fileName);
            }
        }
    }
}

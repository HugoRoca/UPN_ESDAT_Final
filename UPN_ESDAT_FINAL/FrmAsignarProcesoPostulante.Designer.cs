namespace UPN_ESDAT_FINAL
{
    partial class FrmAsignarProcesoPostulante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsignarProcesoPostulante));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCV = new System.Windows.Forms.TextBox();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPostulante = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelNoTieneProceso = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panelNoTieneProceso.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Postulante:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCV);
            this.groupBox1.Controls.Add(this.btnVerPdf);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPostulante);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(459, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // txtCV
            // 
            this.txtCV.Location = new System.Drawing.Point(264, 73);
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(100, 21);
            this.txtCV.TabIndex = 22;
            this.txtCV.Visible = false;
            // 
            // btnVerPdf
            // 
            this.btnVerPdf.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnVerPdf.Location = new System.Drawing.Point(99, 67);
            this.btnVerPdf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerPdf.Name = "btnVerPdf";
            this.btnVerPdf.Size = new System.Drawing.Size(158, 27);
            this.btnVerPdf.TabIndex = 21;
            this.btnVerPdf.Text = "Ver archivo PDF";
            this.btnVerPdf.UseVisualStyleBackColor = false;
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "CV:";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(96, 48);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(47, 15);
            this.lblDocumento.TabIndex = 3;
            this.lblDocumento.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI/CE:";
            // 
            // lblPostulante
            // 
            this.lblPostulante.AutoSize = true;
            this.lblPostulante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostulante.Location = new System.Drawing.Point(96, 23);
            this.lblPostulante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostulante.Name = "lblPostulante";
            this.lblPostulante.Size = new System.Drawing.Size(47, 15);
            this.lblPostulante.TabIndex = 1;
            this.lblPostulante.Text = "label2";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(484, 31);
            this.label7.TabIndex = 2;
            this.label7.Text = "ASIGNAR/ACTUALIZAR PROCESO";
            // 
            // panelNoTieneProceso
            // 
            this.panelNoTieneProceso.Controls.Add(this.groupBox2);
            this.panelNoTieneProceso.Location = new System.Drawing.Point(14, 149);
            this.panelNoTieneProceso.Name = "panelNoTieneProceso";
            this.panelNoTieneProceso.Size = new System.Drawing.Size(459, 259);
            this.panelNoTieneProceso.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvProcesos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 259);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procesos";
            // 
            // dgvProcesos
            // 
            this.dgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcesos.Location = new System.Drawing.Point(3, 17);
            this.dgvProcesos.Name = "dgvProcesos";
            this.dgvProcesos.Size = new System.Drawing.Size(453, 239);
            this.dgvProcesos.TabIndex = 0;
            this.dgvProcesos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcesos_CellContentClick);
            // 
            // FrmAsignarProcesoPostulante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 415);
            this.Controls.Add(this.panelNoTieneProceso);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmAsignarProcesoPostulante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postulante";
            this.Load += new System.EventHandler(this.FrmAsignarProcesoPostulante_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelNoTieneProceso.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPostulante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerPdf;
        private System.Windows.Forms.TextBox txtCV;
        private System.Windows.Forms.Panel panelNoTieneProceso;
        private System.Windows.Forms.DataGridView dgvProcesos;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
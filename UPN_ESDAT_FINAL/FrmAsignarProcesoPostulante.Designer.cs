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
            this.panelSiTieneProceso = new System.Windows.Forms.Panel();
            this.panelProcesoContrado = new System.Windows.Forms.Panel();
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEstados = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.dgvEstadosPostulante = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvContratado = new System.Windows.Forms.DataGridView();
            this.btnVerProceso = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelNoTieneProceso.SuspendLayout();
            this.panelSiTieneProceso.SuspendLayout();
            this.panelProcesoContrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadosPostulante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratado)).BeginInit();
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
            this.label7.Size = new System.Drawing.Size(950, 31);
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
            // panelSiTieneProceso
            // 
            this.panelSiTieneProceso.Controls.Add(this.groupBox3);
            this.panelSiTieneProceso.Location = new System.Drawing.Point(480, 149);
            this.panelSiTieneProceso.Name = "panelSiTieneProceso";
            this.panelSiTieneProceso.Size = new System.Drawing.Size(459, 259);
            this.panelSiTieneProceso.TabIndex = 4;
            // 
            // panelProcesoContrado
            // 
            this.panelProcesoContrado.Controls.Add(this.btnVerProceso);
            this.panelProcesoContrado.Controls.Add(this.dgvContratado);
            this.panelProcesoContrado.Controls.Add(this.label6);
            this.panelProcesoContrado.Location = new System.Drawing.Point(14, 430);
            this.panelProcesoContrado.Name = "panelProcesoContrado";
            this.panelProcesoContrado.Size = new System.Drawing.Size(459, 259);
            this.panelProcesoContrado.TabIndex = 4;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.dgvEstadosPostulante);
            this.groupBox3.Controls.Add(this.txtObservaciones);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbEstados);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 259);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cambiar estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estado:";
            // 
            // cbEstados
            // 
            this.cbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstados.FormattingEnabled = true;
            this.cbEstados.Location = new System.Drawing.Point(115, 65);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(121, 23);
            this.cbEstados.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(115, 20);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(338, 39);
            this.txtObservaciones.TabIndex = 0;
            // 
            // dgvEstadosPostulante
            // 
            this.dgvEstadosPostulante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadosPostulante.Location = new System.Drawing.Point(6, 95);
            this.dgvEstadosPostulante.Name = "dgvEstadosPostulante";
            this.dgvEstadosPostulante.Size = new System.Drawing.Size(447, 158);
            this.dgvEstadosPostulante.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(242, 65);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 24);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Agregar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "CONTRATADO";
            // 
            // dgvContratado
            // 
            this.dgvContratado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratado.Location = new System.Drawing.Point(6, 39);
            this.dgvContratado.Name = "dgvContratado";
            this.dgvContratado.Size = new System.Drawing.Size(447, 217);
            this.dgvContratado.TabIndex = 5;
            // 
            // btnVerProceso
            // 
            this.btnVerProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerProceso.Location = new System.Drawing.Point(336, 9);
            this.btnVerProceso.Name = "btnVerProceso";
            this.btnVerProceso.Size = new System.Drawing.Size(117, 24);
            this.btnVerProceso.TabIndex = 5;
            this.btnVerProceso.Text = "Ver Proceso";
            this.btnVerProceso.UseVisualStyleBackColor = true;
            this.btnVerProceso.Click += new System.EventHandler(this.btnVerProceso_Click);
            // 
            // FrmAsignarProcesoPostulante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 701);
            this.Controls.Add(this.panelSiTieneProceso);
            this.Controls.Add(this.panelProcesoContrado);
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
            this.panelSiTieneProceso.ResumeLayout(false);
            this.panelProcesoContrado.ResumeLayout(false);
            this.panelProcesoContrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadosPostulante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratado)).EndInit();
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
        private System.Windows.Forms.Panel panelSiTieneProceso;
        private System.Windows.Forms.Panel panelProcesoContrado;
        private System.Windows.Forms.DataGridView dgvProcesos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvEstadosPostulante;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEstados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVerProceso;
        private System.Windows.Forms.DataGridView dgvContratado;
        private System.Windows.Forms.Label label6;
    }
}
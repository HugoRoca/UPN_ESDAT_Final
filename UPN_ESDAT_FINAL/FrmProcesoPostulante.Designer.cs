namespace UPN_ESDAT_FINAL
{
    partial class FrmProcesoPostulante
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
            this.label7 = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtDNICE = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.txtCV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdPostulante = new System.Windows.Forms.TextBox();
            this.gbDatosProceso = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.btnVerDocumento = new System.Windows.Forms.Button();
            this.txtIdProceso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionLarga = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescripcionCorta = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.dgvEstados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.gbDatosProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(949, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "POSTULANTE - PROCESO";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.txtDNICE);
            this.gbDatos.Controls.Add(this.label9);
            this.gbDatos.Controls.Add(this.btnVerPdf);
            this.gbDatos.Controls.Add(this.txtCV);
            this.gbDatos.Controls.Add(this.label8);
            this.gbDatos.Controls.Add(this.dtpFechaNac);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.txtEmail);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.txtCelular);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtApellidos);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.txtNombres);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtIdPostulante);
            this.gbDatos.Location = new System.Drawing.Point(13, 32);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatos.Size = new System.Drawing.Size(412, 225);
            this.gbDatos.TabIndex = 3;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos Postulante";
            // 
            // txtDNICE
            // 
            this.txtDNICE.Location = new System.Drawing.Point(82, 103);
            this.txtDNICE.MaxLength = 20;
            this.txtDNICE.Name = "txtDNICE";
            this.txtDNICE.ReadOnly = true;
            this.txtDNICE.Size = new System.Drawing.Size(142, 21);
            this.txtDNICE.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "DNI/CE:";
            // 
            // btnVerPdf
            // 
            this.btnVerPdf.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnVerPdf.Location = new System.Drawing.Point(82, 181);
            this.btnVerPdf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerPdf.Name = "btnVerPdf";
            this.btnVerPdf.Size = new System.Drawing.Size(221, 27);
            this.btnVerPdf.TabIndex = 9;
            this.btnVerPdf.Text = "Ver archivo PDF";
            this.btnVerPdf.UseVisualStyleBackColor = false;
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);
            // 
            // txtCV
            // 
            this.txtCV.Location = new System.Drawing.Point(675, 231);
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(100, 21);
            this.txtCV.TabIndex = 13;
            this.txtCV.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "CV:";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Enabled = false;
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(150, 155);
            this.dtpFechaNac.MaxDate = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNac.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(153, 21);
            this.dtpFechaNac.TabIndex = 7;
            this.dtpFechaNac.Value = new System.DateTime(2005, 12, 31, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha Nacimiento:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(82, 130);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(323, 21);
            this.txtEmail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(82, 76);
            this.txtCelular.MaxLength = 20;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.ReadOnly = true;
            this.txtCelular.Size = new System.Drawing.Size(142, 21);
            this.txtCelular.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Celular";
            // 
            // txtApellidos
            // 
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidos.Location = new System.Drawing.Point(82, 49);
            this.txtApellidos.MaxLength = 100;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.ReadOnly = true;
            this.txtApellidos.Size = new System.Drawing.Size(323, 21);
            this.txtApellidos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellidos:";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(82, 22);
            this.txtNombres.MaxLength = 100;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(323, 21);
            this.txtNombres.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres:";
            // 
            // txtIdPostulante
            // 
            this.txtIdPostulante.Location = new System.Drawing.Point(587, 183);
            this.txtIdPostulante.Name = "txtIdPostulante";
            this.txtIdPostulante.ReadOnly = true;
            this.txtIdPostulante.Size = new System.Drawing.Size(230, 21);
            this.txtIdPostulante.TabIndex = 1;
            // 
            // gbDatosProceso
            // 
            this.gbDatosProceso.Controls.Add(this.txtEstado);
            this.gbDatosProceso.Controls.Add(this.txtArea);
            this.gbDatosProceso.Controls.Add(this.btnVerDocumento);
            this.gbDatosProceso.Controls.Add(this.txtIdProceso);
            this.gbDatosProceso.Controls.Add(this.label1);
            this.gbDatosProceso.Controls.Add(this.label10);
            this.gbDatosProceso.Controls.Add(this.label11);
            this.gbDatosProceso.Controls.Add(this.txtDescripcionLarga);
            this.gbDatosProceso.Controls.Add(this.label12);
            this.gbDatosProceso.Controls.Add(this.txtDescripcionCorta);
            this.gbDatosProceso.Controls.Add(this.label13);
            this.gbDatosProceso.Controls.Add(this.txtDocumento);
            this.gbDatosProceso.Location = new System.Drawing.Point(433, 32);
            this.gbDatosProceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatosProceso.Name = "gbDatosProceso";
            this.gbDatosProceso.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatosProceso.Size = new System.Drawing.Size(501, 225);
            this.gbDatosProceso.TabIndex = 4;
            this.gbDatosProceso.TabStop = false;
            this.gbDatosProceso.Text = "Datos Proceso";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(139, 190);
            this.txtEstado.MaxLength = 20;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(217, 21);
            this.txtEstado.TabIndex = 21;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(139, 130);
            this.txtArea.MaxLength = 20;
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(217, 21);
            this.txtArea.TabIndex = 20;
            // 
            // btnVerDocumento
            // 
            this.btnVerDocumento.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnVerDocumento.Location = new System.Drawing.Point(139, 157);
            this.btnVerDocumento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerDocumento.Name = "btnVerDocumento";
            this.btnVerDocumento.Size = new System.Drawing.Size(217, 27);
            this.btnVerDocumento.TabIndex = 18;
            this.btnVerDocumento.Text = "Ver archivo PDF";
            this.btnVerDocumento.UseVisualStyleBackColor = false;
            this.btnVerDocumento.Click += new System.EventHandler(this.btnVerDocumento_Click);
            // 
            // txtIdProceso
            // 
            this.txtIdProceso.Location = new System.Drawing.Point(558, 141);
            this.txtIdProceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdProceso.Name = "txtIdProceso";
            this.txtIdProceso.ReadOnly = true;
            this.txtIdProceso.Size = new System.Drawing.Size(296, 21);
            this.txtIdProceso.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Estado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Documento:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(95, 133);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Area:";
            // 
            // txtDescripcionLarga
            // 
            this.txtDescripcionLarga.Location = new System.Drawing.Point(139, 52);
            this.txtDescripcionLarga.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcionLarga.Multiline = true;
            this.txtDescripcionLarga.Name = "txtDescripcionLarga";
            this.txtDescripcionLarga.ReadOnly = true;
            this.txtDescripcionLarga.Size = new System.Drawing.Size(351, 72);
            this.txtDescripcionLarga.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 55);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "Descripción Larga:";
            // 
            // txtDescripcionCorta
            // 
            this.txtDescripcionCorta.Location = new System.Drawing.Point(139, 22);
            this.txtDescripcionCorta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcionCorta.Name = "txtDescripcionCorta";
            this.txtDescripcionCorta.ReadOnly = true;
            this.txtDescripcionCorta.Size = new System.Drawing.Size(351, 21);
            this.txtDescripcionCorta.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Descripción Corta:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(558, 181);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(217, 21);
            this.txtDocumento.TabIndex = 19;
            this.txtDocumento.Visible = false;
            // 
            // dgvEstados
            // 
            this.dgvEstados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEstados.Location = new System.Drawing.Point(3, 80);
            this.dgvEstados.Name = "dgvEstados";
            this.dgvEstados.Size = new System.Drawing.Size(915, 231);
            this.dgvEstados.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.cbEstado);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dgvEstados);
            this.groupBox1.Location = new System.Drawing.Point(13, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(921, 314);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estados en proceso actual:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(110, 28);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(302, 46);
            this.txtObservacion.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(423, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "Estado:";
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(479, 31);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(320, 23);
            this.cbEstado.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(805, 28);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 46);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FrmProcesoPostulante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDatosProceso);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmProcesoPostulante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProcesoPostulante";
            this.Load += new System.EventHandler(this.FrmProcesoPostulante_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbDatosProceso.ResumeLayout(false);
            this.gbDatosProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtDNICE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnVerPdf;
        private System.Windows.Forms.TextBox txtCV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdPostulante;
        private System.Windows.Forms.GroupBox gbDatosProceso;
        private System.Windows.Forms.Button btnVerDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionLarga;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescripcionCorta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIdProceso;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.DataGridView dgvEstados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAgregar;
    }
}
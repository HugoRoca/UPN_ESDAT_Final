﻿namespace UPN_ESDAT_FINAL
{
    partial class FrmCrearProcesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrearProcesos));
            this.gbDatosProceso = new System.Windows.Forms.GroupBox();
            this.lblProcesoFinalizado = new System.Windows.Forms.Label();
            this.btnAsignarProceso = new System.Windows.Forms.Button();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnSubir = new System.Windows.Forms.Button();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionLarga = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcionCorta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProceso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.dgvProceso = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.gbDatosProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProceso)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosProceso
            // 
            this.gbDatosProceso.Controls.Add(this.lblProcesoFinalizado);
            this.gbDatosProceso.Controls.Add(this.btnAsignarProceso);
            this.gbDatosProceso.Controls.Add(this.btnVerPdf);
            this.gbDatosProceso.Controls.Add(this.btnEliminar);
            this.gbDatosProceso.Controls.Add(this.btnGuardar);
            this.gbDatosProceso.Controls.Add(this.btnNuevo);
            this.gbDatosProceso.Controls.Add(this.cbEstado);
            this.gbDatosProceso.Controls.Add(this.btnSubir);
            this.gbDatosProceso.Controls.Add(this.cbArea);
            this.gbDatosProceso.Controls.Add(this.label6);
            this.gbDatosProceso.Controls.Add(this.label5);
            this.gbDatosProceso.Controls.Add(this.label4);
            this.gbDatosProceso.Controls.Add(this.txtDescripcionLarga);
            this.gbDatosProceso.Controls.Add(this.label3);
            this.gbDatosProceso.Controls.Add(this.txtDescripcionCorta);
            this.gbDatosProceso.Controls.Add(this.label2);
            this.gbDatosProceso.Controls.Add(this.txtIdProceso);
            this.gbDatosProceso.Controls.Add(this.label1);
            this.gbDatosProceso.Controls.Add(this.txtDocumento);
            this.gbDatosProceso.Location = new System.Drawing.Point(13, 30);
            this.gbDatosProceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatosProceso.Name = "gbDatosProceso";
            this.gbDatosProceso.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatosProceso.Size = new System.Drawing.Size(804, 259);
            this.gbDatosProceso.TabIndex = 1;
            this.gbDatosProceso.TabStop = false;
            this.gbDatosProceso.Text = "Datos";
            // 
            // lblProcesoFinalizado
            // 
            this.lblProcesoFinalizado.AutoSize = true;
            this.lblProcesoFinalizado.BackColor = System.Drawing.Color.LimeGreen;
            this.lblProcesoFinalizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesoFinalizado.Location = new System.Drawing.Point(532, 20);
            this.lblProcesoFinalizado.Name = "lblProcesoFinalizado";
            this.lblProcesoFinalizado.Size = new System.Drawing.Size(263, 31);
            this.lblProcesoFinalizado.TabIndex = 21;
            this.lblProcesoFinalizado.Text = "Proceso Finalizado";
            this.lblProcesoFinalizado.Visible = false;
            // 
            // btnAsignarProceso
            // 
            this.btnAsignarProceso.BackColor = System.Drawing.Color.Salmon;
            this.btnAsignarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarProceso.Location = new System.Drawing.Point(463, 168);
            this.btnAsignarProceso.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnAsignarProceso.Name = "btnAsignarProceso";
            this.btnAsignarProceso.Size = new System.Drawing.Size(333, 46);
            this.btnAsignarProceso.TabIndex = 20;
            this.btnAsignarProceso.Text = "Asignar postulante a este proceso";
            this.btnAsignarProceso.UseVisualStyleBackColor = false;
            this.btnAsignarProceso.Visible = false;
            this.btnAsignarProceso.Click += new System.EventHandler(this.btnAsignarProceso_Click);
            // 
            // btnVerPdf
            // 
            this.btnVerPdf.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnVerPdf.Location = new System.Drawing.Point(221, 197);
            this.btnVerPdf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVerPdf.Name = "btnVerPdf";
            this.btnVerPdf.Size = new System.Drawing.Size(217, 27);
            this.btnVerPdf.TabIndex = 18;
            this.btnVerPdf.Text = "Ver archivo PDF";
            this.btnVerPdf.UseVisualStyleBackColor = false;
            this.btnVerPdf.Visible = false;
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(691, 205);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 46);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(577, 205);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(105, 46);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(463, 205);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(105, 46);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Enabled = false;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(142, 228);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(296, 23);
            this.cbEstado.TabIndex = 14;
            // 
            // btnSubir
            // 
            this.btnSubir.Enabled = false;
            this.btnSubir.Location = new System.Drawing.Point(142, 197);
            this.btnSubir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(72, 27);
            this.btnSubir.TabIndex = 13;
            this.btnSubir.Text = "Subir PDF";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // cbArea
            // 
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(142, 168);
            this.cbArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(296, 23);
            this.cbArea.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Estado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Area:";
            // 
            // txtDescripcionLarga
            // 
            this.txtDescripcionLarga.Location = new System.Drawing.Point(142, 90);
            this.txtDescripcionLarga.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcionLarga.Multiline = true;
            this.txtDescripcionLarga.Name = "txtDescripcionLarga";
            this.txtDescripcionLarga.Size = new System.Drawing.Size(654, 72);
            this.txtDescripcionLarga.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción Larga:";
            // 
            // txtDescripcionCorta
            // 
            this.txtDescripcionCorta.Location = new System.Drawing.Point(142, 60);
            this.txtDescripcionCorta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescripcionCorta.Name = "txtDescripcionCorta";
            this.txtDescripcionCorta.Size = new System.Drawing.Size(654, 21);
            this.txtDescripcionCorta.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción Corta:";
            // 
            // txtIdProceso
            // 
            this.txtIdProceso.Location = new System.Drawing.Point(142, 30);
            this.txtIdProceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdProceso.Name = "txtIdProceso";
            this.txtIdProceso.ReadOnly = true;
            this.txtIdProceso.Size = new System.Drawing.Size(296, 21);
            this.txtIdProceso.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(221, 200);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(217, 21);
            this.txtDocumento.TabIndex = 19;
            this.txtDocumento.Visible = false;
            // 
            // dgvProceso
            // 
            this.dgvProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProceso.Location = new System.Drawing.Point(0, 295);
            this.dgvProceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProceso.Name = "dgvProceso";
            this.dgvProceso.Size = new System.Drawing.Size(830, 355);
            this.dgvProceso.TabIndex = 1;
            this.dgvProceso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProceso_CellClick);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(830, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "PROCESO";
            // 
            // FrmCrearProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 650);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvProceso);
            this.Controls.Add(this.gbDatosProceso);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmCrearProcesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso";
            this.Load += new System.EventHandler(this.FrmCrearProcesos_Load);
            this.gbDatosProceso.ResumeLayout(false);
            this.gbDatosProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProceso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosProceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionLarga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcionCorta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdProceso;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.DataGridView dgvProceso;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVerPdf;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnAsignarProceso;
        private System.Windows.Forms.Label lblProcesoFinalizado;
    }
}
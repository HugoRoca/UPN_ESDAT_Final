namespace UPN_ESDAT_FINAL
{
    partial class FrmListaProcesoPostulante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaProcesoPostulante));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProceso = new System.Windows.Forms.TextBox();
            this.dgvPostulantes = new System.Windows.Forms.DataGridView();
            this.btnFinalizarProceso = new System.Windows.Forms.Button();
            this.btnPausarProceso = new System.Windows.Forms.Button();
            this.btnInhabilitarProceso = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(579, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "LISTA DE POSTULANTE POR PROCESO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Proceso:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInhabilitarProceso);
            this.groupBox1.Controls.Add(this.btnPausarProceso);
            this.groupBox1.Controls.Add(this.btnFinalizarProceso);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProceso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos proceso:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(78, 76);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(63, 17);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estado:";
            // 
            // txtProceso
            // 
            this.txtProceso.Location = new System.Drawing.Point(78, 26);
            this.txtProceso.Multiline = true;
            this.txtProceso.Name = "txtProceso";
            this.txtProceso.ReadOnly = true;
            this.txtProceso.Size = new System.Drawing.Size(462, 42);
            this.txtProceso.TabIndex = 8;
            // 
            // dgvPostulantes
            // 
            this.dgvPostulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostulantes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPostulantes.Location = new System.Drawing.Point(0, 170);
            this.dgvPostulantes.Name = "dgvPostulantes";
            this.dgvPostulantes.Size = new System.Drawing.Size(579, 229);
            this.dgvPostulantes.TabIndex = 9;
            // 
            // btnFinalizarProceso
            // 
            this.btnFinalizarProceso.BackColor = System.Drawing.Color.LightGreen;
            this.btnFinalizarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarProceso.Location = new System.Drawing.Point(446, 76);
            this.btnFinalizarProceso.Name = "btnFinalizarProceso";
            this.btnFinalizarProceso.Size = new System.Drawing.Size(94, 46);
            this.btnFinalizarProceso.TabIndex = 11;
            this.btnFinalizarProceso.Text = "Finalizar proceso";
            this.btnFinalizarProceso.UseVisualStyleBackColor = false;
            this.btnFinalizarProceso.Visible = false;
            this.btnFinalizarProceso.Click += new System.EventHandler(this.btnFinalizarProceso_Click);
            // 
            // btnPausarProceso
            // 
            this.btnPausarProceso.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPausarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausarProceso.Location = new System.Drawing.Point(346, 76);
            this.btnPausarProceso.Name = "btnPausarProceso";
            this.btnPausarProceso.Size = new System.Drawing.Size(94, 46);
            this.btnPausarProceso.TabIndex = 12;
            this.btnPausarProceso.Text = "Pausar Proceso";
            this.btnPausarProceso.UseVisualStyleBackColor = false;
            this.btnPausarProceso.Visible = false;
            this.btnPausarProceso.Click += new System.EventHandler(this.btnPausarProceso_Click);
            // 
            // btnInhabilitarProceso
            // 
            this.btnInhabilitarProceso.BackColor = System.Drawing.Color.IndianRed;
            this.btnInhabilitarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInhabilitarProceso.Location = new System.Drawing.Point(246, 76);
            this.btnInhabilitarProceso.Name = "btnInhabilitarProceso";
            this.btnInhabilitarProceso.Size = new System.Drawing.Size(94, 46);
            this.btnInhabilitarProceso.TabIndex = 13;
            this.btnInhabilitarProceso.Text = "Inhabilitar Proceso";
            this.btnInhabilitarProceso.UseVisualStyleBackColor = false;
            this.btnInhabilitarProceso.Visible = false;
            this.btnInhabilitarProceso.Click += new System.EventHandler(this.btnInhabilitarProceso_Click);
            // 
            // FrmListaProcesoPostulante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 399);
            this.Controls.Add(this.dgvPostulantes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmListaProcesoPostulante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Postulante";
            this.Load += new System.EventHandler(this.FrmListaProcesoPostulante_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProceso;
        private System.Windows.Forms.DataGridView dgvPostulantes;
        private System.Windows.Forms.Button btnFinalizarProceso;
        private System.Windows.Forms.Button btnInhabilitarProceso;
        private System.Windows.Forms.Button btnPausarProceso;
    }
}
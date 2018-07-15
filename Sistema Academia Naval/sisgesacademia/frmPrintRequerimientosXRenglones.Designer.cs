namespace SisGesAcademia
{
    partial class frmPrintRequerimientosXRenglones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintRequerimientosXRenglones));
            this.chkAdquiridos = new System.Windows.Forms.CheckBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.chkTodos = new System.Windows.Forms.RadioButton();
            this.cmbDependencia = new System.Windows.Forms.ComboBox();
            this.chkDependencia = new System.Windows.Forms.RadioButton();
            this.chkFecha = new System.Windows.Forms.RadioButton();
            this.fechahasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.fechadesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(400, 22);
            this.lblTituloForm.Text = "Pantalla Generar Requerimientos por Renglones";
            // 
            // chkAdquiridos
            // 
            this.chkAdquiridos.AutoSize = true;
            this.chkAdquiridos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdquiridos.Location = new System.Drawing.Point(325, 70);
            this.chkAdquiridos.Name = "chkAdquiridos";
            this.chkAdquiridos.Size = new System.Drawing.Size(85, 17);
            this.chkAdquiridos.TabIndex = 98;
            this.chkAdquiridos.Text = "Adquiridos";
            this.chkAdquiridos.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(465, 136);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 97;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(465, 67);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 96;
            this.btnImprimir.Text = "Listar";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Location = new System.Drawing.Point(13, 67);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(252, 20);
            this.chkTodos.TabIndex = 95;
            this.chkTodos.TabStop = true;
            this.chkTodos.Text = "TODOS LOS REQUERIMIENTOS";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // cmbDependencia
            // 
            this.cmbDependencia.FormattingEnabled = true;
            this.cmbDependencia.Location = new System.Drawing.Point(15, 255);
            this.cmbDependencia.Name = "cmbDependencia";
            this.cmbDependencia.Size = new System.Drawing.Size(459, 21);
            this.cmbDependencia.TabIndex = 94;
            // 
            // chkDependencia
            // 
            this.chkDependencia.AutoSize = true;
            this.chkDependencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDependencia.Location = new System.Drawing.Point(15, 224);
            this.chkDependencia.Name = "chkDependencia";
            this.chkDependencia.Size = new System.Drawing.Size(243, 20);
            this.chkDependencia.TabIndex = 93;
            this.chkDependencia.TabStop = true;
            this.chkDependencia.Text = "BUSQUEDA POR RENGLONES";
            this.chkDependencia.UseVisualStyleBackColor = true;
            this.chkDependencia.CheckedChanged += new System.EventHandler(this.chkDependencia_CheckedChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFecha.Location = new System.Drawing.Point(13, 119);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(200, 20);
            this.chkFecha.TabIndex = 92;
            this.chkFecha.TabStop = true;
            this.chkFecha.Text = "BUSQUEDA POR FECHA";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // fechahasta
            // 
            this.fechahasta.Location = new System.Drawing.Point(135, 175);
            this.fechahasta.Name = "fechahasta";
            this.fechahasta.Size = new System.Drawing.Size(200, 20);
            this.fechahasta.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 90;
            this.label1.Text = "FECHA HASTA:";
            // 
            // fechadesde
            // 
            this.fechadesde.Location = new System.Drawing.Point(135, 147);
            this.fechadesde.Name = "fechadesde";
            this.fechadesde.Size = new System.Drawing.Size(200, 20);
            this.fechadesde.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 88;
            this.label4.Text = "FECHA DESDE:";
            // 
            // frmPrintRequerimientosXRenglones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 312);
            this.Controls.Add(this.chkAdquiridos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.cmbDependencia);
            this.Controls.Add(this.chkDependencia);
            this.Controls.Add(this.chkFecha);
            this.Controls.Add(this.fechahasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechadesde);
            this.Controls.Add(this.label4);
            this.Name = "frmPrintRequerimientosXRenglones";
            this.Text = "frmPrintRequerimientosXRenglones";
            this.Load += new System.EventHandler(this.frmPrintRequerimientosXRenglones_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.fechadesde, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.fechahasta, 0);
            this.Controls.SetChildIndex(this.chkFecha, 0);
            this.Controls.SetChildIndex(this.chkDependencia, 0);
            this.Controls.SetChildIndex(this.cmbDependencia, 0);
            this.Controls.SetChildIndex(this.chkTodos, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.chkAdquiridos, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAdquiridos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton chkTodos;
        private System.Windows.Forms.ComboBox cmbDependencia;
        private System.Windows.Forms.RadioButton chkDependencia;
        private System.Windows.Forms.RadioButton chkFecha;
        private System.Windows.Forms.DateTimePicker fechahasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechadesde;
        private System.Windows.Forms.Label label4;
    }
}
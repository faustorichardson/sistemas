namespace SisGesEntrenamiento
{
    partial class frmPrintEstadisticasEscuelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintEstadisticasEscuelas));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.provincias = new System.Windows.Forms.RadioButton();
            this.municipios = new System.Windows.Forms.RadioButton();
            this.regionales = new System.Windows.Forms.RadioButton();
            this.distritoseducativos = new System.Windows.Forms.RadioButton();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(324, 22);
            this.lblTituloForm.Text = "Genera Estadisticas Escuelas Publicas";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(356, 54);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 13;
            this.btnImprimir.Text = "Listar";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(356, 112);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // provincias
            // 
            this.provincias.AutoSize = true;
            this.provincias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provincias.Location = new System.Drawing.Point(87, 49);
            this.provincias.Name = "provincias";
            this.provincias.Size = new System.Drawing.Size(137, 22);
            this.provincias.TabIndex = 14;
            this.provincias.Text = "Por Provincias";
            this.provincias.UseVisualStyleBackColor = true;
            // 
            // municipios
            // 
            this.municipios.AutoSize = true;
            this.municipios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.municipios.Location = new System.Drawing.Point(87, 77);
            this.municipios.Name = "municipios";
            this.municipios.Size = new System.Drawing.Size(139, 22);
            this.municipios.TabIndex = 15;
            this.municipios.Text = "Por Municipios";
            this.municipios.UseVisualStyleBackColor = true;
            // 
            // regionales
            // 
            this.regionales.AutoSize = true;
            this.regionales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionales.Location = new System.Drawing.Point(87, 107);
            this.regionales.Name = "regionales";
            this.regionales.Size = new System.Drawing.Size(142, 22);
            this.regionales.TabIndex = 16;
            this.regionales.Text = "Por Regionales";
            this.regionales.UseVisualStyleBackColor = true;
            // 
            // distritoseducativos
            // 
            this.distritoseducativos.AutoSize = true;
            this.distritoseducativos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distritoseducativos.Location = new System.Drawing.Point(87, 132);
            this.distritoseducativos.Name = "distritoseducativos";
            this.distritoseducativos.Size = new System.Drawing.Size(210, 22);
            this.distritoseducativos.TabIndex = 17;
            this.distritoseducativos.Text = "Por Distritos Educativos";
            this.distritoseducativos.UseVisualStyleBackColor = true;
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodas.Location = new System.Drawing.Point(244, 50);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(71, 19);
            this.chkTodas.TabIndex = 18;
            this.chkTodas.Text = "TODAS";
            this.chkTodas.UseVisualStyleBackColor = true;
            // 
            // frmPrintEstadisticasEscuelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 173);
            this.Controls.Add(this.chkTodas);
            this.Controls.Add(this.distritoseducativos);
            this.Controls.Add(this.regionales);
            this.Controls.Add(this.municipios);
            this.Controls.Add(this.provincias);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmPrintEstadisticasEscuelas";
            this.Text = "frmPrintEstadisticasEscuelas";
            this.Load += new System.EventHandler(this.frmPrintEstadisticasEscuelas_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.provincias, 0);
            this.Controls.SetChildIndex(this.municipios, 0);
            this.Controls.SetChildIndex(this.regionales, 0);
            this.Controls.SetChildIndex(this.distritoseducativos, 0);
            this.Controls.SetChildIndex(this.chkTodas, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RadioButton provincias;
        private System.Windows.Forms.RadioButton municipios;
        private System.Windows.Forms.RadioButton regionales;
        private System.Windows.Forms.RadioButton distritoseducativos;
        private System.Windows.Forms.CheckBox chkTodas;
    }
}
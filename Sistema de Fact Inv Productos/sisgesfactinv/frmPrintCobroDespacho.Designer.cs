namespace SisGesFactInv
{
    partial class frmPrintCobroDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintCobroDespacho));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rbDespachada = new System.Windows.Forms.RadioButton();
            this.rbCobradas = new System.Windows.Forms.RadioButton();
            this.rbAnuladas = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(455, 22);
            this.lblTituloForm.Text = "IMPRESION DE COBROS / FACTURAS / DESPACHOS";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(375, 118);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 11;
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
            this.btnImprimir.Location = new System.Drawing.Point(375, 56);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 45);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // rbDespachada
            // 
            this.rbDespachada.AutoSize = true;
            this.rbDespachada.Checked = true;
            this.rbDespachada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDespachada.Location = new System.Drawing.Point(74, 56);
            this.rbDespachada.Name = "rbDespachada";
            this.rbDespachada.Size = new System.Drawing.Size(204, 17);
            this.rbDespachada.TabIndex = 12;
            this.rbDespachada.TabStop = true;
            this.rbDespachada.Text = "PENDIENTES DE DESPACHAR";
            this.rbDespachada.UseVisualStyleBackColor = true;
            // 
            // rbCobradas
            // 
            this.rbCobradas.AutoSize = true;
            this.rbCobradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCobradas.Location = new System.Drawing.Point(74, 94);
            this.rbCobradas.Name = "rbCobradas";
            this.rbCobradas.Size = new System.Drawing.Size(180, 17);
            this.rbCobradas.TabIndex = 13;
            this.rbCobradas.Text = "PENDIENTES DE COBRAR";
            this.rbCobradas.UseVisualStyleBackColor = true;
            // 
            // rbAnuladas
            // 
            this.rbAnuladas.AutoSize = true;
            this.rbAnuladas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAnuladas.Location = new System.Drawing.Point(74, 132);
            this.rbAnuladas.Name = "rbAnuladas";
            this.rbAnuladas.Size = new System.Drawing.Size(91, 17);
            this.rbAnuladas.TabIndex = 14;
            this.rbAnuladas.Text = "ANULADAS";
            this.rbAnuladas.UseVisualStyleBackColor = true;
            // 
            // frmPrintCobroDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 182);
            this.Controls.Add(this.rbAnuladas);
            this.Controls.Add(this.rbCobradas);
            this.Controls.Add(this.rbDespachada);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmPrintCobroDespacho";
            this.Text = "frmPrintCobroDespacho";
            this.Load += new System.EventHandler(this.frmPrintCobroDespacho_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.rbDespachada, 0);
            this.Controls.SetChildIndex(this.rbCobradas, 0);
            this.Controls.SetChildIndex(this.rbAnuladas, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rbDespachada;
        private System.Windows.Forms.RadioButton rbCobradas;
        private System.Windows.Forms.RadioButton rbAnuladas;
    }
}
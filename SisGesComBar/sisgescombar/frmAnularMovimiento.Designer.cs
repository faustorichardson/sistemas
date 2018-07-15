namespace SisGesComBar
{
    partial class frmAnularMovimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnularMovimiento));
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.rbRecibido = new System.Windows.Forms.RadioButton();
            this.rbGastado = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.Size = new System.Drawing.Size(262, 22);
            this.lblTituloForm.Text = "Anular Movimiento Combustible";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(139, 51);
            this.txtID.MaxLength = 25;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(102, 20);
            this.txtID.TabIndex = 66;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "ID Movimiento";
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnular.Location = new System.Drawing.Point(301, 42);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(92, 45);
            this.btnAnular.TabIndex = 65;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(301, 103);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 45);
            this.btnSalir.TabIndex = 68;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // rbRecibido
            // 
            this.rbRecibido.AutoSize = true;
            this.rbRecibido.Checked = true;
            this.rbRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRecibido.Location = new System.Drawing.Point(37, 90);
            this.rbRecibido.Name = "rbRecibido";
            this.rbRecibido.Size = new System.Drawing.Size(147, 17);
            this.rbRecibido.TabIndex = 69;
            this.rbRecibido.TabStop = true;
            this.rbRecibido.Text = "Combustible Recibido";
            this.rbRecibido.UseVisualStyleBackColor = true;
            // 
            // rbGastado
            // 
            this.rbGastado.AutoSize = true;
            this.rbGastado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGastado.Location = new System.Drawing.Point(37, 117);
            this.rbGastado.Name = "rbGastado";
            this.rbGastado.Size = new System.Drawing.Size(144, 17);
            this.rbGastado.TabIndex = 70;
            this.rbGastado.TabStop = true;
            this.rbGastado.Text = "Combustible Gastado";
            this.rbGastado.UseVisualStyleBackColor = true;
            // 
            // frmAnularMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 164);
            this.Controls.Add(this.rbGastado);
            this.Controls.Add(this.rbRecibido);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnular);
            this.Name = "frmAnularMovimiento";
            this.Text = "frmAnularMovimiento";
            this.Load += new System.EventHandler(this.frmAnularMovimiento_Load);
            this.Controls.SetChildIndex(this.lblTituloForm, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.rbRecibido, 0);
            this.Controls.SetChildIndex(this.rbGastado, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RadioButton rbRecibido;
        private System.Windows.Forms.RadioButton rbGastado;
    }
}
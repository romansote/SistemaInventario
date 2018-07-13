namespace WindowsFormsApplication1
{
    partial class FrmMenu
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
            this.btnEj1 = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.btnTrycatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEj1
            // 
            this.btnEj1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEj1.Location = new System.Drawing.Point(40, 24);
            this.btnEj1.Name = "btnEj1";
            this.btnEj1.Size = new System.Drawing.Size(125, 23);
            this.btnEj1.TabIndex = 0;
            this.btnEj1.Text = "Validando campos";
            this.btnEj1.UseVisualStyleBackColor = false;
            this.btnEj1.Click += new System.EventHandler(this.btnEj1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(40, 110);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(125, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Location = new System.Drawing.Point(40, 53);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(125, 23);
            this.btnCalculadora.TabIndex = 2;
            this.btnCalculadora.Text = "Calculadora";
            this.btnCalculadora.UseVisualStyleBackColor = true;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // btnTrycatch
            // 
            this.btnTrycatch.Location = new System.Drawing.Point(40, 81);
            this.btnTrycatch.Name = "btnTrycatch";
            this.btnTrycatch.Size = new System.Drawing.Size(125, 23);
            this.btnTrycatch.TabIndex = 3;
            this.btnTrycatch.Text = "TryCatch";
            this.btnTrycatch.UseVisualStyleBackColor = true;
            this.btnTrycatch.Click += new System.EventHandler(this.btnTrycatch_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(207, 365);
            this.Controls.Add(this.btnTrycatch);
            this.Controls.Add(this.btnCalculadora);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEj1);
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEj1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.Button btnTrycatch;
    }
}
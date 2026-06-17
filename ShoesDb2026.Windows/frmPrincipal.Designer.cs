namespace ShoesDb2026.Windows
{
    partial class frmPrincipal
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
            statusStrip1 = new StatusStrip();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            labelFecha = new Label();
            labelFechaActual = new Label();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabelUsuarioActual = new ToolStripStatusLabel();
            label2 = new Label();
            label3 = new Label();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelUsuarioActual });
            statusStrip1.Location = new Point(0, 480);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelFechaActual);
            panel1.Controls.Add(labelFecha);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(807, 64);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 411);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(256, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(544, 411);
            panel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 17);
            label1.Name = "label1";
            label1.Size = new Size(139, 28);
            label1.TabIndex = 0;
            label1.Text = "SHOES 2026";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(412, 17);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(50, 20);
            labelFecha.TabIndex = 1;
            labelFecha.Text = "Fecha:";
            // 
            // labelFechaActual
            // 
            labelFechaActual.AutoSize = true;
            labelFechaActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFechaActual.Location = new Point(468, 17);
            labelFechaActual.Name = "labelFechaActual";
            labelFechaActual.Size = new Size(95, 20);
            labelFechaActual.TabIndex = 2;
            labelFechaActual.Text = "17/06/2026";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(66, 20);
            toolStripStatusLabel1.Text = "Usuario: ";
            // 
            // toolStripStatusLabelUsuarioActual
            // 
            toolStripStatusLabelUsuarioActual.Name = "toolStripStatusLabelUsuarioActual";
            toolStripStatusLabelUsuarioActual.Size = new Size(133, 20);
            toolStripStatusLabelUsuarioActual.Text = "Usuario conectado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(143, 155);
            label2.Name = "label2";
            label2.Size = new Size(270, 23);
            label2.TabIndex = 0;
            label2.Text = "Sistema de Gestion de Zapatillas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 198);
            label3.Name = "label3";
            label3.Size = new Size(336, 20);
            label3.TabIndex = 1;
            label3.Text = "Seleccione una opcion del menu para comenzar";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 506);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrincipal";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabelUsuarioActual;
        private Label labelFechaActual;
        private Label labelFecha;
        private Label label1;
        private Label label3;
        private Label label2;
    }
}
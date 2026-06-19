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
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblUsuarioActual = new ToolStripStatusLabel();
            panel1 = new Panel();
            btnLogout = new Button();
            labelFechaActual = new Label();
            labelFecha = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnZapatillas = new Button();
            btnDeportes = new Button();
            btnTalles = new Button();
            btnGeneros = new Button();
            btnMarcas = new Button();
            panel3 = new Panel();
            label3 = new Label();
            label2 = new Label();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblUsuarioActual });
            statusStrip1.Location = new Point(0, 480);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(66, 20);
            toolStripStatusLabel1.Text = "Usuario: ";
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(133, 20);
            lblUsuarioActual.Text = "Usuario conectado";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(labelFechaActual);
            panel1.Controls.Add(labelFecha);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(807, 64);
            panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(255, 128, 128);
            btnLogout.Font = new Font("Bahnschrift", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(691, 16);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(77, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // labelFechaActual
            // 
            labelFechaActual.AutoSize = true;
            labelFechaActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFechaActual.Location = new Point(468, 24);
            labelFechaActual.Name = "labelFechaActual";
            labelFechaActual.Size = new Size(95, 20);
            labelFechaActual.TabIndex = 2;
            labelFechaActual.Text = "17/06/2026";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(412, 24);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(50, 20);
            labelFecha.TabIndex = 1;
            labelFecha.Text = "Fecha:";
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
            // panel2
            // 
            panel2.Controls.Add(btnZapatillas);
            panel2.Controls.Add(btnDeportes);
            panel2.Controls.Add(btnTalles);
            panel2.Controls.Add(btnGeneros);
            panel2.Controls.Add(btnMarcas);
            panel2.Location = new Point(0, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 411);
            panel2.TabIndex = 2;
            // 
            // btnZapatillas
            // 
            btnZapatillas.BackColor = SystemColors.ButtonShadow;
            btnZapatillas.Location = new Point(18, 282);
            btnZapatillas.Name = "btnZapatillas";
            btnZapatillas.Size = new Size(210, 101);
            btnZapatillas.TabIndex = 4;
            btnZapatillas.Text = "Zapatillas";
            btnZapatillas.UseVisualStyleBackColor = false;
            // 
            // btnDeportes
            // 
            btnDeportes.Location = new Point(18, 221);
            btnDeportes.Name = "btnDeportes";
            btnDeportes.Size = new Size(210, 46);
            btnDeportes.TabIndex = 3;
            btnDeportes.Text = "Deportes";
            btnDeportes.UseVisualStyleBackColor = true;
            btnDeportes.Click += btnDeportes_Click;
            // 
            // btnTalles
            // 
            btnTalles.Location = new Point(18, 155);
            btnTalles.Name = "btnTalles";
            btnTalles.Size = new Size(210, 46);
            btnTalles.TabIndex = 2;
            btnTalles.Text = "Talles";
            btnTalles.UseVisualStyleBackColor = true;
            // 
            // btnGeneros
            // 
            btnGeneros.Location = new Point(18, 93);
            btnGeneros.Name = "btnGeneros";
            btnGeneros.Size = new Size(210, 46);
            btnGeneros.TabIndex = 1;
            btnGeneros.Text = "Generos";
            btnGeneros.UseVisualStyleBackColor = true;
            btnGeneros.Click += btnGeneros_Click;
            // 
            // btnMarcas
            // 
            btnMarcas.Location = new Point(18, 28);
            btnMarcas.Name = "btnMarcas";
            btnMarcas.Size = new Size(210, 46);
            btnMarcas.TabIndex = 0;
            btnMarcas.Text = "Marcas";
            btnMarcas.UseVisualStyleBackColor = true;
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
            Load += frmPrincipal_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
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
        private ToolStripStatusLabel lblUsuarioActual;
        private Label labelFechaActual;
        private Label labelFecha;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button btnMarcas;
        private Button btnZapatillas;
        private Button btnDeportes;
        private Button btnTalles;
        private Button btnGeneros;
        private Button btnLogout;
    }
}
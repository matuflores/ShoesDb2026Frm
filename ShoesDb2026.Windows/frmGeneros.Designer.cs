namespace ShoesDb2026.Windows
{
    partial class frmGeneros
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
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            btnOff = new Button();
            lblCantidadDeGeneros = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnOff);
            splitContainer1.Panel2.Controls.Add(lblCantidadDeGeneros);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(548, 283);
            splitContainer1.SplitterDistance = 226;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.BackgroundColor = Color.White;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(548, 226);
            dgvDatos.TabIndex = 1;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.HeaderText = "Genero";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // btnOff
            // 
            btnOff.FlatStyle = FlatStyle.Flat;
            btnOff.Image = Properties.Resources.off;
            btnOff.Location = new Point(499, 3);
            btnOff.Name = "btnOff";
            btnOff.Size = new Size(46, 47);
            btnOff.TabIndex = 2;
            btnOff.UseVisualStyleBackColor = true;
            btnOff.Click += btnOff_Click;
            // 
            // lblCantidadDeGeneros
            // 
            lblCantidadDeGeneros.AutoSize = true;
            lblCantidadDeGeneros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadDeGeneros.Location = new Point(199, 15);
            lblCantidadDeGeneros.Name = "lblCantidadDeGeneros";
            lblCantidadDeGeneros.Size = new Size(18, 20);
            lblCantidadDeGeneros.TabIndex = 1;
            lblCantidadDeGeneros.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 15);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de registros:";
            // 
            // frmGeneros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 283);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Name = "frmGeneros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generos";
            Load += frmGeneros_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private Label lblCantidadDeGeneros;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private Button btnOff;
    }
}
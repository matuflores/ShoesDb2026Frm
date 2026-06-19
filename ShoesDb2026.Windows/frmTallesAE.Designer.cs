namespace ShoesDb2026.Windows
{
    partial class frmTallesAE
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
            components = new System.ComponentModel.Container();
            btnCancelar = new Button();
            btnOk = new Button();
            cbActivo = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            nudTalle = new NumericUpDown();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudTalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(275, 165);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(134, 62);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.LOGIN;
            btnOk.Location = new Point(86, 165);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(134, 62);
            btnOk.TabIndex = 10;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // cbActivo
            // 
            cbActivo.AutoSize = true;
            cbActivo.Location = new Point(178, 96);
            cbActivo.Name = "cbActivo";
            cbActivo.Size = new Size(18, 17);
            cbActivo.TabIndex = 8;
            cbActivo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 93);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 7;
            label2.Text = "Activo?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 45);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 6;
            label1.Text = "Talle:";
            // 
            // nudTalle
            // 
            nudTalle.DecimalPlaces = 1;
            nudTalle.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudTalle.Location = new Point(178, 43);
            nudTalle.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudTalle.Minimum = new decimal(new int[] { 14, 0, 0, 0 });
            nudTalle.Name = "nudTalle";
            nudTalle.Size = new Size(231, 27);
            nudTalle.TabIndex = 12;
            nudTalle.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmTallesAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 266);
            Controls.Add(nudTalle);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(cbActivo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmTallesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmTallesAE";
            ((System.ComponentModel.ISupportInitialize)nudTalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnOk;
        private CheckBox cbActivo;
        private Label label2;
        private Label label1;
        private NumericUpDown nudTalle;
        private ErrorProvider errorProvider1;
    }
}
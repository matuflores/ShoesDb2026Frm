namespace ShoesDb2026.Windows
{
    partial class frmDeportesAE
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
            label1 = new Label();
            label2 = new Label();
            cbActivo = new CheckBox();
            textBoxDeporte = new TextBox();
            btnOk = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 38);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 0;
            label1.Text = "Deporte: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 86);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 1;
            label2.Text = "Activo?";
            // 
            // cbActivo
            // 
            cbActivo.AutoSize = true;
            cbActivo.Location = new Point(175, 89);
            cbActivo.Name = "cbActivo";
            cbActivo.Size = new Size(18, 17);
            cbActivo.TabIndex = 2;
            cbActivo.UseVisualStyleBackColor = true;
            // 
            // textBoxDeporte
            // 
            textBoxDeporte.Location = new Point(175, 33);
            textBoxDeporte.Name = "textBoxDeporte";
            textBoxDeporte.Size = new Size(231, 27);
            textBoxDeporte.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.LOGIN;
            btnOk.Location = new Point(83, 158);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(134, 62);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(272, 158);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(134, 62);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmDeportesAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 266);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(textBoxDeporte);
            Controls.Add(cbActivo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDeportesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDeportesAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox cbActivo;
        private TextBox textBoxDeporte;
        private Button btnOk;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
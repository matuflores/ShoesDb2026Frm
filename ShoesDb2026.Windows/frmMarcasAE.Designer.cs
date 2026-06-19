namespace ShoesDb2026.Windows
{
    partial class frmMarcasAE
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
            textBoxMarca = new TextBox();
            cbActivo = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            textBoxURLLogo = new TextBox();
            label3 = new Label();
            errorProvider1 = new ErrorProvider(components);
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
            // textBoxMarca
            // 
            textBoxMarca.Location = new Point(178, 40);
            textBoxMarca.Name = "textBoxMarca";
            textBoxMarca.Size = new Size(231, 27);
            textBoxMarca.TabIndex = 9;
            // 
            // cbActivo
            // 
            cbActivo.AutoSize = true;
            cbActivo.Location = new Point(178, 127);
            cbActivo.Name = "cbActivo";
            cbActivo.Size = new Size(18, 17);
            cbActivo.TabIndex = 8;
            cbActivo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 124);
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
            label1.Size = new Size(57, 20);
            label1.TabIndex = 6;
            label1.Text = "Marca: ";
            // 
            // textBoxURLLogo
            // 
            textBoxURLLogo.Location = new Point(178, 83);
            textBoxURLLogo.Name = "textBoxURLLogo";
            textBoxURLLogo.Size = new Size(231, 27);
            textBoxURLLogo.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 86);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 12;
            label3.Text = "URL Logo:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmMarcasAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 266);
            Controls.Add(textBoxURLLogo);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(textBoxMarca);
            Controls.Add(cbActivo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmMarcasAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMarcasAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnOk;
        private TextBox textBoxMarca;
        private CheckBox cbActivo;
        private Label label2;
        private Label label1;
        private TextBox textBoxURLLogo;
        private Label label3;
        private ErrorProvider errorProvider1;
    }
}
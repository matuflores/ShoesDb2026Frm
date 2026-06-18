namespace ShoesDb2026.Windows
{
    partial class frmLogin
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
            btnLogin = new Button();
            btnClose = new Button();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            txtBoxUser = new TextBox();
            txtBoxPassword = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Image = Properties.Resources.LOGIN;
            btnLogin.Location = new Point(271, 216);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(129, 52);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Cancel;
            btnClose.Location = new Point(544, 216);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(129, 52);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 70);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 2;
            label1.Text = "User:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 134);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // txtBoxUser
            // 
            txtBoxUser.Location = new Point(400, 67);
            txtBoxUser.Name = "txtBoxUser";
            txtBoxUser.Size = new Size(273, 27);
            txtBoxUser.TabIndex = 0;
            txtBoxUser.Text = "admin";
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Location = new Point(400, 131);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PasswordChar = '*';
            txtBoxPassword.Size = new Size(273, 27);
            txtBoxPassword.TabIndex = 1;
            txtBoxPassword.Text = "1234";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.KEY;
            pictureBox1.Location = new Point(34, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 208);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 321);
            Controls.Add(pictureBox1);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnClose;
        private ErrorProvider errorProvider1;
        private TextBox txtBoxPassword;
        private TextBox txtBoxUser;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
using ShoesDb2026.Windows.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShoesDb2026.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActual.Text = $"{Sesion.UsuarioActual!.UserName}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

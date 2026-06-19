using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActual.Text = $"{Sesion.UsuarioActual!.UserName}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDeportes_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmDeportes>())
            {
                frm.Text = "Lista de Deportes";
                frm.ShowDialog();
            }
        }

        private void btnGeneros_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmGeneros>())
            {
                frm.Text = "Lista de Géneros";
                frm.ShowDialog();
            }
        }
    }
}

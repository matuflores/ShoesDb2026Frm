using Microsoft.Extensions.DependencyInjection;
using ShoesDb2026.Entities;
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
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider _provider;
        public frmLogin(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Login cancelled.", "Salida",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                
                Usuario? usuario = UsuariosSistema.Usuarios.FirstOrDefault
                    (u => u.UserName == txtBoxUser.Text
                    && u.Password == txtBoxPassword.Text);
                if (usuario is null)
                {
                    MessageBox.Show("Invalid username or password.", "Error de autenticación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    LimpiarDatosLogin();
                    return;
                }
                frmPrincipal frm=_provider.GetRequiredService<frmPrincipal>();
                frm.ShowDialog();
                LimpiarDatosLogin();
            }
        }

        private void LimpiarDatosLogin()
        {
            txtBoxUser.Clear();
            txtBoxPassword.Clear();
            txtBoxUser.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtBoxUser.Text)) 
            { 
                valido = false; 
                errorProvider1.SetError(txtBoxUser, "Ingrese el nombre de usuario.");
                txtBoxUser.Focus();
            }
            if (string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                valido = false;
                errorProvider1.SetError(txtBoxUser, "Ingrese el nombre de usuario.");
            }
            return valido;
            
        }
    }
}

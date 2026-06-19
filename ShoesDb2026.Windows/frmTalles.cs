using Microsoft.Extensions.DependencyInjection;
using ShoesDb2026.Service.DTOs.Size;
using ShoesDb2026.Service.DTOs.Sport;
using ShoesDb2026.Service.Interfaces;
using ShoesDb2026.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShoesDb2026.Windows
{
    public partial class frmTalles : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SizeListDto>? _listSizes;
        private bool filtroActivo = false;
        public frmTalles(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmTalles_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider
                    .GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = sizeService.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSizes = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listSizes);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosEnGrilla(List<SizeListDto>? listSizes)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listSizes is null ||
                listSizes.Count == 0) return;
            foreach (var item in listSizes)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidadTalles.Text = listSizes.Count.ToString();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

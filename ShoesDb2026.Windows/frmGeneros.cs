using Microsoft.Extensions.DependencyInjection;
using ShoesDb2026.Service.DTOs.Genre;
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
    public partial class frmGeneros : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<GenreListDto>? _listGenres;
        public frmGeneros(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmGeneros_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider
                    .GetRequiredService<IGenreService>();
                try
                {
                    var resultadoConsulta = genreService.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listGenres = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listGenres);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosEnGrilla(List<GenreListDto>? listGenres)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listGenres is null ||
                listGenres.Count == 0) return;
            foreach (var item in listGenres)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidadDeGeneros.Text = listGenres.Count.ToString();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

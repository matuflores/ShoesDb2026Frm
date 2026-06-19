using Microsoft.Extensions.DependencyInjection;
using ShoesDb2026.Service.DTOs.Brand;
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
    public partial class frmMarcas : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<BrandListDto>? _listBrands;
        private bool filtroActivo = false;
        public frmMarcas(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider
                    .GetRequiredService<IBrandService>();
                try
                {
                    var resultadoConsulta = brandService.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listBrands = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listBrands);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosEnGrilla(List<BrandListDto>? listBrands)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listBrands is null ||
                listBrands.Count == 0) return;
            foreach (var item in listBrands)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidad.Text = listBrands.Count.ToString();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            ManejarControles(false);
        }

        private void tsmActivo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider
                    .GetRequiredService<IBrandService>();
                try
                {
                    var resultadoConsulta = brandService.FilterForActive(true);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listBrands = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listBrands);
                    ManejarControles(true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ManejarControles(bool v)
        {
            filtroActivo = v;
            tsbFiltrar.BackColor = filtroActivo ? Color.Orange : SystemColors.Control;

            tsbNuevo.Enabled = !v;
            tsbEditar.Enabled = !v;
            tsbBorrar.Enabled = !v;
        }

        private void tsmNoActivo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider
                    .GetRequiredService<IBrandService>();
                try
                {
                    var resultadoConsulta = brandService.FilterForActive(false);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listBrands = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listBrands);
                    ManejarControles(true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione la marca a borrar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;
            BrandListDto brandListDto = (BrandListDto)filaSeleccionada.Tag;

            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider
                    .GetRequiredService<IBrandService>();

                var resultadoConsulta = brandService.GetForDelete(brandListDto.BrandId);
                if (resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var brandDeleteDto = resultadoConsulta.Value;

                var dr = MessageBox.Show($"¿Confirma que desea eliminar la marca '{brandListDto.BrandName}'?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) return;


                try
                {
                    var resultadoEliminacion = brandService.Delete(brandDeleteDto!);
                    if (resultadoEliminacion.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoEliminacion.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (resultadoEliminacion.IsConcurrencyConflict)
                    {
                        string errores = string.Join("\n", resultadoEliminacion.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RecargarGrilla();
                        return;
                    }

                    MessageBox.Show("Marca eliminada exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            ManejarControles(false);
        }

        private void ManejarControles(bool v)
        {
            filtroActivo = v;
            tsbFiltrar.BackColor = filtroActivo ? Color.Orange : SystemColors.Control;

            tsbNuevo.Enabled = !v;
            tsbEditar.Enabled = !v;
            tsbBorrar.Enabled = !v;
        }

        private void tsmActivo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider
                    .GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = sizeService.FilterForActive(true);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSizes = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listSizes);
                    ManejarControles(true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tsmNoActivo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider
                    .GetRequiredService<ISizeService>();
                try
                {
                    var resultadoConsulta = sizeService.FilterForActive(false);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSizes = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listSizes);
                    lblCantidadTalles.Text = _listSizes.Count.ToString();
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
                MessageBox.Show("Por favor, seleccione el talles a borrar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;
            SizeListDto sizeListDto = (SizeListDto)filaSeleccionada.Tag;

            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider
                    .GetRequiredService<ISizeService>();

                var resultadoConsulta = sizeService.GetForDelete(sizeListDto.SizeId);
                if (resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var sizeDeleteDto = resultadoConsulta.Value;

                var dr = MessageBox.Show($"¿Confirma que desea eliminar el talles '{sizeListDto.SizeNumber}'?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) return;


                try
                {
                    var resultadoEliminacion = sizeService.Delete(sizeDeleteDto!);
                    if (resultadoEliminacion.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoEliminacion.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RecargarGrilla();
                        return;
                    }

                    MessageBox.Show("Talle eliminado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmTallesAE frm = scope.ServiceProvider.GetRequiredService<frmTallesAE>())
                {
                    frm.Text = "Nuevo Talle";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        RecargarGrilla();
                    }

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;
            var sizeListDto = (SizeListDto)filaSeleccionada.Tag;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var sizeService = scope.ServiceProvider
                .GetRequiredService<ISizeService>();
                    var resultadoConsulta = sizeService
                        .GetForUpdate(sizeListDto.SizeId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var sizeEditDto = resultadoConsulta.Value;
                    using (frmTallesAE frm = scope.ServiceProvider
                        .GetRequiredService<frmTallesAE>())
                    {
                        frm.Text = "Editar Talle";
                        frm.SetSize(sizeEditDto);
                        frm.ShowDialog();
                        if (frm.ConcurrencyConflict)
                        {
                            RecargarGrilla();
                        }
                        if (frm.DataChanged)
                        {
                            RecargarGrilla();
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

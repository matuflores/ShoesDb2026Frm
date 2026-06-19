using Microsoft.Extensions.DependencyInjection;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoesDb2026.Windows
{
    public partial class frmDeportes : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SportListDto>? _listSports;
        private bool filtroActivo = false;
        public frmDeportes(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDeportes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider
                    .GetRequiredService<ISportService>();
                try
                {
                    var resultadoConsulta = sportService.GetAll();
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listSports);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosEnGrilla(List<SportListDto>? listSports)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (listSports is null ||
                listSports.Count == 0) return;
            foreach (var item in listSports)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidad.Text = listSports.Count.ToString();
        }

        private void tsmActivo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider
                    .GetRequiredService<ISportService>();
                try
                {
                    var resultadoConsulta = sportService.FilterForActive(true);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listSports);
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
                var sportService = scope.ServiceProvider
                    .GetRequiredService<ISportService>();
                try
                {
                    var resultadoConsulta = sportService.FilterForActive(false);
                    if (resultadoConsulta.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoConsulta.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _listSports = resultadoConsulta.Value;
                    MostrarDatosEnGrilla(_listSports);
                    lblCantidad.Text = _listSports.Count.ToString();
                    ManejarControles(true);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            ManejarControles(false);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione el deporte a borrar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;
            SportListDto sportListDto = (SportListDto)filaSeleccionada.Tag;

            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider
                    .GetRequiredService<ISportService>();

                var resultadoConsulta = sportService.GetForDelete(sportListDto.SportId);
                if (resultadoConsulta.IsFailure)
                {
                    string errores = string.Join("\n", resultadoConsulta.Errors);
                    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var sportDeleteDto = resultadoConsulta.Value;

                var dr = MessageBox.Show($"¿Confirma que desea eliminar el deporte '{sportListDto.SportName}'?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) return;


                try
                {
                    var resultadoEliminacion = sportService.Delete(sportDeleteDto!);
                    if (resultadoEliminacion.IsFailure)
                    {
                        string errores = string.Join("\n", resultadoEliminacion.Errors);
                        MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //if (resultadoEliminacion.IsConcurrencyConflict)
                    //{
                    //    string errores = string.Join("\n", resultadoEliminacion.Errors);
                    //    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    RecargarGrilla();
                    //    return;
                    //}

                    MessageBox.Show("Deporte eliminado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                using (frmDeportesAE frm = scope.ServiceProvider.GetRequiredService<frmDeportesAE>())
                {
                    frm.Text = "Nuevo Deporte";
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
            var tipoListDto = (SportListDto)filaSeleccionada.Tag;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var sportService = scope.ServiceProvider
                .GetRequiredService<ISportService>();
                    var resultadoConsulta = sportService
                        .GetForUpdate(tipoListDto.SportId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var tipoEditDto = resultadoConsulta.Value;
                    using (frmDeportesAE frm = scope.ServiceProvider
                        .GetRequiredService<frmDeportesAE>())
                    {
                        frm.Text = "Editar Deporte";
                        frm.SetSport(tipoEditDto);
                        frm.ShowDialog();
                        if (frm.ConcurrencyConflict)//si hubo concurrencia se recarga la grilla
                        {
                            RecargarGrilla();
                        }
                        if (frm.DataChanged)//si cambiaron los datos se recarga la grilla
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

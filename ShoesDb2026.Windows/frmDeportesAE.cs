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
    public partial class frmDeportesAE : Form
    {
        private SportUpdateDto? _sportUpdateDto;
        private readonly ISportService _sportService;
        private bool _esEdicion = false;

        
        public frmDeportesAE(ISportService sportService)
        {
            InitializeComponent();
            _sportService = sportService;
        }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_sportUpdateDto is null)
            {
                cbActivo.Checked = true;
                cbActivo.Enabled = false;
            }
            else
            {
                textBoxDeporte.Text = _sportUpdateDto.SportName;
                cbActivo.Checked = _sportUpdateDto.Active;
                cbActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var _tipoCreateDto = new SportCreateDto();
                        _tipoCreateDto.SportName = textBoxDeporte.Text;
                        _tipoCreateDto.Active = cbActivo.Checked;
                        var resultadoAgregar = _sportService.Add(_tipoCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        var respuestaAgregarOtro = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (respuestaAgregarOtro == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();

                    }
                    else
                    {
                        if (_sportUpdateDto is null)
                        {
                            _sportUpdateDto = new SportUpdateDto();
                        }
                        _sportUpdateDto.SportName = textBoxDeporte.Text;
                        _sportUpdateDto.Active = cbActivo.Checked;

                        var resultadoEditar = _sportService
                            .Update(_sportUpdateDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);

                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;
                        }
                        if (resultadoEditar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        MessageBox.Show("Registro editado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            textBoxDeporte.Clear();
            cbActivo.Checked = true;
            cbActivo.Enabled = false;
            textBoxDeporte.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBoxDeporte.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxDeporte, "El nombre del deporte es requerido");

            }
            return valido;
        }
        //
        public void SetSport(SportUpdateDto? tipoEditDto)
        {
            _sportUpdateDto = tipoEditDto;
        }
    }
}

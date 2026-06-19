using ShoesDb2026.Service.DTOs.Size;
using ShoesDb2026.Service.DTOs.Sport;
using ShoesDb2026.Service.Interfaces;
using ShoesDb2026.Service.Services;
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
    public partial class frmTallesAE : Form
    {
        private SizeUpdateDto? _sizeUpdateDto;
        private readonly ISizeService _sizeService;
        private bool _esEdicion = false;
        public frmTallesAE(ISizeService sizeService)
        {
            InitializeComponent();
            _sizeService = sizeService;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_sizeUpdateDto is null)
            {
                cbActivo.Checked = true;
                cbActivo.Enabled = false;
            }
            else
            {
                nudTalle.Value = _sizeUpdateDto.SizeNumber;
                cbActivo.Checked = _sizeUpdateDto.Active;
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

                        var _sizeCreateDto = new SizeCreateDto();
                        _sizeCreateDto.SizeNumber = (decimal)nudTalle.Value;
                        var resultadoAgregar = _sizeService.Add(_sizeCreateDto);
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
                        if (_sizeUpdateDto is null)
                        {
                            _sizeUpdateDto = new SizeUpdateDto();
                        }
                        _sizeUpdateDto.SizeNumber = (decimal)nudTalle.Value;
                        _sizeUpdateDto.Active = cbActivo.Checked;

                        var resultadoEditar = _sizeService
                            .Update(_sizeUpdateDto);
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
            nudTalle.Value = 14;
            cbActivo.Checked = true;
            cbActivo.Enabled = false;
            nudTalle.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(nudTalle.Text))
            {
                valido = false;
                errorProvider1.SetError(nudTalle, "El número de talla es requerido");
            }
            return valido;
        }

        public void SetSize(SizeUpdateDto? sizeEditDto)
        {
            _sizeUpdateDto = sizeEditDto;
        }
    }
}

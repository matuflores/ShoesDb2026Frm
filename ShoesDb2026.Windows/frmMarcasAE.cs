using ShoesDb2026.Service.DTOs.Brand;
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
    public partial class frmMarcasAE : Form
    {
        private BrandUpdateDto? _brandUpdateDto;
        private readonly IBrandService _brandService;
        private bool _esEdicion = false;
        public frmMarcasAE(IBrandService brandService)
        {
            InitializeComponent();
            _brandService = brandService;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_brandUpdateDto is null)
            {
                cbActivo.Checked = true;
                cbActivo.Enabled = false;
            }
            else
            {
                textBoxMarca.Text = _brandUpdateDto.BrandName;
                textBoxURLLogo.Text = _brandUpdateDto.ImageUrl;
                cbActivo.Checked = _brandUpdateDto.Active;
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

                        var _brandCreateDto = new BrandCreateDto();
                        _brandCreateDto.BrandName = textBoxMarca.Text;
                        _brandCreateDto.Active = cbActivo.Checked;
                        _brandCreateDto.ImageUrl = textBoxURLLogo.Text;
                        var resultadoAgregar = _brandService.Add(_brandCreateDto);
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
                        if (_brandUpdateDto is null)
                        {
                            _brandUpdateDto = new BrandUpdateDto();
                        }
                        _brandUpdateDto.BrandName = textBoxMarca.Text;
                        _brandUpdateDto.ImageUrl = textBoxURLLogo.Text;
                        _brandUpdateDto.Active = cbActivo.Checked;

                        var resultadoEditar = _brandService
                            .Update(_brandUpdateDto);
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
            textBoxMarca.Clear();
            textBoxURLLogo.Clear();
            cbActivo.Checked = true;
            cbActivo.Enabled = false;
            textBoxMarca.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBoxMarca.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxMarca, "El nombre de la marca es requerido");

            }
            return valido;
        }

        public void SetBrand(BrandUpdateDto? brandEditDto)
        {
            _brandUpdateDto = brandEditDto;
        }
    }
}

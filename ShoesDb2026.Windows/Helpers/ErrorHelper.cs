using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Windows.Helpers
{
    public static class ErrorHelper
    {
        public static void MostrarErrores(List<string> listaErrores)
        {
            string errores = string.Join("\n", listaErrores);
            MessageBox.Show(errores, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

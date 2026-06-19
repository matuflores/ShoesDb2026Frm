using ShoesDb2026.Entities;
using ShoesDb2026.Service.DTOs.Brand;
using ShoesDb2026.Service.DTOs.Genre;
using ShoesDb2026.Service.DTOs.Sport;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Windows.Helpers
{
    public static class GridHelper
    {
        /// <summary>
        /// Método estático para limpiar una grilla
        /// </summary>
        /// <param name="grid">Grilla que se desea limpiar</param>
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        /// <summary>
        /// Método estático para construir una nueva fila
        /// de la grilla que me pasan
        /// </summary>
        /// <param name="grid">Grilla a la cual le creo la fila</param>
        /// <returns>Fila de la grilla resultante</returns>
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case BrandListDto brandDto:
                    r.Cells[0].Value = brandDto.BrandId;
                    r.Cells[1].Value = brandDto.BrandName;
                    r.Cells[2].Value = brandDto.ImageUrl;
                    r.Cells[3].Value = brandDto.Active;
                    break;
                case SportListDto sportDto:
                    r.Cells[0].Value = sportDto.SportId;
                    r.Cells[1].Value = sportDto.SportName;
                    r.Cells[2].Value = sportDto.Active;
                    break;
                case GenreListDto genreDto:
                    r.Cells[0].Value = genreDto.GenreId;
                    r.Cells[1].Value = genreDto.GenreName;
                    break;
            }

            r.Tag = obj;
        }
        /// <summary>
        /// Método estático para agregar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a agregar</param>
        /// <param name="grid">Grilla en la cual se agrega la fila</param>
        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        /// <summary>
        /// Método estático para eliminar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a eliminar</param>
        /// <param name="grid">Grilla en la cual se desea quitar la fila</param>
        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }
    }
}

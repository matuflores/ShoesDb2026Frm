using ShoesDb2026.Entities;
using ShoesDb2026.Service.DTOs.Brand;
using ShoesDb2026.Service.DTOs.Genre;
using ShoesDb2026.Service.DTOs.Size;
using ShoesDb2026.Service.DTOs.Sport;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
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
                //case BrandListDto brandDto:
                //    r.Cells[0].Value = brandDto.BrandId;
                //    r.Cells[1].Value = brandDto.BrandName;
                //    r.Cells[2].Value = brandDto.ImageUrl;
                //    r.Cells[3].Value = brandDto.Active;
                //    break;
                case SportListDto sportDto:
                    r.Cells[0].Value = sportDto.SportId;
                    r.Cells[1].Value = sportDto.SportName;
                    r.Cells[2].Value = sportDto.Active;
                    break;
                case GenreListDto genreDto:
                    r.Cells[0].Value = genreDto.GenreId;
                    r.Cells[1].Value = genreDto.GenreName;
                    break;
                case SizeListDto sizeDto:
                    r.Cells[0].Value = sizeDto.SizeId;
                    r.Cells[1].Value = sizeDto.SizeNumber;
                    r.Cells[2].Value = sizeDto.Active;
                    break;
            }

            r.Tag = obj;
        }
        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Entities.Interfaces
{
    public interface IConcurrencyEntity
    {
        public byte[] RowVersion { get; set; }
    }
}

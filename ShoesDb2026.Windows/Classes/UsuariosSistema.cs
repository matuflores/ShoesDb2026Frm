using ShoesDb2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesDb2026.Windows.Classes
{
    public static class UsuariosSistema
    {
        public static List<Usuario> Usuarios { get; } =
            [
            new Usuario { UserName = "admin", Password = "1234" },
            new Usuario { UserName = "empleado", Password = "1234" },
            ];
    }
}

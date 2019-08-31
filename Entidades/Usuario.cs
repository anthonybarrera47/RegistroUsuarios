using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string UserName { get; set; }
        public String Nombre { get; set; }
        public String Password { get; set; }
        public String TipoUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Usuarios()
        {
            UsuarioID = 0;
            UserName = string.Empty;
            Nombre = string.Empty;
            Password = string.Empty;
            TipoUsuario = string.Empty;
            FechaRegistro = DateTime.Now;
        }
        public Usuarios(int usuarioId, string userName, string nombre, string password, string tipo, DateTime fechaRegistro)
        {
            UsuarioID = usuarioId;
            UserName = userName;
            Nombre = nombre;
            Password = password;
            TipoUsuario = tipo;
            FechaRegistro = fechaRegistro;
        }
    }
}

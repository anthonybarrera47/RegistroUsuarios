using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual List<TelefonoDetalle> TelefonoDetalle { get; set; }
        public Usuarios()
        {
            UsuarioID = 0;
            UserName = string.Empty;
            Nombre = string.Empty;
            Password = string.Empty;
            TipoUsuario = string.Empty;
            FechaRegistro = DateTime.Now;
            TelefonoDetalle = new List<TelefonoDetalle>();
        }
        public Usuarios(int usuarioID, string userName, string nombre, string password, string tipoUsuario, DateTime fechaRegistro, List<TelefonoDetalle> telefonoDetalle)
        {
            UsuarioID = usuarioID;
            UserName = userName;
            Nombre = nombre;
            Password = password;
            TipoUsuario = tipoUsuario;
            FechaRegistro = fechaRegistro;
            TelefonoDetalle = telefonoDetalle;
        }
    }
}

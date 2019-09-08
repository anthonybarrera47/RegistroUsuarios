using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TelefonoDetalle
    {
        [Key]
        public int ID { get; set; }
        public string Numero { get; set; }
        public int TipoTelefonoID { get; set; }
        public int UsuarioID { get; set; }

        [ForeignKey("TipoTelefonoID")]
        public virtual TiposTelefono TiposTelefono { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuarios Usuario { get; set; }

        public TelefonoDetalle(int iD, string numero, int tipoTelefonoID, int usuarioID)
        {
            ID = iD;
            Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            TipoTelefonoID = tipoTelefonoID;
            UsuarioID = usuarioID;
        }

        public TelefonoDetalle()
        {
            ID = 0;
            Numero = string.Empty;
            TipoTelefonoID = 0;
            UsuarioID = 0;
        }
    }
}

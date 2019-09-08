using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class TiposTelefono
    {
        [Key]
        public int TipoTelefonoID { get; set; }
        public string Descripcion { get; set; }
        public TiposTelefono()
        {
            TipoTelefonoID = 0;
            Descripcion = string.Empty;
        }
        public TiposTelefono(int tipoTelefonoId, string descripcion)
        {
            TipoTelefonoID = tipoTelefonoId;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
        }
    }
}

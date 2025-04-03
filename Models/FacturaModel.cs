using System;
using System.Collections.Generic;

namespace Roles_Estructuras_Control.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }

        public DateTime FechaIngreso { get; set; } // ⚠️ Usa DateTime por compatibilidad

        public int NumeroFactura { get; set; }

        public int ClientesModelId { get; set; }
        public ClientesModel ClientesModel { get; set; }

        public ICollection<DetalleFacturaModel> DetallesFactura { get; set; }
    }
}

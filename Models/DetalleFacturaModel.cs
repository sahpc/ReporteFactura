using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roles_Estructuras_Control.Models
{
    public class DetalleFacturaModel
    {
        internal object valor;

        public int Id { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        // Relación con Producto
        public int ProductoModelsId { get; set; }
        public ProductoModels ProductoModels { get; set; }

        // Relación con Factura
        public int FacturaModelId { get; set; }
        public FacturaModel FacturaModel { get; set; }

        // Relación con Stock (opcional)
        public int? StockModelsId { get; set; }
        public StockModels StockModels { get; set; }

        // Relación con Usuario
        public string IdentityUserId { get; set; }
        public UsuariosModel UsuariosModel { get; set; }
    }
}

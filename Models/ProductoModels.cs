using System.ComponentModel.DataAnnotations;

namespace Roles_Estructuras_Control.Models
{
    public class ProductoModels
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Producto")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreProducto { get; set; }

        [Display(Name = "Presentación del Producto")]
        [MinLength(3, ErrorMessage = "La presentación debe tener al menos 3 caracteres")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Presentacion { get; set; }

        [Display(Name = "Código de Barras")]
        [MinLength(5, ErrorMessage = "El código debe tener al menos 5 caracteres")]
        public string CodigoBarras { get; set; }
    }
}

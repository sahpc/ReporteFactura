using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roles_Estructuras_Control.Data;
using Roles_Estructuras_Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roles_Estructuras_Control.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleFacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarFactura([FromBody] FacturaConDetalleDto facturaDto)
        {
            if (facturaDto == null || facturaDto.Cliente == null || facturaDto.Productos == null || !facturaDto.Productos.Any())
                return BadRequest(new { message = "Datos incompletos. Verifique cliente y productos." });

            // Crear factura
            var factura = new FacturaModel
            {
                NumeroFactura = facturaDto.NumeroFactura,
                FechaIngreso = DateTime.Now,
                ClientesModelId = facturaDto.Cliente.Id,
                DetallesFactura = new List<DetalleFacturaModel>()
            };

            foreach (var p in facturaDto.Productos)
            {
                var producto = await _context.Productos.FirstOrDefaultAsync(x => x.NombreProducto == p.NombreProducto);
                if (producto == null)
                {
                    return BadRequest(new { message = $"El producto '{p.NombreProducto}' no existe." });
                }

                factura.DetallesFactura.Add(new DetalleFacturaModel
                {
                    Cantidad = p.Cantidad,
                    Valor = p.PrecioUnitario,
                    ProductoModelsId = producto.Id
                });
            }

            _context.Factura.Add(factura);
            await _context.SaveChangesAsync();

            return Json(new { message = "✅ Factura guardada exitosamente." });
        }
    }

    // DTOs que recibe desde el frontend
    public class FacturaConDetalleDto
    {
        public int NumeroFactura { get; set; }
        public ClienteDto Cliente { get; set; }
        public List<ProductoDto> Productos { get; set; }
    }

    public class ClienteDto
    {
        public int Id { get; set; }
    }

    public class ProductoDto
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using Examen2Progra.Models;

namespace Examen2Progra.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            // 1. Consulta: agrupar metas por estado y contar cuántas hay en cada uno
            var metasAgrupadas = _context.Metas
                .GroupBy(m => m.Estado)
                .Select(g => new
                {
                    Estado = g.Key,       
                    Cantidad = g.Count()  
                })
                .ToList();

            // 2. Preparar labels y data para Chart.js
            
            var labels = metasAgrupadas
                .Select(x => x.Estado.ToString())
                .ToArray();

            var data = metasAgrupadas
                .Select(x => x.Cantidad)
                .ToArray();

            // 3. Serializamos a JSON para usarlos en JavaScript
            ViewBag.Labels = JsonConvert.SerializeObject(labels);
            ViewBag.Data = JsonConvert.SerializeObject(data);

            // Retornamos la vista Index.cshtml en /Views/Charts/
            return View();
        }
    }
}



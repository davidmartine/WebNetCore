using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCorep2.Models;
using WebNetCorep2.Servicios;

namespace WebNetCorep2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ServicioProducto;
        public IEnumerable<Producto> Productos{ get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService service)
        {
            _logger = logger;
            ServicioProducto = service;
        }

        public void OnGet()
        {
            Productos = ServicioProducto.GetProducts();
        }
    }
}

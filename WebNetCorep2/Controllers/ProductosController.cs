using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCorep2.Models;
using WebNetCorep2.Servicios;

namespace WebNetCorep2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public JsonFileProductService ProductService { get; }

        public ProductosController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return ProductService.GetProducts();
        }
        [Route("Velocidad")]
        [HttpGet]
        public ActionResult Get([FromQuery]string productoId,
                                [FromQuery]int calificacion)
        {
            ProductService.agregar_calificaciones(productoId, calificacion);
            return Ok();
        }
    }
}

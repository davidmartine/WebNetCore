using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebNetCorep2.Models;

namespace WebNetCorep2.Servicios
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Datos", "Productos.json"); }
        }

        public IEnumerable<Producto> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Producto[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void agregar_calificaciones(string productoId,int calificacion)
        {
            var productos = GetProducts();
            var query = productos.First(x => x.id == productoId);

            if (query.calificaciones == null)
            {
                query.calificaciones = new int[] { calificacion };
                
            }
            else
            {
                var calificaciones = query.calificaciones.ToList();
                calificaciones.Add(calificacion);
                query.calificaciones = calificaciones.ToArray();
            }
            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Producto>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    productos
                );
            }
        }

    }
}

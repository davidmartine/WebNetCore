using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebNetCorep2.Models
{
    public class Producto
    {
        public string id { get; set; }
        public string marca { get; set; }
        [JsonPropertyName("imagen")]
        public string imagen { get; set; }
        public string url { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int[] calificaciones { get; set; }

        public override string ToString()=> JsonSerializer.Serialize<Producto>(this);

    }
}

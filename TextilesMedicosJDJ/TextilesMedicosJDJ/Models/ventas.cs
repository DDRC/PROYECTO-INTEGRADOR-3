using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextilesMedicosJDJ.Models
{
    public class ventas
    {
        public Guid ID { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Total { get; set; }
 
    }
}

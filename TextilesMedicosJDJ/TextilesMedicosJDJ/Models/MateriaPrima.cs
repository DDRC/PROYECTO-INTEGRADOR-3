using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextilesMedicosJDJ.Models
{
    internal class MateriaPrima
    {
        public Guid MateriaId { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedición { get; set; }
        public double  PrecioXunidadMedicion { get; set; }
        [NotMapped]
        [DisplayName("Imagen del producto")]
        public IFormFile  ImagenProducto { get; set; }
        

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextilesMedicosJDJ.Models
{

    public class Produccion
    {
        
        [Key]
        public Guid ProductoId { get; set; }
        [ForeignKey("MateriaPrima")]
        [NotMapped]
        public int MateriaPrimaId { get; set; }
        
        [Required(ErrorMessage = "Se requiere que escoja el tipo de producto")]
        [DisplayName("Tipo de producto")]
        public string TipoProducto { get; set; }
        [DisplayName("Precio Aproximado de venta al publico")]
        public float PrecioAproximado { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de Produccion")]
        public DateTime FechaProducción { get; set; }
        [DisplayName("Cantidad de productos")]
        public int CantidadProduccion { get; set; }
        public void Asignarvalores()
        {
            Console.WriteLine("dfds");
        }
        public void CrearProducto()
        {

        }
    }
}

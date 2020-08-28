using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextilesMedicosJDJ.Models
{
    public class Cliente
    {
        public Guid ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        //Metodos de pago
        public string formaDePago{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tienda.Tables
{
    [Table("Producto")]
    public class Producto
    {
        [PrimaryKey]
        public string IdProducto {get; set;}
        [Unique, NotNull, MaxLength(50)]
        public string Nombre { get; set; }
        [NotNull]
        public double Precio { get; set;}
        [NotNull, MaxLength(20)]
        public string Tipo { get; set;}

        override
        public string ToString()
        {
            return Nombre;
        }

    }

    
}

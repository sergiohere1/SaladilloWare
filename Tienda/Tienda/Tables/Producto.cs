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
        /// <summary>
        /// Clave primeria perteneciente al identificador del producto
        /// </summary>
        [PrimaryKey]
        public string IdProducto {get; set;}
        /// <summary>
        /// Nombre del producto
        /// </summary>
        [Unique, NotNull, MaxLength(50)]
        public string Nombre { get; set; }
        /// <summary>
        /// Precio del producto
        /// </summary>
        [NotNull]
        public double Precio { get; set;}
        /// <summary>
        /// Tipo de producto
        /// </summary>
        [NotNull, MaxLength(20)]
        public string Tipo { get; set;}

        override
        public string ToString()
        {
            return Nombre;
        }
    }

    
}

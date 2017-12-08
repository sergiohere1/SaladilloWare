using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Repositories;
using SQLite;

namespace Tienda.Tables
{
    [Table("Pedido")]
    public class Pedido
    {
        /// <summary>
        /// Código del pedido
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int CodPedido{ get; set; }
        /// <summary>
        /// Id del cliente
        /// </summary>
        [MaxLength(150)]
        public string Cliente { get; set; }
       /// <summary>
       /// Id de la placa base
       /// </summary>
        [MaxLength(150)]
        public string IdPlaca { get; set;}
        /// <summary>
        /// Id del procesador
        /// </summary>
        [MaxLength(150)]
        public string IdProcesador{ get; set; }
        /// <summary>
        /// Id de la torre
        /// </summary>
        [MaxLength(150)]
        public string IdTorre { get; set; }
        /// <summary>
        /// Id de la memoria
        /// </summary>
        [MaxLength(150)]
        public string IdMemoria { get; set; }
        /// <summary>
        /// Id de la tarjeta gráfica
        /// </summary>
        [MaxLength(150)]
        public string IdGrafica { get; set; }
        /// <summary>
        /// Precio
        /// </summary>
        [MaxLength(150)]
        public double Precio { get; set; }
    }

    
}

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
        [PrimaryKey, AutoIncrement]
        public int CodPedido{ get; set; }
        [MaxLength(150)]
        public string Cliente { get; set; }
        [MaxLength(150)]
        public string IdPlaca { get; set;}
        [MaxLength(150)]
        public string IdProcesador{ get; set; }
        [MaxLength(150)]
        public string IdTorre { get; set; }
        [MaxLength(150)]
        public string IdMemoria { get; set; }
        [MaxLength(150)]
        public string IdGrafica { get; set; }
        [MaxLength(150)]
        public double Precio { get; set; }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tienda.Tables
{
    [Table("Pedido")]
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int CodPedido{ get; set; }
        [NotNull]
        public string Cliente { get; set; }
        [NotNull]
        public string IdPlaca { get; set;}
        [NotNull]
        public string IdProcesador{ get; set; }
        [NotNull]
        public string IdTorre { get; set; }
        [NotNull]
        public string IdMemoria { get; set; }
        [NotNull]
        public string IdGrafica { get; set; }
        [NotNull]
        public double Precio { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tienda.Tables
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int IdUser { }
    }
}

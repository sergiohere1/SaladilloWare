using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tienda.Tables
{
    [Table("User")]
    public class User
    {
        [PrimaryKey]
        public string IdUser { get; set;}
        [MaxLength(50) , Unique, NotNull]
        public String Name { get; set;}
        [MaxLength(10), NotNull]
        public string Password { get; set;}
        [NotNull, MaxLength(7)]
        public string Tipo { get; set; }
    }
}

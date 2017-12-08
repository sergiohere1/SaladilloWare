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
        /// <summary>
        /// Id del Usuario
        /// </summary>
        [PrimaryKey]
        public string IdUser { get; set;}
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [MaxLength(50) , Unique, NotNull]
        public String Name { get; set;}
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        [MaxLength(10), NotNull]
        public string Password { get; set;}
        /// <summary>
        /// Tipo de usuario (Vendedor o Cliente)
        /// </summary>
        [NotNull, MaxLength(7)]
        public string Tipo { get; set; }
    }
}

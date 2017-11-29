using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Tables;
using SQLite;

namespace Tienda.Repositories
{
    class ProductoRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ProductoRepository(string dbPath)
        {
            //Inicializamos la conexión SQLite
            conn = new SQLiteAsyncConnection(dbPath);
            //Crear la tabla Usuario
            conn.CreateTableAsync<User>().Wait();
        }

        public async Task<List<Producto>> GetAllUsers()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos= await conn.Table<Producto>().ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Failed to retrieve data");
            }
            return listProductos;
        }
    }
}

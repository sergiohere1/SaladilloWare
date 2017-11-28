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

        public async Task AddNewUser(string id, string nombre, double precio, string tipo)
        {
            int result = 0;

            try
            {
                result = await conn.InsertAsync(new Producto { IdProducto = id, Nombre = nombre, Precio = precio, Tipo = tipo });
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al añadir al usuario {0}. Error: {1}", nombre, ex.Message);
            }
        }

        public async Task<List<Producto>> GetAllUsers()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos= await conn.Table<Producto>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data");
            }
            return listProductos;
        }
    }
}

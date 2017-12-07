using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Tables;
using SQLite;

namespace Tienda.Repositories
{
    public class ProductoRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ProductoRepository(string dbPath)
        {
            //Inicializamos la conexión SQLite
            conn = new SQLiteAsyncConnection(dbPath);
            //Crear la tabla Usuario
            conn.CreateTableAsync<Producto>().Wait();
        }

        public async Task<List<Producto>> GetAllProducts()
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

        public async Task<List<Producto>> ObtenerPlacas()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos = await conn.Table<Producto>().Where(producto => producto.Tipo == "PLACA").ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Error al obtener los datos");
            }
            return listProductos;
        }

        public async Task<List<Producto>> ObtenerProcesadores()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos = await conn.Table<Producto>().Where(producto => producto.Tipo == "PROCESADOR").ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Error al obtener los datos");
            }
            return listProductos;
        }

        public async Task<List<Producto>> ObtenerTorres()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos = await conn.Table<Producto>().Where(producto => producto.Tipo == "TORRE").ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Error al obtener los datos");
            }
            return listProductos;
        }

        public async Task<List<Producto>> ObtenerMemorias()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                listProductos = await conn.Table<Producto>().Where(producto => producto.Tipo == "MEMORIA").ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Error al obtener los datos");
            }
            return listProductos;
        }

        public async Task<List<Producto>> ObtenerGraficas()
        {
            List<Producto> listProductos = new List<Producto>();
            try
            {
                // He tenido que dejar el tipo Gráfica en la tabla sin tilde porque si uso la tilde, hay algún
                // tipo de fallo con la conversión UTF-8 que luego no es capaz de devolverme todas las
                // gráficas.
                listProductos = await conn.Table<Producto>().Where(producto => producto.Tipo == "GRAFICA").ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Error al obtener los datos");
            }
            return listProductos;
        }
    }
}

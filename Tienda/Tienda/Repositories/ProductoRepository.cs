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
        /// <summary>
        /// Método que nos devuelve todos los productos que tengamos en la tabla Producto.
        /// </summary>
        /// <returns>Una lista con todos los productos</returns>
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
        /// <summary>
        /// Método encargado de obtener todas las placas de nuestra tabla Producto mediante un filtrado
        /// por tipo.
        /// </summary>
        /// <returns>Una lista con todas las placas</returns>
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
        /// <summary>
        /// Método encargado de obtener todos los procesadores de la tabla Producto mediante un filtrado
        /// por su tipo
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Método encargado de obtener todas las torres de nuestra tabla Producto mediante un filtrado
        /// por tipo.
        /// </summary>
        /// <returns>Una lista de todas las torres</returns>
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
        /// <summary>
        /// Método encargado de obtener todas las memorias que tengamos en la tabla Producto mediante un
        /// filtro por el tipo
        /// </summary>
        /// <returns>Todas las memorias que tengamos en nuestra tabla Producto</returns>
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

        /// <summary>
        /// Método para obtener todas las gráficas de nuestra tabla de productos mediante un filtro por su tipo.
        /// </summary>
        /// <returns>Una lista con todas las gráficas</returns>
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

        /// <summary>
        /// Método encargado de actualizar los productos, en este caso lo que le pasamos es la id del Producto que queramos
        /// actualizar y su precio nuevo.
        /// </summary>
        /// <param name="idProducto">El producto que queremos actualizar</param>
        /// <param name="precioNuevo">El nuevo precio de dicho producto</param>
        /// <returns></returns>
        public async Task ActualizarProductos(string idProducto, double precioNuevo)
        {           
                await conn.ExecuteAsync("UPDATE Producto SET Precio = ? WHERE IdProducto = ?", precioNuevo, idProducto);           
        }
    }
}

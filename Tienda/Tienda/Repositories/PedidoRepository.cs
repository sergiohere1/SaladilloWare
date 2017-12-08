using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tienda.Tables;


namespace Tienda.Repositories
{
    public class PedidoRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;
        

        public PedidoRepository(string dbPath)
        {
            // Inicializamos la conexión SQLite
            conn = new SQLiteAsyncConnection(dbPath);
            // Crear la tabla Usuario
            conn.CreateTableAsync<Pedido>().Wait();
        }
        
        /// <summary>
        /// Método encargado de crear un nuevo Pedido para insertarlo en la tabla Pedido
        /// </summary>
        /// <param name="idUser">Id del usuario que realiza el pedido</param>
        /// <param name="placa">Id de la placa base</param>
        /// <param name="procesador">Id del procesador</param>
        /// <param name="torre">Id de la torre</param>
        /// <param name="memoria">Id de la Memoria</param>
        /// <param name="grafica">Id de la gráfica</param>
        /// <param name="precio">Precio total</param>
        /// <returns></returns>
        public async Task AddNewOrder(string idUser, string placa, string procesador, string torre, 
            string memoria, string grafica, double precio)
        {
            int result = 0;

            try
            {
                result = await conn.InsertAsync(new Pedido {Cliente = idUser, IdPlaca = placa,
                    IdProcesador = procesador, IdTorre = torre, IdMemoria = memoria, IdGrafica = grafica, Precio = precio});
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al añadir al usuario {0}. Error: {1}", idUser, ex.Message);
            }
        }
        /// <summary>
        /// Método encargado de obtener todos los pedidos realizados.
        /// </summary>
        /// <returns>Devuelve una lista con todos los pedidos realizados</returns>
        public async Task<List<Pedido>> GetAllOrders()
        {
            List<Pedido> listPedidos = new List<Pedido>();

            try
            {
                listPedidos= await conn.Table<Pedido>().ToListAsync();
            }
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Failed to retrieve data");
            }

            return listPedidos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tienda.Tables;


namespace Tienda.Repositories
{
    class PedidoRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;
        private string dbPathRoute;

        public PedidoRepository(string dbPath)
        {
            // Inicializamos la conexión SQLite
            conn = new SQLiteAsyncConnection(dbPath);
            // Crear la tabla Usuario
            conn.CreateTableAsync<Pedido>().Wait();
            dbPathRoute = dbPath;
        }
        

        public async Task AddNewUser(string idUser, string placa, string procesador, string torre, string memoria, string grafica, double precio)
        {
            int result = 0;


            try
            {
                result = await conn.InsertAsync(new Pedido {Cliente = idUser, IdPlaca = placa, IdProcesador = procesador, IdTorre = torre, IdMemoria = memoria, Precio = precio });
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al añadir al usuario {0}. Error: {1}", idUser, ex.Message);
            }
        }

        public async Task<List<Pedido>> GetAllUsers()
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

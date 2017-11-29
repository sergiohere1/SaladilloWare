using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tienda.Tables;

namespace Tienda.Repositories
{
    public class UserRepository
    {
        public string StatusMessage { get; set;}
        private SQLiteAsyncConnection conn;

        public UserRepository(string dbPath)
        {
            //Inicializamos la conexión SQLite
            conn = new SQLiteAsyncConnection(dbPath);
            //Crear la tabla Usuario
            conn.CreateTableAsync<User>().Wait();
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> listUsers = new List<User>();
            try
            {
                listUsers = await conn.Table<User>().ToListAsync();
            #pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            {
                StatusMessage = string.Format("Failed to retrieve data");
            }
            return listUsers;
        }
    }
}

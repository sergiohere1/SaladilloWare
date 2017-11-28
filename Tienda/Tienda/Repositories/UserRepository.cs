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

        public async Task AddNewUser(string id, string name, string password, string tipo)
        {
            int result = 0;

            try
            {
                result = await conn.InsertAsync(new User {IdUser= id, Name = name, Password = password, Tipo = tipo});
            } catch(Exception ex)
            {
                StatusMessage = string.Format("Error al añadir al usuario {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> listUsers = new List<User>();
            try
            {
                listUsers = await conn.Table<User>().ToListAsync();
            }catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data");
            }
            return listUsers;
        }
    }
}

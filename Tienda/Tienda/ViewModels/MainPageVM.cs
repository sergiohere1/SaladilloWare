using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Repositories;
using Tienda.Tables;

namespace Tienda.ViewModels
{

    public class MainPageVM : INotifyPropertyChanged
    {
        #region Campos
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string username;
        /// <summary>
        /// Contraseña
        /// </summary>
        public string password;
        /// <summary>
        /// Mensaje de error dependiendo del error que se le de al usuario.
        /// </summary>
        public string errorMessage;
        /// <summary>
        /// Campo que se implementa al implementar la interfaz INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username != value)
                {
                    username = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Username"));
                    }
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (username != value)
                {
                    password = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                    }
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método encargado de validar el Login del usuario, y, en función a si es un vendedor o
        /// un cliente, cargarle una página u otra.
        /// </summary>
        /// <param name="page">Página actual que se pasa para el lanzamiento de alertas para
        /// los errores</param>
        public async void MakeLogin(MainPage page)
        {

            if (ValidarDatosInsertados()){ 
                User userSearch;

                ObservableCollection<User> usuarios = new ObservableCollection<User>(await App.UsuarioRepo.GetAllUsers());

                userSearch = usuarios.SingleOrDefault(t => t.Name == Username && t.Password == Password);

                if (userSearch != null)
                {
                    // Dependiendo de si el usuario es Administrador o Cliente, cargamos una página u otra.
                    switch (userSearch.Tipo)
                    {
                        case "VENDOR":
                            App.Current.MainPage = new AdminPage();
                            break;
                        case "CLIENTE":
                            App.Current.MainPage = new ClientPage(userSearch);
                            break;
                    }
                }
                else
                {
                    errorMessage = "Error, los datos introducidos no se encuentran en la Base de Datos";
                    await page.DisplayAlert("Error", errorMessage, "Aceptar");
                }
            }
            else
            {
                await page.DisplayAlert("Error", errorMessage, "Aceptar");
            }
            
        }

        /// <summary>
        /// Método encargado de validar los campos de Usuario y Contraseña por si hay valores vacíos o
        /// nulos
        /// </summary>
        /// <returns></returns>
        public bool ValidarDatosInsertados()
        {
            bool datosValidos = true;

            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                errorMessage = "Error, el campo de nombre/usuario se encuentra vacío";
                datosValidos = false;
            }

            return datosValidos;
        }

        #endregion
    }
}

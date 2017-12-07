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
        public string username;
        public string password;
        public string errorMessage;

        public event PropertyChangedEventHandler PropertyChanged;

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
       
        public async void makeLogin(MainPage page)
        {

            if (validarDatosInsertados()){ 
                User userSearch;

                ObservableCollection<User> usuarios = new ObservableCollection<User>(await App.UsuarioRepo.GetAllUsers());

                userSearch = usuarios.SingleOrDefault(t => t.Name == Username && t.Password == Password);

                if (userSearch != null)
                {
                    // Dependiendo de si el usuario es Administrador o Cliente, cargamos una página u otra.
                    switch (userSearch.Tipo)
                    {
                        case "VENDOR":
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

        public bool validarDatosInsertados()
        {
            bool datosValidos = true;

            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                errorMessage = "Error, el campo de nombre/usuario se encuentra vacío";
                datosValidos = false;
            }

            return datosValidos;
        }
    }
}

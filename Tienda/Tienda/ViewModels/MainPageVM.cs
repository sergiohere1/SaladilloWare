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
       
        public async Task<bool> ShowUsername()
        {
            bool resultado = false;

            ObservableCollection<User> usuarios = new ObservableCollection<User>(await App.UsuarioRepo.GetAllUsers());

           if(username == "Sergio")
            {
                resultado = true;
            }

            return resultado;
        }
    }
}

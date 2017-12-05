using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.ViewModels;
using Xamarin.Forms;

namespace Tienda
{
    
    public partial class MainPage : ContentPage
    {
        protected MainPageVM mainviewmodel = new MainPageVM();

        public MainPage()
        {
            InitializeComponent();
            // Bindeamos el Viewmodel para que le asignemos los valores que introduzcamos de usuario y
            // contraseña.
            BindingContext = mainviewmodel;

            loginButton.Clicked += async (sender, args) =>
            {
                bool resultado;
                resultado = await mainviewmodel.ShowUsername();

                if (!resultado)
                {
                    ShowError("Error al iniciar sésión", "Compruebe que haya introducido bien" +
                        " su nombre de usuario y contraseña y que no ha dejado ningún campo vacío.");
                }
                else
                {
                    App.Current.MainPage = new ClientPage();
                }

            };
        }

        // Método encargado de mostrar cualquier error mediante un Dialog.
        public void ShowError(string message1, string message2)
        {
            DisplayAlert(message1, message2, "Aceptar");
        }

        
    }
}

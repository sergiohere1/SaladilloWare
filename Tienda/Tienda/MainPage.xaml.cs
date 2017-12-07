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
                mainviewmodel.makeLogin(this);
            };
        }               
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.Repositories;
using Xamarin.Forms;

namespace Tienda
{
    public partial class App : Application
    {
        public static UserRepository UsuarioRepo { get; set; }
        public static ProductoRepository ProductoRepo { get; set; }
        public static PedidoRepository PedidoRepo { get; set; }

        public App(string filename)
        {
            InitializeComponent();
            UsuarioRepo = new UserRepository(filename);
            ProductoRepo = new ProductoRepository(filename);
            PedidoRepo = new PedidoRepository(filename);
            MainPage = new Tienda.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

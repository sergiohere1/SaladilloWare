using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tienda
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPage : ContentPage
	{
        public AdminVM adminViewModel = new AdminVM();

		public AdminPage ()
		{
			InitializeComponent ();
            BindingContext = adminViewModel;
            adminViewModel.LoadContent();

            btnAdminDisconnect.Clicked += CerrarSesion;
            btnLoadXML.Clicked += ActualizarPrecios;
		}
        /// <summary>
        /// Método que hace que se desconecte el usuario para iniciar sesión con otro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CerrarSesion(object sender, EventArgs e)
        {
            adminViewModel.CerrarSesion();
        }

        /// <summary>
        /// Método encargado de actualizar el precio de cada producto según el XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualizarPrecios(object sender, EventArgs e)
        {
            adminViewModel.ActualizarPrecios();
        }
    }
}
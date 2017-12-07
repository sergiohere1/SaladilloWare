using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Tables;
using Tienda.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tienda
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientPage : ContentPage
	{
        private ClientVM clienteVM;
        public ClientPage (User user)
		{
			InitializeComponent ();
            clienteVM = new ClientVM(user);
            BindingContext = clienteVM;
            
            // Controlamos cada vez que el usuario elija un producto si ya ha seleccionado todos para
            // habilitar el botón de Aceptar.
            placaselect.SelectedIndexChanged += ComprobarSelect;
            procesadorselect.SelectedIndexChanged += ComprobarSelect;
            torreselect.SelectedIndexChanged += ComprobarSelect;
            memoriaselect.SelectedIndexChanged += ComprobarSelect;
            graficaselect.SelectedIndexChanged += ComprobarSelect;

            btnAceptar.Clicked += AniadirProductosPedido;
            btnConfirm.Clicked += RealizarPedido;
            btnDisconnect.Clicked += CerrarSesion;
        }

        /// <summary>
        /// Este método se encargará de comprobar si una vez el usuario ha elegido en el picker
        /// un producto
        /// </summary>
        /// <param name="sender">Objecto que hace que se de lugar a este evento (En este caso,
        /// que el índice del picker cambie)</param>
        /// <param name="e">Argumentos del evento</param>
        private void ComprobarSelect(object sender, EventArgs e)
        {
            clienteVM.ComprobarSelect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AniadirProductosPedido(object sender, EventArgs e)
        {
            clienteVM.AniadirProductosPedido();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RealizarPedido(object sender, EventArgs e)
        {
            clienteVM.RealizarPedido(this);
        }

        private void CerrarSesion(object sender, EventArgs e)
        {
            clienteVM.CerrarSesion();
        }

        
	}
}
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
            
		}
	}
}
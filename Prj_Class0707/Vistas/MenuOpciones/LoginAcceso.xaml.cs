using Prj_Class0707.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prj_Class0707.Vistas.MenuOpciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginAcceso : ContentPage
	{
		public LoginAcceso ()
		{
			InitializeComponent ();
			BindingContext = new MVLogin(Navigation);
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			Navigation.PushAsync(new RegistrarUsuario());
        }
    }
}
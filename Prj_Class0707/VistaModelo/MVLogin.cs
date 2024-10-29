using Firebase.Auth;
using Prj_Class0707.Conexion;
using Prj_Class0707.Modelo;
using Prj_Class0707.Vistas.MenuOpciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prj_Class0707.VistaModelo
{
    public class MVLogin:BaseModelo
    {
        #region Atributos
        private string email;
        private string clave;
        #endregion

        #region Propiedades
        public string txtemail
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string txtclave
        {
            get { return clave; }
            set { SetValue(ref clave, value); }
        }
        #endregion

        #region Command
        public ICommand LogearUsuarioCommand { get; }
        #endregion

        #region Metodo
        public async Task LoginUsuario()
        {
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Alerta", "Escriba su email", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(clave))
            {
                await DisplayAlert("Alerta", "Escriba su contraseña", "Ok");
                return;
            }


            var objusuario = new MUsuarios()
            {
                Email = email.Trim(),
                Clave = clave
            };
            try
            {

                var autenticacion = new FirebaseAuthProvider(new FirebaseConfig(FirebaseDBConexion.WepApyAuthentication));
                var authuser = await autenticacion.SignInWithEmailAndPasswordAsync(objusuario.Email.ToString(), objusuario.Clave.ToString());
                string obternertoken = authuser.FirebaseToken;

                var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal(objusuario.Email.ToString()));
                //var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal());
                //var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal());

                Propiedades_NavigationPage.BarBackgroundColor = Color.RoyalBlue;
                App.Current.MainPage = Propiedades_NavigationPage;
                //Correrbarra = false;
                //IsVisible = false;
            }
            catch (Exception)
            {
                //Correrbarra = false;
                //IsVisible = false;
                await App.Current.MainPage.DisplayAlert("Advertencia", "Las credenciales introducidas son incorrectos o el usuario se encuentra inactivo.", "Aceptar");
            }
        }
        #endregion

        #region Constructor
        public MVLogin(INavigation navegar)
        {
            Navigation = navegar;
            LogearUsuarioCommand = new Xamarin.Forms.Command(async () => await LoginUsuario());
        }
        #endregion

    }
}

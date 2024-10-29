using Prj_Class0707.Vistas.Maestras;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prj_Class0707.VistaModelo
{
    public class MVMenuMantenimiento : BaseModelo
    {
        #region VARIABLES

        #endregion

        #region CONSTRUCTOR
        public MVMenuMantenimiento(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS

        #endregion

        #region PROCESOS
        private async void NavegarMaestraClientes()
        {
            await Navigation.PushAsync(new Clientes());
        }

        //private async void NavegarLibros()
        //{
        //    //await Navigation.PushAsync(new MaestraLibros(null));
        //    await Navigation.PushAsync(new AgregarLibros());
        //}

        //private async void NavegarClientes()
        //{
        //    await Navigation.PushAsync(new AgregarCliente());
        //}

        #endregion

        #region COMANDOS
        //public ICommand NavegarMaestraProveedorescommad => new Command(NavegarMaestraProveedores);
        //public ICommand NavegarLibroscommad => new Command(NavegarLibros);
        public ICommand NavegarClientescommad => new Command(NavegarMaestraClientes);
        #endregion


    }
}

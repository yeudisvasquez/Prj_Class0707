using Prj_Class0707.Vistas.MenuOpciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prj_Class0707.VistaModelo
{
    public class MVEmpezar:BaseModelo
    {
         
        #region VARIABLES

        #endregion

        #region CONSTRUCTOR
        public MVEmpezar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS

        #endregion

        #region PROCESOS
        private async void NavegarLogin()
        {
            await Navigation.PushAsync(new LoginAcceso());
        }
        #endregion

        #region COMANDOS
        public ICommand NavegarLogincommad => new Command(NavegarLogin);
        #endregion

    }
}


using Prj_Class0707.Vistas;
using Prj_Class0707.Vistas.MenuOpciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prj_Class0707.VistaModelo
{
    public class MVMenuPrincipal : BaseModelo
    {

        #region VARIABLES
        #endregion

        #region CONSTRUCTOR
        public MVMenuPrincipal(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomand = new Command(async () => await Volver());
            MantenimientoCommand = new Command(async () => await NavegarMenuMantenimiento());
            ReportesCommand = new Command(async () => await NavegarMenureportes());
            DesarrolladorCommand = new Command(async () => await NavegarDesarrollador());
        }
        public MVMenuPrincipal(INavigation navigation, string usu)
        {
            Navigation = navigation;
            Volvercomand = new Command(async () => await Volver());
            MantenimientoCommand = new Command(async () => await NavegarMenuMantenimiento());
            ReportesCommand = new Command(async () => await NavegarMenureportes());
            DesarrolladorCommand = new Command(async () => await NavegarDesarrollador());
        }
        #endregion

        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PushAsync(new MenuPrincipal());
            //await Navigation.PopAsync();
        }
        private async Task NavegarMenuMantenimiento()
        {
            await Navigation.PushAsync(new MenuMantenimiento());
            //await Navigation.PushAsync(new MenuMantenimiento());
        }
        private async Task NavegarMenureportes()
        {
            //await Navigation.PushAsync(new Clientes());
            await Navigation.PushAsync(new MenuReportes());
        }
        private async Task NavegarDesarrollador()
        {
            //await Navigation.PushAsync(new Desarrollador());
            await Navigation.PushAsync(new Desarrollador());
        }
        #endregion

        #region COMMANDS
        public Command Volvercomand { get; }
        public ICommand MantenimientoCommand { get; }
        public ICommand DesarrolladorCommand { get; }
        public ICommand ReportesCommand { get; }

    //public ICommand DesarrolladorCommand => new Command (desarrolladorNavegar);
    #endregion
}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prj_Class0707.VistaModelo
{
    public class MVDesarrollador : BaseModelo
    {
        #region CONSTRUCTOR

        public MVDesarrollador()
        {
        }
        public MVDesarrollador(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomand = new Command(async () => await Volver());
            //NavegarEspecialidadescommand = new Command(async () => await NavegarEspecialidades());
            //NavegarMedicoscommand = new Command(async () => await NavegarMedicos());
        }

        public MVDesarrollador(INavigation navigation, string usu)
        {
            Navigation = navigation;
            Volvercomand = new Command(async () => await Volver());
            //NavegarEspecialidadescommand = new Command(async () => await NavegarEspecialidades());
            //NavegarMedicoscommand = new Command(async () => await NavegarMedicos());
        }

        #endregion

        #region PROCESOS

        private async Task Volver()
        {
            await Navigation.PopAsync();
        }

        private async Task NavegarEspecialidades()
        {
            //await Navigation.PushAsync(new ListaEspecialidades());
        }

        private async Task NavegarMedicos()
        {
            //await Navigation.PushAsync(new ListaMedicos());
        }

        #endregion

        #region COMANDOS

        public Command Volvercomand { get; }
        public Command NavegarEspecialidadescommand { get; }
        public Command NavegarMedicoscommand { get; }

        #endregion

    }
}

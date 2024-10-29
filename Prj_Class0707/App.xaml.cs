using Prj_Class0707.Vistas;
using Prj_Class0707.Vistas.Maestras;
using Prj_Class0707.Vistas.MenuOpciones;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prj_Class0707
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Empezar());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

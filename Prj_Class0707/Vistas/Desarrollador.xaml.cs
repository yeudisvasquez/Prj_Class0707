using Prj_Class0707.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prj_Class0707.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Desarrollador : ContentPage
    {
        public Desarrollador()
        {
            InitializeComponent();
            BindingContext = new MVDesarrollador(Navigation);
        }
    }
}
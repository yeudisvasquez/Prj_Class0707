using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prj_Class0707.Vistas.Maestras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarModificar_DoctoresPage : ContentPage
    {
        public AgregarModificar_DoctoresPage()
        {
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListViewEspecialidades_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
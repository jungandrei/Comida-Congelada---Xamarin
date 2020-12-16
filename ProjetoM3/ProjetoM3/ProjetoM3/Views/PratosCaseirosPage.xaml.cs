using ProjetoM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoM3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PratosCaseirosPage : ContentPage
    {

        private readonly PratosViewModel Contexto;
        public PratosCaseirosPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            BindingContext = Contexto = PratosViewModel.CreatePratosViewModel();

            Contexto.ListarPratosPorTipo("caseiro");

        }

        private void Button_Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sacola());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // TODO: implementar
        }
    }
}
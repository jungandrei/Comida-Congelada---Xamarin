using ProjetoM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoM3.Views.Pratos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPratosPage : ContentPage
    {
        private readonly PratosViewModel Contexto;
        public ListaPratosPage()
        {

            InitializeComponent();

            BindingContext = Contexto = PratosViewModel.CreatePratosViewModel();

            Contexto.ListarPratos();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Model.Pratos selecionado)
            {
                Contexto.Item = Contexto.Clonar(selecionado);

                await Navigation.PushAsync(new DetalhePratoPage(Contexto)).ConfigureAwait(true);

                ((ListView)sender).SelectedItem = null;
            }
        }

        private async void ToolBarItemNovo_Clicked(object sender, EventArgs e)
        {
            Contexto.Item = new Model.Pratos();

            await Navigation.PushAsync(new DetalhePratoPage(Contexto)).ConfigureAwait(true);
        }

        private void SearchBar_Pesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBar_Pesquisa.Text))
            {
                Contexto.PesquisarCommand.Execute(string.Empty);
            }
        }

        private void ToolbarItemPesquisa_Clicked(object sender, EventArgs e)
        {
            FramePesquisa.IsVisible = !FramePesquisa.IsVisible;
        }
    }
}
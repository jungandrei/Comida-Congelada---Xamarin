using ProjetoM3.Views.Pratos;
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
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            if (App.usuario.Email == "jung.andrei@gmail.com")
            {
                // Habilitar o menu de cadastro aqui
                NovosPratosButton.IsEnabled = true;
            }
            else
            {
                NovosPratosButton.IsEnabled = false;
            }
        }

        private void TapGestureRecognizer_Pratos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PratosPage());
        }

        private void TapGestureRecognizer_PratosCaseiros(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PratosCaseirosPage());
        }

        private void TapGestureRecognizer_PorcoesPrincipais(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PorcoesPrincipaisPage());
        }

        private void TapGestureRecognizer_Acompanhamentos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AcompanhamentosPage());
        }

        private void TapGestureRecognizer_Lanches(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LanchesPage());
        }

        private void TapGestureRecognizer_Bebidas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BebidasPage());
        }

        private void TapGestureRecognizer_PapinhasOrganicas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PapinhasOrganicasPage());
        }

        private void TapGestureRecognizer_PratosCombinados(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PratosCombinadosPage());
        }

        private void TapGestureRecognizer_ItensIndividuais(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItensIndividuaisPage());
        }

        private void TapGestureRecognizer_PaesLanchesSucos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaesLanchesSucosPage());
        }

        private void ButtonNovosPratos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaPratosPage());
        }
    }
}
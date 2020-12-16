using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoM3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoM3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void ButtonCadastrar_PagPrincipal(object sender, EventArgs e)
        {
            // aqui, adicionamos o usuario, vamos fazer sem validacoes para ser rapido

            if (await UsuarioViewModel.CreateUsuarioViewModel().NovoUsuario(EntryEmail.Text, EntryLogin.Text,
                EntrySenha.Text, ckPessoaFisica.IsChecked, ckPessoaJuridica.IsChecked).ConfiguraAwait(true))
            {
                App.Current.MainPage = new PrincipalPage();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProjetoM3.Model;
using ProjetoM3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoM3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new CadastroPage());

            // TODO: Teste para ver se funciona o codigo

            // TODO: nao esquecer de colocar tolower() no final do login, para nao ter problemas de login
            await UsuarioViewModel.CreateUsuarioViewModel().Adicionar(new Usuario() {Login = "lalala"}).ConfigureAwait(true);

        }

        private async void ButtonLogin_PagPrincipal(object sender, EventArgs e)
        {
            //É que aqui ele abre a pagina princiapl
            //sim, mas nao faz login antes de abrir?Ah vdd
            if (await UsuarioViewModel.CreateUsuarioViewModel().Login(EntryUsuario.Text, EntrySenha.Text).ConfigureAwait(true))
            {
                App.Current.MainPage = new PrincipalPage();
            }

        }
    }
}
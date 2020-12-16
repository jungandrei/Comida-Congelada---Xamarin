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
            await Navigation.PushAsync(new CadastroPage()).ConfigureAwait(true);
        }

        private async void ButtonLogin_PagPrincipal(object sender, EventArgs e)
        {
            if (await UsuarioViewModel.CreateUsuarioViewModel().Login(EntryUsuario.Text, EntrySenha.Text).ConfigureAwait(true))
            {
                App.Current.MainPage = new NavigationPage(new PrincipalPage());
            }
        }
    }
}
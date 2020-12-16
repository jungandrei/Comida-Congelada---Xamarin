using System;
using ProjetoM3.Model;
using ProjetoM3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoM3
{
    public partial class App : Application
    {
        public static Usuario usuario { get; set; }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY0MTM1QDMxMzgyZTMzMmUzMFBPZ09nZm1MeG92Q3d6TEVybW9wcS9Fcm05Y2hzYmRaV2svSkF1VlAydk09");
            InitializeComponent();
            Construir();

            MainPage = new NavigationPage(new LoginPage());
        }

        private static void Construir()
        {
            try
            {
                // 1. Inicializa as variaveis estáticas que configuram o banco de dados do Firebase e do Firestore, se esta configuracao nao ocorrer a aplicacao nao conecta no banco dedados
                // 1.1. É preciso lembrar que é preciso configurar corretamente no Firebase e nas propriedades do Projeto do Android
                Unipon.Engine.Service.FireBaseHelper.FirebaseUrl = "https://projetom3app-default-rtdb.firebaseio.com/";
                Unipon.Engine.Service.FireBaseHelper.FirebaseApiKey = "AIzaSyCEeKBZtLFlUlzkYhFKY_Kvu-az0DxquAc";
                Unipon.Engine.Service.FireBaseHelper.FirebaseSignInEmail = "jung.andrei@gmail.com";
                Unipon.Engine.Service.FireBaseHelper.FirebaseSignInPassword = "g3t5a2ka";
                Unipon.Engine.Service.FireStoreHelper.FireStoreUrl = "projetom3app.appspot.com";

#if DEBUG
                Unipon.Engine.Service.CatalogarErroHelper.ExibirMensagemErro = true;
#endif
#if RELEASE
                Unipon.Engine.Service.CatalogarErroHelper.ExibirMensagemErro = false;
#endif
                // 2. Faz uma requisicao para gerar a primeira autenticacao na carga do aplicativo, este metodo garante que seja gerada a autenticacao inicial
                new Command(async () => {
                    await Unipon.Engine.Service.FireBaseHelper.GetAuth().ConfigureAwait(true);
                }).Execute(null);
            }
            catch (Exception ex)
            {
                // 3. Caso ocorra algo de errado, eh regado uma mensagem de erro dentro do firebase
                Unipon.Engine.Service.CatalogarErroHelper.Registrar(ex);
            }
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

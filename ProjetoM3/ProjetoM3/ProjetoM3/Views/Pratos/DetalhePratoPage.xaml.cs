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
    public partial class DetalhePratoPage : ContentPage
    {
        private readonly PratosViewModel Contexto;
        public DetalhePratoPage(PratosViewModel contexto)
        {
            InitializeComponent();

            if (contexto == null)
                contexto = PratosViewModel.CreatePratosViewModel();

            BindingContext = Contexto = contexto;

            if ((Contexto == null) || (Contexto.Item == null) || (string.IsNullOrEmpty(Contexto.Item.Chave)))
            {
                ToolbarItemRemover.IsEnabled = false;
                TitleViewLabel.Text = this.Resources["DetalhePratoPage_Titulo_Novo"].ToString();
            }
            else
            {
                TitleViewLabel.Text = this.Resources["DetalhePratoPage_Titulo_Editar"].ToString();
            }
        }

        private async void ToolbarItemRemover_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert(
                    this.Resources["DetalhePratoPage_DisplayAlert_Remover_Atencao"].ToString(),
                    this.Resources["DetalhePratoPage_DisplayAlert_Remover_Deseja_Remover"].ToString() + Contexto.Item.Nome +
                    this.Resources["DetalhePratoPage_DisplayAlert_Remover_Interrogacao"].ToString(),
                    this.Resources["DetalhePratoPage_DisplayAlert_Remover_Sim"].ToString(),
                    this.Resources["DetalhePratoPage_DisplayAlert_Remover_Nao"].ToString()).ConfigureAwait(true);

            if (resposta == true)
            {
                Contexto.RemoverCommand.Execute(Contexto.Item);
                await Navigation.PopAsync().ConfigureAwait(true);
            }
        }

        private async void ToolbarItemSalvar_Clicked(object sender, EventArgs e)
        {
            if (await ValidarDados(Contexto.Item).ConfigureAwait(true))
            {
                Contexto.SalvarCommand.Execute(Contexto.Item);
                await Navigation.PopAsync().ConfigureAwait(true);
            }
        }

        private async Task<bool> ValidarDados(Model.Pratos prato)
        {
            try
            {
                Model.Pratos existe = await Contexto
                                          .Obter(x => x.Object.Nome.ToLower() == prato.Nome.ToLower() &&
                                                      x.Object.Chave != prato.Chave)
                                          .ConfigureAwait(true);
                if ((existe != null) && (!string.IsNullOrEmpty(existe.Chave)))
                {
                    await DisplayAlert(
                        this.Resources["DetalhePratoPage_DisplayAlert_Nome_Existe_Titulo"].ToString(),
                        this.Resources["DetalhePratoPage_DisplayAlert_Nome_Existe_Mensagem"].ToString(),
                        this.Resources["DetalhePratoPage_DisplayAlert_Nome_Existe_OK"].ToString()).ConfigureAwait(true);
                    return false;
                }
                else
                if (string.IsNullOrEmpty(prato.Nome) || prato.Nome.Length < 3)
                {
                    await DisplayAlert(
                        this.Resources["DetalhePratoPage_DisplayAlert_Nome_Invalido_Titulo"].ToString(),
                        this.Resources["DetalhePratoPage_DisplayAlert_Nome_Invalido_Mensagem"].ToString(),
                        this.Resources["DetalhePratoPage_DisplayAlert_Nome_Invalido_OK"].ToString()).ConfigureAwait(true);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
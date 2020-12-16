using Xamarin.Forms.Xaml;
using Unipon.Engine.Views.Helpers;

namespace ProjetoM3.Views.Pratos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class I18n : TraducaoRecurso, ITraducao
    {
        //Internationalization
        public I18n()
        {
            InitializeComponent();
            this.Executar<I18n>("pt");
        }

        //ordenar recursos no excel e colocar os mesmos nos idiomas
        public void pt()
        {
            this.Add("ButtonSalvar_Text", "Salvar");
            this.Add("ButtonCancelar_Text", "Cancelar");

            this.Add("ListaPratosPage_Titulo", "Pratos disponíveis");
            this.Add("ListaPratosPage_SearchBar_Placeholder", "Ex.: macarronada, feijoada, ...");
            this.Add("ListaPratosPage_ListView_Text", "No momento, não existem pratos cadastrados.");

            this.Add("DetalhePratoPage_Titulo_Novo", "Novo prato");
            this.Add("DetalhePratoPage_Titulo_Editar", "Editando prato");

            this.Add("DetalhePratoPage_DisplayAlert_Remover_Atencao", "Atenção");
            this.Add("DetalhePratoPage_DisplayAlert_Remover_Deseja_Remover", "Deseja remover ");
            this.Add("DetalhePratoPage_DisplayAlert_Remover_Interrogacao", "?");
            this.Add("DetalhePratoPage_DisplayAlert_Remover_Sim", "Sim");
            this.Add("DetalhePratoPage_DisplayAlert_Remover_Nao", "Não");

            this.Add("DetalhePratoPage_DisplayAlert_Nome_Existe_Titulo", "Ops...");
            this.Add("DetalhePratoPage_DisplayAlert_Nome_Existe_Mensagem", "Nome de prato já existe");
            this.Add("DetalhePratoPage_DisplayAlert_Nome_Existe_OK", "Ok");

            this.Add("DetalhePratoPage_DisplayAlert_Nome_Invalido_Titulo", "Ops...");
            this.Add("DetalhePratoPage_DisplayAlert_Nome_Invalido_Mensagem", "O nome do prato precisa ter pelo menos 3 letras");
            this.Add("DetalhePratoPage_DisplayAlert_Nome_Invalido_OK", "OK");

            this.Add("DetalhePratoPage_LabelNome_Text", "NOME DO PRATO");
            this.Add("DetalhePratoPage_EntryNome_Placeholder", "Ex: macarronada, feijoada, ...");

            this.Add("DetalhePratoPage_LabelTipoPrato_Text", "TIPO DE PRATO");
            this.Add("DetalhePratoPage_LabelTipoPrato_Placeholder", "Ex: caseiro, porcoes, ...");

        }

        public void en()
        {

        }

        public void es()
        {

        }
    }
}
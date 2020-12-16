using System;
using System.Threading.Tasks;
using ProjetoM3.Model;
using Unipon.Engine.ViewModel;

namespace ProjetoM3.ViewModel
{
    public class UsuarioViewModel : GenericoViewModel<Usuario>
    {
        public static UsuarioViewModel CreateUsuarioViewModel()
        {

            string ParentChild = $"app.dev"; // aqui eh o path dentro do firebase
            string NomeNodoFirebase = "usuario"; //aqui eh o nome da tabela no firebase
            string NomeArquivoFirebase = "usuario"; //aqui eh o nome da tabela dentro do app 

            // ModoObservacao.Nenhum        Nao faz sincronismo automatico
            // ModoObservacao.RemotoELocal  sincroniza a base local do app e o firebase
            // ModoObservacao.SomenteLocal  grava os dados apenas no celular, sem enviar para o firebase
            // ModoObservacao.SomenteRemoto grava os dados apenas no firebase

            return new UsuarioViewModel(NomeNodoFirebase, ModoObservacao.Nenhum, NomeArquivoFirebase, ParentChild);
        }
        
        public async Task<bool> NovoUsuario(string email, string login, string senha, bool ehPF, bool ehPJ)
        {
            // verifica se ja nao existe outro
            Usuario existente = await Obter(x => x.Object.Email == email.ToLower() && x.Object.Senha == senha).ConfigureAwait(true);

            if (existente == null)
            {
                Usuario novo = new Usuario();
                novo.Login = login;
                novo.Senha = senha;
                novo.Email = email;
                // novo.EhPF 

                // TODO: Colocar os teus campos aqui (PessoaFisica e juridica)

                if (await Adicionar(novo).ConfigureAwait(true))
                {
                    // se conseguiu adicionar o novo usuario, entao, pode entrar no app
                    App.usuario = novo;
                    return true;
                }

                return true;
            }
            return false;
        }

        public UsuarioViewModel(string NomeNodoFirebase, ModoObservacao modoObservacao, string NomeArquivoFirebase, string ParentChild = null) : base(NomeNodoFirebase, modoObservacao, NomeArquivoFirebase, ParentChild)
        {

        }

        public async Task<bool> Login(string email, string senha)
        {
            Usuario logando = await Obter(x => x.Object.Email == email.ToLower() && x.Object.Senha == senha).ConfigureAwait(true);

            if (logando != null) 
                if (string.IsNullOrEmpty(logando.Chave) == false)
                {
                    App.usuario = logando;
                    return true;
                }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjetoM3.Model;
using Unipon.Engine.ViewModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetoM3.ViewModel
{
    public class PratosViewModel : GenericoViewModel<Pratos>
    {
        public static PratosViewModel CreatePratosViewModel()
        {

            string ParentChild = $"app.dev"; 
            string NomeNodoFirebase = "prato"; 
            string NomeArquivoFirebase = "prato"; 

            return new PratosViewModel(NomeNodoFirebase, ModoObservacao.Nenhum, NomeArquivoFirebase, ParentChild);
        }

        public PratosViewModel(string NomeNodoFirebase, ModoObservacao modoObservacao, string NomeArquivoFirebase, string ParentChild = null) : base(NomeNodoFirebase, modoObservacao, NomeArquivoFirebase, ParentChild)
        {

        }

        public async void ListarPratos()
        {
            var listaTemporaria = await Listar(x => x.Key != null).ConfigureAwait(true);

            // limpo a lista (sem dar null)
            Items.Clear();

            // e, se existir algum registro, faco ADD
            if (listaTemporaria != null)
                foreach (Pratos prato in listaTemporaria)
                {
                    Items.Add(prato);
                }
            // atualiza a lista elementos agrupados
            AgruparLista();
        }

        private void AgruparLista()
        {
            if (ItemsAgrupados == null)
                ItemsAgrupados = new List<ObservableGroupCollection<string, Pratos>>();
            ItemsAgrupados.Clear();
            if (Items.Any())
                ItemsAgrupados = Items.Where(p => p.Chave != null)
                                      .OrderBy(p => p.TipoPrato)
                                      .GroupBy(p => p.TipoPrato)
                                      .Select(p => new ObservableGroupCollection<string, Pratos>(p)).ToList();
            this.Changed(() => ItemsAgrupados);
            this.Changed(() => ExisteItemsAgrupados);
        }

        public ICommand PesquisarCommand => new Command<string>(async (string pesquisa) =>
        {
            IEnumerable<Pratos> listaPesquisa;
            Items.Clear();
            // se nao houver pesquisa, eu listo tudo
            if (string.IsNullOrEmpty(pesquisa))
            {
                listaPesquisa = await Listar(x => x.Key != null).ConfigureAwait(true);
            }
            else
            {
                // faco o filtro nos itens da minha lista, observando o "contem"
                listaPesquisa = await Listar(x => x.Key != null && x.Object.Nome.ToLower().Contains(pesquisa.ToLower())).ConfigureAwait(true);
            }

            // lista de itens encontrados
            if (listaPesquisa != null)
                foreach (Pratos prato in listaPesquisa)
                    Items.Add(prato);

            // atualizo o agrupamento da lista
            AgruparLista();
        });

    }
}

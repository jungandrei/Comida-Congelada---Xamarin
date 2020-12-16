using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjetoM3.Model;
using Unipon.Engine.ViewModel;

namespace ProjetoM3.ViewModel
{
    public class SacolaViewModel : GenericoViewModel<Sacola>
    {
        public static SacolaViewModel CreateSacolaViewModel()
        {

            string ParentChild = $"app.dev.usuario.{App.usuario}";
            string NomeNodoFirebase = "sacola";
            string NomeArquivoFirebase = "sacola";

            return new SacolaViewModel(NomeNodoFirebase, ModoObservacao.Nenhum, NomeArquivoFirebase, ParentChild);
        }

        public SacolaViewModel(string NomeNodoFirebase, ModoObservacao modoObservacao, string NomeArquivoFirebase, string ParentChild = null) : base(NomeNodoFirebase, modoObservacao, NomeArquivoFirebase, ParentChild)
        {

        }
    }
}

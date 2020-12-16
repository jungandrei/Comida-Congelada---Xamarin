using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjetoM3.Model;
using Unipon.Engine.ViewModel;

namespace ProjetoM3.ViewModel
{
    public class SacolaPratosViewModel : GenericoViewModel<SacolaPratos>
    {
        public static SacolaPratosViewModel CreateSacolaPratosViewModel(string chaveSacola)
        {

            string ParentChild = $"app.dev.usuario.{App.usuario}.sacola.{chaveSacola}";
            string NomeNodoFirebase = "pratos";
            string NomeArquivoFirebase = "pratos";

            return new SacolaPratosViewModel(NomeNodoFirebase, ModoObservacao.RemotoELocal, NomeArquivoFirebase, ParentChild);
        }

        public SacolaPratosViewModel(string NomeNodoFirebase, ModoObservacao modoObservacao, string NomeArquivoFirebase, string ParentChild = null) : base(NomeNodoFirebase, modoObservacao, NomeArquivoFirebase, ParentChild)
        {

        }
    }
}

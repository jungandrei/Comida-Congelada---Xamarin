using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjetoM3.Model;
using Unipon.Engine.ViewModel;

namespace ProjetoM3.ViewModel
{
    public class PratosViewModel : GenericoViewModel<Usuario>
    {
        public static PratosViewModel CreatePratosViewModel()
        {

            string ParentChild = $"app.dev"; 
            string NomeNodoFirebase = "prato"; 
            string NomeArquivoFirebase = "prato"; 

            return new PratosViewModel(NomeNodoFirebase, ModoObservacao.RemotoELocal, NomeArquivoFirebase, ParentChild);
        }

        public PratosViewModel(string NomeNodoFirebase, ModoObservacao modoObservacao, string NomeArquivoFirebase, string ParentChild = null) : base(NomeNodoFirebase, modoObservacao, NomeArquivoFirebase, ParentChild)
        {

        }

        
    }
}

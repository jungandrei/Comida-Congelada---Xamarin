using System;
using System.Collections.Generic;
using System.Text;
using ProjetoM3.Model;
using Unipon.Engine.ViewModel;

namespace ProjetoM3.ViewModel
{
    public class PratosViewModel : GenericoViewModel<Usuario>
    {
        public static PratosViewModel CreatePratosViewModel()
        {

            string ParentChild = $"app.dev"; // aqui eh o path dentro do firebase
            string NomeNodoFirebase = "prato"; //aqui eh o nome da tabela no firebase
            string NomeArquivoFirebase = "prato"; //aqui eh o nome da tabela dentro do app 

            // ModoObservacao.Nenhum        Nao faz sincronismo automatico
            // ModoObservacao.RemotoELocal  sincroniza a base local do app e o firebase
            // ModoObservacao.SomenteLocal  grava os dados apenas no celular, sem enviar para o firebase
            // ModoObservacao.SomenteRemoto grava os dados apenas no firebase

            return new PratosViewModel(NomeNodoFirebase, ModoObservacao.RemotoELocal, NomeArquivoFirebase, ParentChild);
        }

        public PratosViewModel(string NomeNodoFirebase, ModoObservacao modoObservacao, string NomeArquivoFirebase, string ParentChild = null) : base(NomeNodoFirebase, modoObservacao, NomeArquivoFirebase, ParentChild)
        {

        }

        
    }
}

using System;
using Newtonsoft.Json;
using Unipon.Engine.Interfaces;
using Unipon.Engine.Model;

namespace ProjetoM3.Model
{
    public class Usuario : BaseModel, IInterfaceBasica
    {
        #region Estrutura padrão (obrigatorio)
        [JsonIgnore]
        private string _Chave;

        [JsonProperty("k")]
        public string Chave { get => _Chave; set => Set(ref _Chave, value); } // O Set sincroniza a ViewModel e a Model, para "mostrar" a alteracao de valores

        [JsonIgnore]
        private DateTime _DataCriacao;

        [JsonProperty("dc")]
        public DateTime DataCriacao { get => _DataCriacao; set => Set(ref _DataCriacao, value); }

        [JsonIgnore]
        private DateTime _DataAtualizacao;

        [JsonProperty("da")]
        public DateTime DataAtualizacao { get => _DataAtualizacao; set => Set(ref _DataAtualizacao, value); }
        #endregion

        #region - Seus campos 
        [JsonIgnore]
        private string _Login;
        [JsonProperty("lo")]
        public string Login { get => _Login; set => Set(ref _Login, value); }

        [JsonIgnore]
        private string _Senha;

        [JsonProperty("se")] 
        public string Senha { get => _Senha; set => Set(ref _Senha, value); }

        [JsonIgnore]
        private string _Email;

        [JsonProperty("em")]
        public string Email { get => _Email; set => Set(ref _Email, value); }


       




        #endregion

    }
}

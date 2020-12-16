using System;
using Newtonsoft.Json;
using Unipon.Engine.Interfaces;
using Unipon.Engine.Model;

namespace ProjetoM3.Model
{
    public class SacolaPratos : BaseModel, IInterfaceBasica
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
    }
}

using System;
using Newtonsoft.Json;
using Unipon.Engine.Interfaces;
using Unipon.Engine.Model;

namespace ProjetoM3.Model
{
    public class Pratos : BaseModel, IInterfaceBasica
    {

        [JsonIgnore]
        private string _Chave;

        [JsonProperty("k")]
        public string Chave { get => _Chave; set => Set(ref _Chave, value); }

        [JsonIgnore]
        private DateTime _DataCriacao;

        [JsonProperty("dc")]
        public DateTime DataCriacao { get => _DataCriacao; set => Set(ref _DataCriacao, value); }

        [JsonIgnore]
        private DateTime _DataAtualizacao;

        [JsonProperty("da")]
        public DateTime DataAtualizacao { get => _DataAtualizacao; set => Set(ref _DataAtualizacao, value); }

        [JsonIgnore]
        private string _Nome;

        [JsonProperty("no")]
        public string Nome { get => _Nome; set => Set(ref _Nome, value); }

        [JsonIgnore]
        private int _Quantidade;

        [JsonProperty("qa")]
        public int Quantidade { get => _Quantidade; set => Set(ref _Quantidade, value); }


        [JsonIgnore] 
        private double _Preco;

        [JsonProperty("pe")]
        public double Preco { get => _Preco; set => Set(ref _Preco, value); }

        [JsonIgnore] 
        private string _Descricao;

        [JsonProperty("de")]
        public string Descricao { get => _Descricao; set => Set(ref _Descricao, value); }

        [JsonIgnore] private string _Titulo;

        [JsonProperty("ti")]
        public string Titulo { get => _Titulo; set => Set(ref _Titulo, value); }

    }
}

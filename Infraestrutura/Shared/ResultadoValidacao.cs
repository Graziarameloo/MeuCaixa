using Infraestrutura.Shared.Enums;
using Infraestrutura.Shared.Interfaces;

namespace Infraestrutura.Shared
{
    public class ResultadoValidacao : IResultadoValidacao
    {
        public bool OcorreuErro { get; }
        public string? MensagemErro { get; }
        public Exception? Excecao { get; }
        public TipoErro TipoErro { get; }


        public ResultadoValidacao()
        {
            OcorreuErro = false;
        }

        public ResultadoValidacao(string mensagemErro, TipoErro tipoErro = TipoErro.DadosInvalidos)
        {
            OcorreuErro = true;
            MensagemErro = mensagemErro;
            TipoErro = tipoErro;
        }

        public ResultadoValidacao(Exception excecao, string mensagemErro = "", TipoErro tipoErro = TipoErro.Inesperado)
        {
            OcorreuErro = true;
            Excecao = excecao;
            MensagemErro = mensagemErro;
            TipoErro = tipoErro;
        }

    }

    public class ResultadoValidacao<T> : IResultadoValidacao<T>
    {
        public bool OcorreuErro { get; }
        public string? MensagemErro { get; }
        public Exception? Excecao { get; }
        public T? Retorno { get; set; }
        public TipoErro TipoErro { get; }


        public ResultadoValidacao(T retorno)
        {
            OcorreuErro = false;
            Retorno = retorno;
        }

        public ResultadoValidacao(string mensagemErro, TipoErro tipoErro = TipoErro.DadosInvalidos)
        {
            OcorreuErro = true;
            MensagemErro = mensagemErro;
            TipoErro = tipoErro;
        }

        public ResultadoValidacao(Exception excecao, string mensagemErro = "", TipoErro tipoErro = TipoErro.Inesperado)
        {
            OcorreuErro = true;
            Excecao = excecao;
            MensagemErro = mensagemErro;
            TipoErro = tipoErro;
        }
    }
}
using Infraestrutura.Shared.Enums;

namespace Infraestrutura.Shared.Interfaces
{
    public interface IResultadoValidacao
    {
        bool OcorreuErro { get; }
        string? MensagemErro { get; }
        TipoErro TipoErro { get; }
    }
}

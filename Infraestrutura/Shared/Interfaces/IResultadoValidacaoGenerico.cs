namespace Infraestrutura.Shared.Interfaces
{
    public interface IResultadoValidacao<T> : IResultadoValidacao
    {
        T? Retorno { get; set; }
    }
}

using Infraestrutura.Shared;
using Infraestrutura.Shared.Interfaces;
using MeuCaixa.Cadastro.Entities;

namespace MeuCaixa.Cadastro.Service.Validator
{
    public class DespesaValidator
    {
        public IResultadoValidacao IncluirDespesa(DespesaEntity? despesa)
        {
            if (despesa == null)
                return new ResultadoValidacao("A despesa não pode ser nula.");

            if (string.IsNullOrWhiteSpace(despesa.Descricao))
                return new ResultadoValidacao("A descrição é obrigatória.");

            if (despesa.Descricao.Trim().Length > 200)
                return new ResultadoValidacao("A descrição deve ter até 200 caracteres.");
            
            if (despesa.Observacao != null && despesa.Observacao.Length > 500)
                return new ResultadoValidacao("A observação deve ter até 500 caracteres.");

            if (despesa.Valor <= 0)
                return new ResultadoValidacao("O valor da despesa deve ser maior que zero.");

            if (despesa.Valor > 9999999999999999.99m)
                return new ResultadoValidacao("O valor ultrapassa o limite permitido.");

            if (decimal.Round(despesa.Valor, 2) != despesa.Valor)
                return new ResultadoValidacao("O valor deve ter no máximo duas casas decimais.");

            if (despesa.DataVencimento == default)
                return new ResultadoValidacao("A data de vencimento é obrigatória.");

            return new ResultadoValidacao();
        }

        public IResultadoValidacao AlterarDespesa(DespesaEntity? despesa)
        {
            if (despesa == null)
                return new ResultadoValidacao("A despesa não pode ser nula.");

            if (despesa.IdDespesa <= 0)
                return new ResultadoValidacao("O ID da despesa deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(despesa.Descricao))
                return new ResultadoValidacao("A descrição é obrigatória.");

            if (despesa.Descricao.Trim().Length > 200)
                return new ResultadoValidacao("A descrição deve ter até 200 caracteres.");

            if (despesa.Observacao != null && despesa.Observacao .Length > 500)
                return new ResultadoValidacao("A observação deve ter até 500 caracteres.");

            if (despesa.Valor <= 0)
                return new ResultadoValidacao("O valor da despesa deve ser maior que zero.");

            if (despesa.Valor > 9999999999999999.99m)
                return new ResultadoValidacao("O valor ultrapassa o limite permitido.");

            if (decimal.Round(despesa.Valor, 2) != despesa.Valor)
                return new ResultadoValidacao("O valor deve ter no máximo duas casas decimais.");

            if (despesa.DataVencimento == default)
                return new ResultadoValidacao("A data de vencimento é obrigatória.");

            return new ResultadoValidacao();
        }

        public IResultadoValidacao ConsultarDespesa(int idDespesa)
        {
            if (idDespesa <= 0)
                return new ResultadoValidacao("Id não informado ou despesa inexistente.");

            return new ResultadoValidacao();
        }

        public IResultadoValidacao ExcluirDespesa(int idDespesa)
        {
            if (idDespesa <= 0)
                return new ResultadoValidacao("O ID da despesa deve ser maior que zero.");

            return new ResultadoValidacao();
        }

        public IResultadoValidacao ListarDespesa()
        {
            return new ResultadoValidacao();
        }
    }
}

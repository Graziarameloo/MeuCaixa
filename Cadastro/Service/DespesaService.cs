using Infraestrutura.Shared;
using Infraestrutura.Shared.Enums;
using Infraestrutura.Shared.Interfaces;
using MeuCaixa.Cadastro.Entities;
using MeuCaixa.Cadastro.Repositories.SqlServer.Interfaces;
using MeuCaixa.Cadastro.Service.Interface;
using MeuCaixa.Cadastro.Service.Validator;

namespace MeuCaixa.Cadastro.Service
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaSqlServerRepository despesaRepository;
        private readonly DespesaValidator despesaValidator;
        public DespesaService(
            IDespesaSqlServerRepository despesaRepository,
            DespesaValidator despesaValidator)
        {
            this.despesaRepository = despesaRepository;
            this.despesaValidator = despesaValidator;
        }

        public async Task<IResultadoValidacao<DespesaEntity>> AlterarDespesaAsync(DespesaEntity entity)
        {
            try
            {
                var validacao = despesaValidator.AlterarDespesa(entity);
                if (validacao.OcorreuErro)
                    return new ResultadoValidacao<DespesaEntity>(validacao.MensagemErro, TipoErro.DadosInvalidos);

                var consultarStatus = await despesaRepository.ConsultarDespesaAsync(entity.IdDespesa);

                if (consultarStatus == null)

                    return new ResultadoValidacao<DespesaEntity>("Id informado errado ou despesa não cadastrada.", TipoErro.NaoEncontrado);

                if (consultarStatus.Pago == true)
                {
                    return new ResultadoValidacao<DespesaEntity>("Despesa já está paga e não pode ser alterada", TipoErro.Conflito);
                }


                entity.Descricao = entity.Descricao.Trim();
                entity.DataVencimento = entity.DataVencimento.Date;

                var despesa = await despesaRepository.AlterarDespesaAsync(entity);

                return new ResultadoValidacao<DespesaEntity>(despesa);
            }
            catch (Exception ex)
            {
                return new ResultadoValidacao<DespesaEntity>(ex, "Ocorreu um erro ao tentar alterar despesa.");
            }
        }

        public async Task<IResultadoValidacao<DespesaEntity?>> ConsultarDespesaAsync(int idDespesa)
        {
            try
            {
                var validacao = despesaValidator.ConsultarDespesa(idDespesa);
                if (validacao.OcorreuErro)
                    return new ResultadoValidacao<DespesaEntity?>(validacao.MensagemErro, TipoErro.DadosInvalidos);

                var consulta = await despesaRepository.ConsultarDespesaAsync(idDespesa);

                if (consulta == null)
                    return new ResultadoValidacao<DespesaEntity?>("Despesa não encontrada.", TipoErro.NaoEncontrado);

                return new ResultadoValidacao<DespesaEntity?>(consulta);
            }
            catch (Exception ex)
            {
                return new ResultadoValidacao<DespesaEntity?>(ex, "Ocorreu um erro ao tentar consultar despesa.");
            }
        }

        public async Task<IResultadoValidacao<bool>> DeletarDespesaAsync(int idDespesa)
        {
            try
            {
                var validacao = despesaValidator.ExcluirDespesa(idDespesa);
                if (validacao.OcorreuErro)
                    return new ResultadoValidacao<bool>(validacao.MensagemErro, TipoErro.DadosInvalidos);

                var consultarStatus = await despesaRepository.ConsultarDespesaAsync(idDespesa);

                if (consultarStatus == null)
                {
                    return new ResultadoValidacao<bool>("Id informado errado ou despesa não cadastrada.", TipoErro.NaoEncontrado);
                }

                if (consultarStatus.Pago == true)
                {
                    return new ResultadoValidacao<bool>("Despesa já está paga e não pode ser excluída", TipoErro.Conflito);
                }

                var delete = await despesaRepository.DeletarDespesaAsync(idDespesa);

                if (!delete)
                {
                    return new ResultadoValidacao<bool>("Despesa não encontrada", TipoErro.NaoEncontrado);
                }

                return new ResultadoValidacao<bool>(true);
            }
            catch (Exception ex)
            {
                return new ResultadoValidacao<bool>(ex, "Ocorreu erro ao tentar deletar despesa.");
            }
        }

        public async Task<IResultadoValidacao<DespesaEntity>> IncluirDespesaAsync(DespesaEntity entity)
        {
            try
            {
                var validacao = despesaValidator.IncluirDespesa(entity);
                if (validacao.OcorreuErro)
                  return new ResultadoValidacao<DespesaEntity>(validacao.MensagemErro, TipoErro.DadosInvalidos);

                entity.IdDespesa = 0;
                entity.Descricao = entity.Descricao.Trim();
                entity.DataVencimento = entity.DataVencimento.Date;
                entity.Pago = false;
                entity.Observacao = entity.Observacao.Trim();


                var incluir = await despesaRepository.IncluirDespesaAsync(entity);

                return new ResultadoValidacao<DespesaEntity>(incluir);
            }
            catch (Exception ex)
            {
                return new ResultadoValidacao<DespesaEntity>(ex, "Ocorreu um erro ao tentar incluir despesa");
            }
        }

        public async Task<IResultadoValidacao<List<DespesaEntity>>> ListarDespesaAsync()
        {
            try
            {
                var validacao = despesaValidator.ListarDespesa();
                if (validacao.OcorreuErro)
                    throw new ArgumentException(validacao.MensagemErro);

                var listar = await despesaRepository.ListarDespesaAsync();

                return new ResultadoValidacao<List<DespesaEntity>>(listar);
            }
            catch (Exception ex)
            {
                return new ResultadoValidacao<List<DespesaEntity>>(ex, "Ocorreu erro ao tentar listar despesas");
            }
        }
    }
}

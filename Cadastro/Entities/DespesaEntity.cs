namespace MeuCaixa.Cadastro.Entities
{
    public class DespesaEntity
    {
        public int IdDespesa { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }
        public string? Observacao { get; set; }
    }
}

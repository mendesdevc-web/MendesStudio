namespace Studio.Service.Dtos.ResponseDto
{
    public class ReponseCriarAtendimento
    {
        public int CodigoAtendimento { get; set; }
        public int CodigoPosto { get; set; }
        public int CodigoCliente { get; set; }
        public DateTime DataAtendimento { get; set; }
        public decimal ValorTotal { get; set; }

    }
}

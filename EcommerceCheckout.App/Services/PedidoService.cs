namespace EcommerceCheckout.App.Services
{
    public class PedidoService
    {
        /// <summary>
        /// Gera um código de rastreio formatado unindo a região em maiúsculas 
        /// e o número do pedido com 4 dígitos preenchidos com zeros à esquerda.
        /// </summary>
        public string GerarCodigoRastreio(string regiao, int numeroPedido)
        {
            string regiaoFormatada = regiao.ToUpper();
            string numeroFormatado = numeroPedido.ToString("D4"); // Garante 4 dígitos (ex: 42 -> 0042)

            return $"{regiaoFormatada}-{numeroFormatado}";
        }

        /// <summary>
        /// Calcula os pontos de fidelidade: 2 pontos a cada R$ 10 completos gastos.
        /// </summary>
        public int CalcularPontosFidelidade(int valorTotal)
        {
            int parcelasDeDez = valorTotal / 10;
            return parcelasDeDez * 2;
        }

        /// <summary>
        /// Determina se o pedido tem direito a frete grátis (valor >= R$ 200 OU cliente VIP).
        /// </summary>
        public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
        {
            return valorTotal >= 200 || eClienteVIP;
        }
    }
}
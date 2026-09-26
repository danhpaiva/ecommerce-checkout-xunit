using EcommerceCheckout.App.Services;

namespace EcommerceCheckout.Tests.Tests
{
    public class PedidoServiceTests
    {
        private readonly PedidoService _service;

        public PedidoServiceTests()
        {
            // Instancia o serviço para reutilização nos testes da classe
            _service = new PedidoService();
        }

        [Fact]
        public void GerarCodigoRastreio_DeveRetornarRegiaoEmMaiusculasENumeroComQuatroDigitos()
        {
            // Arrange (Organizar)
            string regiao = "sudeste";
            int numeroPedido = 42;
            string resultadoEsperado = "SUDESTE-0042";

            // Act (Agir)
            string resultado = _service.GerarCodigoRastreio(regiao, numeroPedido);

            // Assert (Validar)
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void CalcularPontosFidelidade_DeveCalcularDoisPontosACadaDezReais()
        {
            // Arrange (Organizar)
            int valorTotal = 150;
            int resultadoEsperado = 30; // (150 / 10) * 2 = 30

            // Act (Agir)
            int resultado = _service.CalcularPontosFidelidade(valorTotal);

            // Assert (Validar)
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TemDireitoAFreteGratis_DeveRetornarTrue_QuandoClienteforVIPMesmoComValorAbaixoDe200()
        {
            // Arrange (Organizar)
            int valorTotal = 150;
            bool eClienteVIP = true;

            // Act (Agir)
            bool resultado = _service.TemDireitoAFreteGratis(valorTotal, eClienteVIP);

            // Assert (Validar)
            Assert.True(resultado);
        }

        [Fact]
        public void TemDireitoAFreteGratis_DeveRetornarFalse_QuandoNaoForVIPEValorForMenorQue200()
        {
            // Arrange (Organizar)
            int valorTotal = 150;
            bool eClienteVIP = false;

            // Act (Agir)
            bool resultado = _service.TemDireitoAFreteGratis(valorTotal, eClienteVIP);

            // Assert (Validar)
            Assert.False(resultado);
        }

        [Fact]
        public void TemDireitoAFreteGratis_DeveRetornarTrue_QuandoValorForIgualOuMaiorQue200MesmoNaoSendoVIP()
        {
            // Arrange (Organizar)
            int valorTotal = 200;
            bool eClienteVIP = false;

            // Act (Agir)
            bool resultado = _service.TemDireitoAFreteGratis(valorTotal, eClienteVIP);

            // Assert (Validar)
            Assert.True(resultado);
        }
    }
}
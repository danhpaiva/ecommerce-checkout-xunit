using EcommerceCheckout.App.Services;

PedidoService pedidoService = new PedidoService();
var resultado = pedidoService.GerarCodigoRastreio("sudeste", 42); // Retorna "SUDESTE-0042"
Console.WriteLine(resultado);
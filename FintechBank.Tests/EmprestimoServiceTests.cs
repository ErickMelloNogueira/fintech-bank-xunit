using Xunit;
using FintechBank.App;

namespace FintechBank.Tests
{
    public class EmprestimoServiceTests
    {
        private readonly EmprestimoService _service;

        public EmprestimoServiceTests()
        {
            _service = new EmprestimoService();
        }

        // Teste 1 (Cálculo de Parcela com Juros por Score)
        [Theory]
        [InlineData(10000.00, 10, 800, 1050.00)] // Score alto: 5% de juros[cite: 8]
        [InlineData(10000.00, 10, 600, 1120.00)] // Score médio: 12% de juros[cite: 8]
        [InlineData(10000.00, 10, 400, 1200.00)] // Score baixo: 20% de juros[cite: 8]
        public void CalcularValorParcela_DeveRetornarParcelaCorreta(decimal valorTotal, int parcelas, int scoreCredito, decimal resultadoEsperado)
        {
            var resultado = _service.CalcularValorParcela(valorTotal, parcelas, scoreCredito);
            Assert.Equal(resultadoEsperado, resultado);
        }

        // Teste 2 (Aprovação de Empréstimo por Margem consignável)
        [Theory]
        [InlineData(5000.00, 1500.00, true)]  // Parcela <= 30% da renda -> Aprovado
        [InlineData(5000.00, 1600.00, false)] // Parcela > 30% da renda -> Recusado[cite: 9]
        public void AprovarEmprestimo_DeveValidarCorretamente(decimal rendaMensal, decimal valorParcela, bool resultadoEsperado)
        {
            var resultado = _service.AprovarEmprestimo(rendaMensal, valorParcela);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
using Xunit;
using FintechBank.App;

namespace FintechBank.Tests
{
    public class ContaCorrenteServiceTests
    {
        private readonly ContaCorrenteService _service;

        public ContaCorrenteServiceTests()
        {
            _service = new ContaCorrenteService();
        }

        // Teste 1 (Taxa de Manutenção)
        [Theory]
        [InlineData(6000.00, false, 0.00)] // Saldo alto -> Isento[cite: 8]
        [InlineData(500.00, true, 0.00)]   // Cliente Especial -> Isento[cite: 8]
        [InlineData(2500.00, false, 12.50)]// Saldo intermediário -> R$ 12,50[cite: 8]
        [InlineData(300.00, false, 25.00)] // Saldo baixo -> R$ 25,00[cite: 8]
        public void CalcularTaxaManutencao_DeveRetornarTaxaCorreta(decimal saldo, bool clienteEspecial, decimal resultadoEsperado)
        {
            var resultado = _service.CalcularTaxaManutencao(saldo, clienteEspecial);
            Assert.Equal(resultadoEsperado, resultado);
        }

        // Teste 2 (Validação de Saque)
        [Theory]
        [InlineData(1000.00, 500.00, 1200.00, true)] // Dentro do limite total -> true[cite: 8]
        [InlineData(1000.00, 500.00, 1600.00, false)]// Excede saldo + limite -> false[cite: 8]
        public void PodeRealizarSaque_DeveValidarCorretamente(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque, bool resultadoEsperado)
        {
            var resultado = _service.PodeRealizarSaque(saldo, limiteChequeEspecial, valorSaque);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
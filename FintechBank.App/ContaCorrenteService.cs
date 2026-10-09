namespace FintechBank.App
{
    public class ContaCorrenteService
    {
        public decimal CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)
        {
            // Saldo maior ou igual a R$ 5.000,00 OU clienteEspecial == true[cite: 6]
            if (saldo >= 5000.00m || clienteEspecial)
            {
                return 0.00m;
            }
            // Saldo entre R$ 1.000,00 e R$ 4.999,99 (e não especial)[cite: 6]
            else if (saldo >= 1000.00m && saldo <= 4999.99m)
            {
                return 12.50m;
            }
            // Saldo menor que R$ 1.000,00 (e não especial)[cite: 6]
            else
            {
                return 25.00m;
            }
        }

        public bool PodeRealizarSaque(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque)
        {
            // Retorna true apenas se o valor do saque for menor ou igual à soma de saldo + limiteChequeEspecial[cite: 6]
            return valorSaque <= (saldo + limiteChequeEspecial);
        }
    }
}
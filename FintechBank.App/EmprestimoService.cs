namespace FintechBank.App
{
    public class EmprestimoService
    {
        public decimal CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito)
        {
            decimal valorComJuros;

            // Se scoreCredito >= 700: taxa de juros de 5% (multiplica por 1.05m)[cite: 6]
            if (scoreCredito >= 700)
            {
                valorComJuros = valorTotal * 1.05m;
            }
            // Se scoreCredito entre 500 e 699: taxa de juros de 12% (multiplica por 1.12m)[cite: 6]
            else if (scoreCredito >= 500 && scoreCredito <= 699)
            {
                valorComJuros = valorTotal * 1.12m;
            }
            // Se scoreCredito < 500: taxa de juros de 20% (multiplica por 1.20m)[cite: 6]
            else
            {
                valorComJuros = valorTotal * 1.20m;
            }

            // Retornar o valor da parcela individual[cite: 6]
            return valorComJuros / parcelas;
        }

        public bool AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)
        {
            // O empréstimo só é aprovado se a parcela comprometer no máximo 30% da renda[cite: 6]
            return valorParcela <= (rendaMensal * 0.30m);
        }
    }
}
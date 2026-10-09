# FintechBank

## 📌 Visão Geral
O **FintechBank** é uma aplicação bancária desenvolvida em C# que simula regras de negócio do setor financeiro. O projeto implementa serviços de cálculo de taxas, validação de saques e simulação de empréstimos, garantindo a qualidade do código através de testes unitários automatizados.

## 🛠️ Requisitos Técnicos
- **Linguagem:** C#
- **Framework:** .NET 10.0
- **Testes:** xUnit

## 💼 Regras de Negócio Implementadas

### 1. Conta Corrente (`ContaCorrenteService`)
- **Taxa de Manutenção:** Clientes com saldo igual ou superior a R$ 5.000,00 ou classificados como "Cliente Especial" são isentos. Para saldos entre R$ 1.000,00 e R$ 4.999,99 a taxa é de R$ 12,50. Para saldos inferiores a R$ 1.000,00, a taxa é de R$ 25,00.
- **Validação de Saque:** O saque só é permitido se o valor desejado for menor ou igual à soma do saldo atual com o limite do cheque especial.

### 2. Empréstimos (`EmprestimoService`)
- **Cálculo de Parcela e Juros:** A taxa de juros varia de acordo com o score de crédito do cliente:
  - Score >= 700: 5% de juros totais.
  - Score entre 500 e 699: 12% de juros totais.
  - Score < 500: 20% de juros totais.
- **Aprovação de Empréstimo:** O empréstimo só é aprovado se o valor da parcela mensal não ultrapassar a margem consignável de 30% da renda mensal do cliente.

## 🚀 Como Clonar e Compilar
Para obter uma cópia local do projeto e compilá-lo, siga os passos abaixo no seu terminal:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/ErickMelloNogueira/fintech-bank-xunit
   ```
2. **Aceda à pasta do projeto:**
   ```bash
   cd streaming-flix-xunit
   ```
3. **Compile a solução:**
   ```bash
   dotnet build
   ```

## 🧪 Como Executar os Testes Unitários
O projeto possui uma suíte de testes automatizados para garantir a integridade das regras de negócio. Para executá-los, utilize o comando abaixo na raiz do projeto:

```bash
dotnet test
```

## 🧩 Estrutura de Testes Parametrizados (xUnit)
Os testes foram construídos utilizando o padrão de testes parametrizados do xUnit para evitar repetição de código e testar múltiplos cenários de forma eficiente:
- **`[Theory]`**: Esta anotação indica ao xUnit que o método de teste receberá parâmetros externos e será executado múltiplas vezes.
- **`[InlineData]`**: Esta anotação fornece os valores reais para cada execução do teste (cenário). Por exemplo, passamos o saldo, o status do cliente e o valor esperado diretamente pelo `[InlineData]`, permitindo validar as regras de isenção e cobrança numa única estrutura de método.

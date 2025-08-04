using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = Console.ReadLine();

            // Realiza validação Regex para descobrirmos se a placa é válida
            var placaValida = Regex.IsMatch(placa, @"^\w{3}-\d{1}(\d|\w){1}\d{2}$");

            if (!placaValida)
            {
                Console.WriteLine($"A placa {placa} não é válida\n");
                return;
            }

            veiculos.Add(placa.ToUpper());
            Console.WriteLine("Placa adicionada com sucesso!\n");
        }

        public void RemoverVeiculo()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos para remover");
                return;
            }

            // Para melhor experiência, listamos os veículos ao escolher esta opção, facilitando a remoção
            ListarVeiculos();

            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                var horaValida = int.TryParse(Console.ReadLine(), out int horas);

                if (!horaValida)
                {
                    Console.WriteLine("As horas são inválidas.");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

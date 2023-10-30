namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null)
            {
                throw new ArgumentNullException(nameof(hospedes), "A lista de hóspedes não pode ser nula.");
            }

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException($"Capacidade insuficiente. A suíte comporta no máximo {Suite.Capacidade} hóspede(s), mas foram recebidos {hospedes.Count}.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            const decimal taxaDesconto = 0.10m;

            if (DiasReservados >= 10)
            {
                decimal valorDesconto = valor * taxaDesconto;
                valor = valor - valorDesconto;
            }

            return valor;
        }
    }
}
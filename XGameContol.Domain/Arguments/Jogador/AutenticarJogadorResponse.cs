using XGameContol.Domain.Interfaces.Arguments;

namespace XGameContol.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse : IResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }
    }
}

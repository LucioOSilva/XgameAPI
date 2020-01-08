using XGameContol.Domain.Interfaces.Arguments;

namespace XGameContol.Domain.Arguments.Jogador
{
    public class AutenticarJogadorRequest : IRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

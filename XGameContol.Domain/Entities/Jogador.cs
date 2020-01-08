using System;
using XGameContol.Domain.ValueObjects;
using XGameContol.Domain.Enums;

namespace XGameContol.Domain.Entities
{
    public class Jogador
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; set; }
    }
}

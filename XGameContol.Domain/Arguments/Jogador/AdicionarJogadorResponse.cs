using System;
using XGameContol.Domain.Interfaces.Arguments;

namespace XGameContol.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entidade)
        {
            return new AdicionarJogadorResponse()
            {
                Id = entidade.Id,
                Message = "Operação realizada com sucesso!"
            };
        }
    }
}

﻿using XGameContol.Domain.Interfaces.Arguments;

namespace XGameContol.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse : IResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entidade)
        {
            return new AutenticarJogadorResponse()
            {
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                Status = (int)entidade.Status
            };
        }
    }
}
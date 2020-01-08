using System;
using XGameContol.Domain.Arguments.Jogador;
using XGameContol.Domain.Entities;

namespace XGameContol.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

        Guid AdicionarJogador(Jogador jogador);
    }
}


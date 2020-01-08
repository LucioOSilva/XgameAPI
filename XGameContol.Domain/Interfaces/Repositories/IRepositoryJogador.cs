using System;
using XGameContol.Domain.Arguments.Jogador;

namespace XGameContol.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

        Guid AdicionarJogador(AdicionarJogadorRequest request);
    }
}


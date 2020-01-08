using System;
using XGameContol.Domain.Arguments.Jogador;
using XGameContol.Domain.Interfaces.Repositories;
using XGameContol.Domain.Interfaces.Services;

namespace XGameContol.Domain.ServicesMaster
{
    class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositorioJogador;

        public ServiceJogador(IRepositoryJogador repositorioJogador)
        {
            _repositorioJogador = repositorioJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {

            Guid Id = _repositorioJogador.AdicionarJogador(request);
            return new AdicionarJogadorResponse() { Id = Id, Message = "Adicionado OK" };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                throw new Exception("Autenticar Jogador Request é Obrigatório");
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Email é Obrigatório");
            }

            if (IsEmail(request.Email))
            {
                throw new Exception("Email é Obrigatório");
            }

            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Email é Obrigatório");
            }

            if (request.Senha.Length <= 6)
            {
                throw new Exception("Senha deve conter no mínimo 6 caracteres");
            }

            var response =_repositorioJogador.AutenticarJogador(request);
            return response;
        }

        private bool IsEmail(string email)
        {
            return false;
        }
    }
}

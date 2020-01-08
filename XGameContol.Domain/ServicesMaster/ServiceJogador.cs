using prmToolkit.NotificationPattern;
using System;
using XGameContol.Domain.Arguments.Jogador;
using XGameContol.Domain.Entities;
using XGameContol.Domain.Interfaces.Repositories;
using XGameContol.Domain.Interfaces.Services;
using XGameContol.Domain.ValueObjects;

namespace XGameContol.Domain.ServicesMaster
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositorioJogador;

        public ServiceJogador(IRepositoryJogador repositorioJogador)
        {
            _repositorioJogador = repositorioJogador;
        }

        public ServiceJogador()
        {

        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            Jogador jogador = new Jogador();
            jogador.Email = request.Email;
            jogador.Nome = request.Nome;
            jogador.Status = Enums.EnumSituacaoJogador.EmAndamento;

            Guid Id = _repositorioJogador.AdicionarJogador(jogador);
            return new AdicionarJogadorResponse() { Id = Id, Message = "Adicionado OK" };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", "Autenticar é obrigatorio");
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
            {
                return null;
            }

            var response = _repositorioJogador.AutenticarJogador(request);
            return response;
        }

        private bool IsEmail(string email)
        {
            return false;
        }
    }
}

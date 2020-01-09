using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ServiceJogador()
        {
        }

        public ServiceJogador(IRepositoryJogador repositorioJogador)
        {
            _repositorioJogador = repositorioJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);
            var jogador = new Jogador(nome, email, request.Senha);

            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositorioJogador.AdicionarJogador(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarJogadorRequest", "Dados nulos para alterar jogador");
            }

            Jogador jogador = _repositorioJogador.ObterJogadorPorId(request.Id);
            if (jogador  == null)
            {
                AddNotification("Id", "Dados nao encontrados");
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositorioJogador.AlterarJogador(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", "Autenticar é obrigatorio");
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador);

            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositorioJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositorioJogador.ListarJogador().ToList().Select(jogador=> (JogadorResponse)jogador).ToList();
        }
    }
}

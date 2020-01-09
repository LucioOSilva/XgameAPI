using System;
using XGameContol.Domain.ValueObjects;
using XGameContol.Domain.Enums;
using prmToolkit.NotificationPattern;
using XGameContol.Domain.Extensions;

namespace XGameContol.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve ter de 6 a 32 caracteres");
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve ter de 6 a 32 caracteres");
                        
            if (this.IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }

            AddNotifications(nome, email);
        }

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador status)
        {
            Nome = nome;
            Email = email;
            new AddNotifications<Jogador>(this).IfFalse(Status == EnumSituacaoJogador.Ativo, "Só é possivel alterar jogador 'ativo'");
            AddNotifications(nome, email);
        }

        public override string ToString()
        {
            return Nome.PrimeiroNome + " " + Nome.UltimoNome;
        }

    }
}

using System;
using XGameContol.Domain.ValueObjects;
using XGameContol.Domain.Enums;
using prmToolkit.NotificationPattern;

namespace XGameContol.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador()
        {
        }
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNotEmail(x => x.Email.Endereco, "Informe e-mail válido")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve ter de 6 a 32 caracteres");
        }
        

        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; set; }




    }
}

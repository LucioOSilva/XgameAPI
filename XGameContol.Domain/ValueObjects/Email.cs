using prmToolkit.NotificationPattern;

namespace XGameContol.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this).IfNotEmail(x => x.Endereco);
        }
    }
    
}

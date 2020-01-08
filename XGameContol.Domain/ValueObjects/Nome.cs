using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGameContol.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this).IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 50).IfNullOrInvalidLength(x => x.UltimoNome, 3, 50); ;
        }
    }
}

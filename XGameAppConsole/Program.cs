using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGameContol.Domain.Arguments.Jogador;
using XGameContol.Domain.ServicesMaster;
using XGameContol.Domain.ValueObjects;

namespace XGameAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");
            var service = new ServiceJogador();
            Console.WriteLine("Instancia criada do objeto request");


            //AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            //Console.WriteLine("Criado instancia de objeto request");
            //request.Email = "anakinskywalker@gmail.com";
            //request.Senha = "123456";

            var request = new AdicionarJogadorRequest()
            {
                Email = "anakinskywalker@gmail.com",
                PrimeiroNome = "anakin",
                UltimoNome = "skywalker",
                Senha = "123456"
            };

            var response = service.AdicionarJogador(request);
            //var response = service.AutenticarJogador(request);

            Console.WriteLine("Serviço é valido ->" + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });


            Console.ReadKey();




        }
    }
}

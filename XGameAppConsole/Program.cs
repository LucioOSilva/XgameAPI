using System;
using System.Linq;
using XGameContol.Domain.Arguments.Jogador;
using XGameContol.Domain.ServicesMaster;

namespace XGameAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");
            var service = new ServiceJogador();
            Console.WriteLine("Instancia criada do objeto request");


            //AutenticarJogadorRequest autenticarRequest = new AutenticarJogadorRequest();
            //Console.WriteLine("Criado instancia de objeto request");
            //autenticarRequest.Email = "anakinskywalker@gmail.com";
            //autenticarRequest.Senha = "123456";

            //var AdicionarRequest = new AdicionarJogadorRequest()
            //{
            //    Email = "anakinskywalker@gmail.com",
            //    Senha = "123456",
            //    PrimeiroNome = "anakin",
            //    UltimoNome = "skywalker"
            //};

            ////var response = service.AutenticarJogador(autenticarRequest);
            //var response2 = service.AdicionarJogador(AdicionarRequest);
            var result = service.ListarJogador();

            Console.WriteLine("Serviço é valido ->" + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });


            Console.ReadKey();




        }
    }
}

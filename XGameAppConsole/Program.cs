using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            var response = service.AutenticarJogador(request);


            Console.ReadKey();




        }
    }
}

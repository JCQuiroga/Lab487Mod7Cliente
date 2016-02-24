using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Lab487Mod7;
using Microsoft.ServiceBus;

namespace Lab487Mod7Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<IServicioSaludoSb>(new NetTcpRelayBinding(), new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "lab487mod7sb", "saludo")));
            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior()
            {
                TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner", "xc/k9keil4yuD9dCw2+8UxsCnIz1+18mlqeTfX2KayU=")
            });

            using (var ch = cf.CreateChannel()) //Se puede usar el using porque el interfaz implementa IDisposable
            {
               Console.WriteLine(ch.GetSaludo("es"));
            }
            Console.Read();
        }
    }
}

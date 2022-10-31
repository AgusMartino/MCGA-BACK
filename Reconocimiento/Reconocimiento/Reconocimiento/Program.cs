using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconocimiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var canal = connection.CreateModel())
            {

                canal.QueueDeclare(queue: "Reconocimiento", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumidor = new EventingBasicConsumer(canal);
                consumidor.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var mensaje = Encoding.UTF8.GetString(body);

                    Console.WriteLine($" [X] Patente {mensaje} Recibida");
                    //verificar patente en la base
                    bool verificacion = Verificacion_Patente.VerificacionPatente.Current.Verificacion(mensaje);
                    //enviar a pago
                    if (verificacion == true)
                    {
                        EnvioPatente.EnvioPatente.Current.pago(mensaje);
                    }
                    //enviar a multa
                    if (verificacion == false)
                    {
                        EnvioPatente.EnvioPatente.Current.multa(mensaje);
                    }
                    

                };

                canal.BasicConsume(queue: "Reconocimiento", autoAck: true, consumer: consumidor);

                Console.WriteLine("Running on localhost");
                Console.WriteLine("Press enter to exit");
                Console.ReadKey();

            }
        }
    }
}

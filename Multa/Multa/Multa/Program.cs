using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var canal = connection.CreateModel())
            {

                canal.QueueDeclare(queue: "Multa", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumidor = new EventingBasicConsumer(canal);
                consumidor.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var mensaje = Encoding.UTF8.GetString(body);

                    Console.WriteLine($" [X] Patente {mensaje} Recibida");
                    //generar multa
                    GenerarMulta.GenerarMulta.Current.multa(mensaje);
                    Console.WriteLine($" [X] Patente {mensaje} registrada con multa");


                };

                canal.BasicConsume(queue: "Multa", autoAck: true, consumer: consumidor);

                Console.WriteLine("Corriendo generador de multas en localhost");
                Console.WriteLine("Press enter to exit");
                Console.ReadKey();

            }
        }
    }
}

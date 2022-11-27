using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reconocimiento
{
    internal class Program
    {
        static bool levantado = true;
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var canal = connection.CreateModel())
            {

                canal.QueueDeclare(queue: "Reconocimiento", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumidor = new EventingBasicConsumer(canal);

                consumidor.Received += (model, ea) => Evento(model, ea);

                canal.BasicConsume(queue: "Reconocimiento", autoAck: true, consumer: consumidor);
                Logger.Logger.Current.Log("Se inicio servicio de Reconocimiento", "");

                ManageEstado(consumidor, canal);

                Console.WriteLine("Running on localhost");
                Console.WriteLine("Press enter to exit");
                Console.ReadKey();

            }
        }

        static void ManageEstado(EventingBasicConsumer consumidor, IModel canal)
        {
            Action action = () =>
            {
                Console.WriteLine("Chequeo de estado");

                var temp_estado = checkEstado();

                if (temp_estado == false && levantado != false)
                {
                    try
                    {
                        canal.BasicCancel(consumidor.ConsumerTags.FirstOrDefault());
                        Logger.Logger.Current.Log("Apagar servicio de Reconocimiento", "");
                        levantado = false;
                    }
                    
                    catch (Exception ex){
                    
                    }
                }
                else if (temp_estado == true && levantado == false)
                {
                    canal.BasicConsume(queue: "Reconocimiento", autoAck: true, consumer: consumidor);
                    Logger.Logger.Current.Log("Prender servicio de Reconocimiento", "");
                    levantado = true;
                }
            };

            TaskTimer tk = new TaskTimer(action, 1500);

            tk.Start();
        }

        static bool checkEstado()
        {
            bool estado = EstadoServicio.EstadoServicio.Current.Estado();
            return estado;
        }

        static void Evento(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var mensaje = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [X] Patente {mensaje} Recibida");
            Logger.Logger.Current.Log("Se recibe patente", mensaje);
            //verificar patente en la base
            bool verificacion = Verificacion_Patente.VerificacionPatente.Current.Verificacion(mensaje);
            //enviar a pago
            if (verificacion == true)
            {
                EnvioPatente.EnvioPatente.Current.pago(mensaje);
                Logger.Logger.Current.Log("Eviando a servicio de pagos patente", mensaje);
            }
            //enviar a multa
            if (verificacion == false)
            {
                EnvioPatente.EnvioPatente.Current.multa(mensaje);
                Logger.Logger.Current.Log("Eviando a servicio de multas patente", mensaje);
            }
        }
    }
}


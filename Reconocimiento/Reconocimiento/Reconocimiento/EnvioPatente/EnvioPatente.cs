using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconocimiento.EnvioPatente
{
    public class EnvioPatente
    {
        #region Singleton
        private readonly static EnvioPatente _instance;
        public static EnvioPatente Current { get { return _instance; } }
        static EnvioPatente() { _instance = new EnvioPatente(); }
        private EnvioPatente()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public void multa(string mensaje) 
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var canal = connection.CreateModel())
                {
                    //Defino el nombre de la cola y el contenido del mensaje

                    //-> Cola
                    canal.QueueDeclare(queue: "Multa", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    //-> Mensaje
                    string patente = mensaje;
                    var body = Encoding.UTF8.GetBytes(mensaje);

                    //->Enviamos el mensaje
                    canal.BasicPublish(exchange: "", routingKey: "Multa", basicProperties: null, body: body);

                    Console.WriteLine($" [x] Patente {patente} con multa");
                }
            }
        }
        public void pago(string mensaje)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var canal = connection.CreateModel())
                {
                    //Defino el nombre de la cola y el contenido del mensaje

                    //-> Cola
                    canal.QueueDeclare(queue: "Pago", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    //-> Mensaje
                    string patente = mensaje;
                    var body = Encoding.UTF8.GetBytes(mensaje);

                    //->Enviamos el mensaje
                    canal.BasicPublish(exchange: "", routingKey: "Pago", basicProperties: null, body: body);

                    Console.WriteLine($" [x] Patente {patente} con pago");
                }
            }
        }

    }
}

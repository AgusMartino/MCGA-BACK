using System.Net.Sockets;
using System.Net;
using System.Text;

// El servidor TCP va a ser el que recibe info
// En nuestro caso seria el telepeaje que recibe patentes

// "Constructor" =================================

ExecuteServer();

// Metodos =======================================

static void ExecuteServer()
{
    try
    {
        //config variables para armar socket y endpoint
        var hostName = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(hostName);
        IPAddress ipAddr = ipHost.AddressList[0];

        //instanciamos endpoint
        IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

        //instanciamos socket
        Socket listener = new Socket(ipAddr.AddressFamily,
                     SocketType.Stream, ProtocolType.Tcp);

        //bindeamos socket y endpoint
        listener.Bind(localEndPoint);

        //hacemos espacio para clientes que quieran conectarse al server
        int cantidad_max_clientes = 10;
        listener.Listen(cantidad_max_clientes);

        //entramos en un ciclo infinito de escucha iterativa
        while (true)
        {
            Console.WriteLine("Waiting connection ... ");

            //de haber un request de cliente, se aceptará con esto
            Socket clientSocket = listener.Accept();

            //creamos el buffer de datos
            byte[] bytes = new Byte[1024];
            string? data = null;

            //leemos bytes hasta que ya no quede nada por leer
            while (true)
            {
                int numByte = clientSocket.Receive(bytes);

                string temp_data = Encoding.ASCII.GetString(bytes,
                                            0, numByte);

                data += temp_data.Replace("<EOT>","");

                if (temp_data.IndexOf("<EOT>") > -1)
                    break;
            }

            //logeamos recibido
            Console.WriteLine("Text received -> {0} ", data);

            //retornamos un msj de recibido al cliente
            byte[] message = Encoding.ASCII.GetBytes("Mensaje recibido.");

            //enviamos el msj al cliente
            clientSocket.Send(message);

            //cerramos el socket
            //despues podemos usar el socket cerrado para una nueva conexión del cliente
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();

            //pequeño descanso de 5ms para que no se bugee nada
            Thread.Sleep(5);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    
}

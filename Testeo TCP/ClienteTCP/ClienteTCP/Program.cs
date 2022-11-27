using System.Net.Sockets;
using System.Net;
using System.Text;

// El cliente TCP va a ser el que envie info
// En nuestro caso seria la consola que manda patentes

// "Constructor" =================================

while (true)
{
    Console.WriteLine("Ingrese una patente");
    ExecuteClient(Console.ReadLine());
}


// Metodos =======================================

static void ExecuteClient(string? patente)
{
    if (patente == null) return;

    string patente_msg = patente + "<EOT>";

    try
    {
        //config variables para armar socket y endpoint
        var hostName = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(hostName);
        IPAddress ipAddr = ipHost.AddressList[0];

        //instanciamos endpoint
        IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

        //instanciamos socket
        Socket sender = new Socket(ipAddr.AddressFamily,
                   SocketType.Stream, ProtocolType.Tcp);

        //conectamos socket y endpoint
        sender.Connect(localEndPoint);

        //logeamos donde nos conectamos
        Console.WriteLine("Socket connected to -> {0} ",
                        sender.RemoteEndPoint?.ToString());

        //creamos la info que le vamos a enviar al server
        byte[] messageSent = Encoding.ASCII.GetBytes(patente_msg);

        //enviamos la info al server
        int byteSent = sender.Send(messageSent);

        //creamos buffer de datos para recibir respuesta del server
        byte[] messageReceived = new byte[1024];

        //recibimos respuesta del server
        int byteRecv = sender.Receive(messageReceived);
        string msg_server = Encoding.ASCII.GetString(messageReceived,
                                            0, byteRecv);

        Console.WriteLine("Message from Server -> {0}", msg_server);

        //cerramos el socket
        sender.Shutdown(SocketShutdown.Both);
        sender.Close();
    }
    catch (Exception e)
    {

        Console.WriteLine(e.ToString());
    }
}

using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string serverIp = "127.0.0.1";
        int serverPort = 13000;
        
        try
        {
            using (TcpClient client = new TcpClient(serverIp, serverPort))
            using (NetworkStream stream = client.GetStream())
            {
                Console.WriteLine("Conectado ao servidor.");
                
                // Receber e exibir o menu do servidor
                string menu = ReceiveMessage(stream);
                Console.WriteLine(menu);

                while (true)
                {
                    // Ler a opção escolhida pelo usuário
                    //Console.Write("Escolha uma opção: ");
                    string option = Console.ReadLine();

                    // Enviar a opção para o servidor
                    SendMessage(stream, option);

                    // Receber e exibir a resposta do servidor
                    string response = ReceiveMessage(stream);
                    Console.WriteLine(response);

                    // Encerrar a aplicação se a opção for 0
                    if (option == "0")
                    {
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
        }

        //Console.WriteLine("Conexão encerrada.");
    }

    // Envia uma mensagem para o servidor
    private static void SendMessage(NetworkStream stream, string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message + "\n");
        stream.Write(data, 0, data.Length);
    }

    // Recebe uma mensagem do servidor
    private static string ReceiveMessage(NetworkStream stream)
    {
        byte[] buffer = new byte[256];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
    }
}
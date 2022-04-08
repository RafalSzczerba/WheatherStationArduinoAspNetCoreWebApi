using System.Net;
using System.Net.Sockets;
using WheatherStation.DAL.Entities;

namespace WheatherStation.Services
{
    public class ArduinoService : IArduinoService
    {
        public Arduino ReadMeasure()
        {





            var temperature = "";
            var pressure = "";
            if(temperature != null && pressure != null)
            {
               return new Arduino();
            }           
            return new Arduino { Tempetature = temperature, Pressure = pressure, Created = DateTime.Now };
            

        }

        public string ReadDataFromArduino(IPAddress address, int port)
        {            
            TcpListener server = new TcpListener(address, port);
            server.Start();
            Console.WriteLine("Server started. Waiting for connection...");
            //Block execution until a new client is connected.
            TcpClient newClient = server.AcceptTcpClient();
            Console.WriteLine("New client connected!");

            //Checking if new data is available to be read on the network stream
            if (newClient.Available > 0)
            {
                //Initializing a new byte array the size of the available bytes on the network stream
                byte[] readBytes = new byte[newClient.Available];
                //Reading data from the stream
                newClient.GetStream().Read(readBytes, 0, newClient.Available);
                //Converting the byte array to string
                String str = System.Text.Encoding.ASCII.GetString(readBytes);
                //This should output "Hello world" to the console window
                Console.WriteLine(str);
            }
            return "elo";
        }

        public Task WriteMeasureToDataBase()
        {
            throw new NotImplementedException();
        }
    }
}

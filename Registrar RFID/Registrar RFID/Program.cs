using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System.IO.Ports;

namespace Registrar_RFID
{
    public class Program
    {
        private const string EndpointUrl = "https://dblibro.documents.azure.com:443/";
        private const string PrimaryKey = "I7IHSx0n66Pul4x1mhBwyhautW2UR8QQaA3UTsxswysgFPVCAlQu78lOzMwsKephOm6oAFYSws7vIkfJUwzPoQ==";
        private DocumentClient client;

        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.GetStartedDemo().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine($"{de.StatusCode} error occurred: {de.Message}, Message: {baseException.Message}");
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine($"Error: {e.Message}, Message: {baseException.Message}");
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        private async Task GetStartedDemo()
        {
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "LibrosDB" });
        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}

using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using System.Net;
using System.IO;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            //TriggerClientEvent("httpGet");
            //TriggerEvent("httpGet");
            //DbTest();
        }

        // This is an old test from me: I just tried to trigger this event on
        // the client side ("test") which triggers a clientSideEvent with a 
        // notification - not import for the http-stuff
        void doSomething(dynamic p)
        {
            //TriggerClientEvent("httpGet");
            TriggerEvent("httpGet");
            //DbTest();
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }

        static void DbTest()
        {
            Debug.WriteLine("REQUEST: Webpage example");            
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(
              "http://www.example.com");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Debug.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Debug.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            Debug.WriteLine("REQUEST: got an answer");
        }
    }
}

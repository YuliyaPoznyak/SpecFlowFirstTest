using RestSharp;
using SpecFlowFirstTest.Models;
using System.IO;
using System.Net;

namespace SpecFlowFirstTest.HttpRequests
{
    class ServiceAndLinksRequest
    {
        private const string url = "url";


        public static string getServiceAndLinksRequest(string langauageCode)

        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + langauageCode);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static IRestResponse makeRequest(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest("endpoint", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new CountriesRoot { });
            request.AddJsonBody("");
            var result = client.Execute(request);
            HttpStatusCode statusCode = result.StatusCode;
            string content = result.Content;
            return result;
        }
    }
}

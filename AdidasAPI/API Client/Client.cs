using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace AdidasAPI
{
    public class Client
    {
        private Uri url;
        private HttpClient client;
        private const string urlAddress = "https://www.adidas.fi/";


        public Client(string url = urlAddress)
        {
            this.url = new Uri(url);
            this.client = new HttpClient();
            this.client.BaseAddress = this.url;
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                string.Format("{0}{1}", this.url, path));

            return await this.client.SendAsync(request);
        }
    }
}

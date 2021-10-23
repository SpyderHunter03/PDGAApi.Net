using PDGAApi.Net.Exceptions;
using PDGAApi.Net.Models;
using RestSharp;
using System.Threading.Tasks;

namespace PDGAApi.Net
{
    public class PDGA : IPDGA
    {
        private readonly RestClient client;

        public PDGA()
        {
            client = new RestClient("https://api.pdga.com/services/json")
            {
                CookieContainer = new System.Net.CookieContainer()
            };
        }

        public async Task<LoginResponse> Login(string username, string password)
        {
            var request = new RestRequest("user/login", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new LoginBody { username = username, password = password });

            var response = await client.PostAsync<LoginResponse>(request);

            return response;
        }

        public async Task<PlayerInformationResponse> GetPlayerInformation(int pdgaNumber)
        {
            if (!HasCookies())
                throw new NotLoggedInException();

            var request = new RestRequest("/players", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("pdga_number", pdgaNumber);

            var response = await client.GetAsync<PlayerInformationResponse>(request);

            return response;
        }

        public async Task<bool> Logout(string token)
        {
            var request = new RestRequest("user/logout", DataFormat.Json);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-CSRF-Token", token);

            var response = await client.PostAsync<bool>(request);

            return response;
        }

        private bool HasCookies()
        {
            var cookies = client.CookieContainer.GetCookies(new System.Uri("https://api.pdga.com"));
            return cookies.Count > 0;
        }
    }
}

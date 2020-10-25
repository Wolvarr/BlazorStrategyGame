using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Shared.Models.Auth;

namespace StrategyGame.Shared.Services
{
    public class AuthenticationService
    {
        private readonly string baseUrl;
        private readonly HttpClient client;

        public AuthenticationService(string url)
        {
            this.baseUrl = url;
            this.client = new HttpClient();
        }

        public async Task RegisterUserAsync(RegisterRequest request)
        {
            var result = await client.PostAsync($"{baseUrl}/api/auth/register", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            return;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var result = await client.PostAsync($"{baseUrl}/api/auth/login", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
                var asd =  JsonConvert.DeserializeObject<UserManagerResponse>(result.Content.ReadAsStringAsync().Result);
            return asd;
        }
    }
}

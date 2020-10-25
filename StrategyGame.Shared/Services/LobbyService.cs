using Newtonsoft.Json;
using StrategyGame.Shared.Models.Lobby;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Shared.Services
{
    public class LobbyService
    {
        private readonly string baseUrl;
        private readonly HttpClient client;

        public LobbyService(string url)
        {
            this.baseUrl = url;
            this.client = new HttpClient();
        }

        public async Task<List<LobbyDTO>> GetAllLobbies(string accessToken)
        {
            client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);   
            var result = await client.GetAsync($"{baseUrl}/api/lobby/lobbies");
            return JsonConvert.DeserializeObject<List<LobbyDTO>>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<LobbyDTO> GetCurrentLobby(string accessToken)
        {
            client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var result = await client.GetAsync($"{baseUrl}/api/lobby/current-lobby");
            return JsonConvert.DeserializeObject<LobbyDTO>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task CreateLobby(CreateLobbyRequest request, string accessToken)
        {
            client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var result = await client.PostAsync($"{baseUrl}/api/lobby/create", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            return;
        }


    }
}

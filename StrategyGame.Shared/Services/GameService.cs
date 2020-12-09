using Newtonsoft.Json;
using StrategyGame.Shared.Communication;
using StrategyGame.Shared.Models;
using StrategyGame.Shared.Models.Events;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Shared.Services
{
    public class GameService
    {
        private readonly string baseUrl;
        private readonly HttpClient client;

        public GameService(string url)
        {
            this.baseUrl = url;
            this.client = new HttpClient();
        }

        public async Task<List<GenerativeEventViewModel>> GetUpdates(int from = 0, string gameId = "6807a453-04c2-4436-9cc1-0bc682ee7e3e")
        {
            var result = await client.GetAsync($"{baseUrl}/engine/update/{from}?gameId={gameId}");
            return JsonConvert.DeserializeObject<List<GenerativeEventViewModel>>(result.Content.ReadAsStringAsync().Result);
        }


        public async Task EndTurn(Guid gameId, Guid playerId)
        {  
            await client.PostAsync($"{baseUrl}/engine/endturn/?gameId={gameId}&playerId={playerId}", null);
        }

        public async Task StartTurn(Guid gameId, Guid playerId)
        {
            await client.PostAsync($"{baseUrl}/engine/startturn/?gameId={gameId}&playerId={playerId}", null);
        }

        public async Task<bool> CheckTurn(Guid gameId, Guid playerId)
        {
            var result = await client.GetAsync($"{baseUrl}/engine/checkturn/?gameId={gameId}&playerId={playerId}");
            var res = JsonConvert.DeserializeObject<string>(result.Content.ReadAsStringAsync().Result);
            return res == "YES";
        }

        public async Task CustomCommand(CustomCommand command)
        {
            var commandAsString =  new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var result = await client.PostAsync($"{baseUrl}/engine/custom", commandAsString);
            var res = JsonConvert.DeserializeObject<string>(result.Content.ReadAsStringAsync().Result);
        }
    }
}

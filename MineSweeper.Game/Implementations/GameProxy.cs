using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MineSweeper.Game
{
    public class GameProxy : IGame
    {
        public State State { get; private set; }
        public HttpClient HttpClient { get; }

        public GameProxy(State state, HttpClient httpClient)
        {
            State = state;

            HttpClient = httpClient;
        }

        public static async Task<GameProxy> StartGame(HttpClient httpClient, Config config)
        {
            var state = await SendGameMessage(httpClient, "start_game", config);

            return new GameProxy(state, httpClient);
        }

        public static async Task<State> RevealTileAsync(HttpClient httpClient, int x, int y)
        {
            return await SendGameMessage(httpClient, "reveal_tile", new { x = x, y = y, });
        }

        public static async Task<State> ToggleFlagAsync(HttpClient httpClient, int x, int y)
        {
            return await SendGameMessage(httpClient, "toggle_flag", new { x = x, y = y, });
        }
        
        public static async Task<State> SubmitScoreAsync(HttpClient httpClient, string username)
        {
            return await SendGameMessage(httpClient, "submit_score", new { username=username });            
        }

        public void RevealTile(int x, int y)
        {
            State = Task.Run(() =>  RevealTileAsync(HttpClient, x, y)).Result;
        }

        public void ToggleFlag(int x, int y)
        {
            State = Task.Run( () => ToggleFlagAsync(HttpClient, x, y)).Result;
        }
        
        public void SubmitScore(string username)
        {
            State = Task.Run( () => SubmitScoreAsync(HttpClient, username)).Result;
        }

        public static async Task<State> SendGameMessage(HttpClient httpClient, string uri, object data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await httpClient.PostAsync(uri, content);

            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadAsStringAsync();

                if (response != null)
                {
                    var deserializedState = JsonSerializer.Deserialize<State>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if (deserializedState != null)
                    {
                        return deserializedState;
                    }
                }
            }

            throw new InvalidOperationException("Failed Posting message to game server");
        }

    }
}

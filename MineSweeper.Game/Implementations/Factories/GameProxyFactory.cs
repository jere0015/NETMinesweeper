using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public class GameProxyFactory : IGameFactory
    {
        public IGame Create()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7055/Game/");

            var defaultConfig = new Config(10, 10, (int)DateTime.Now.Ticks, Difficulity.Easy);

            return Task.Run(() => GameProxy.StartGame(httpClient, defaultConfig)).Result;
        }

        public IGame Create(Config config)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7055/Game/");

            return Task.Run(() => GameProxy.StartGame(httpClient, config)).Result;
        }
    }
}

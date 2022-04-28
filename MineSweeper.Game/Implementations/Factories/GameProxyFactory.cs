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
            var apiUrl = Environment.GetEnvironmentVariable("APIURL");

            if (apiUrl  == null)
			{
                throw new ArgumentException("Missing APIURL in enviromental variables");
			}
            
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(apiUrl);

            var defaultConfig = new Config(10, 10, (int)DateTime.Now.Ticks, Difficulity.Easy);

            return Task.Run(() => GameProxy.StartGame(httpClient, defaultConfig)).Result;
        }

        public IGame Create(Config config)
        {
            var apiUrl = Environment.GetEnvironmentVariable("APIURL");

            if (apiUrl == null)
            {
                throw new ArgumentException("Missing APIURL in enviromental variables");
            }

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(apiUrl);

            return Task.Run(() => GameProxy.StartGame(httpClient, config)).Result;
        }
    }
}

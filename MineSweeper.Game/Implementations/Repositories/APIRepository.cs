using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MineSweeper.Game.Implementations.Repositories
{
    //internal class APIRepository<T> : IRepository<T> where T : class
    //{
    //    public APIRepository(HttpClient httpClient)
    //    {
    //        HttpClient = httpClient;
    //    }

    //    public HttpClient HttpClient { get; }

    //    public async Task Create(T entity)
    //    {
    //        var json = JsonSerializer.Serialize(entity);

    //        var content = new StringContent(json, Encoding.UTF8, "application/json");

    //        await HttpClient.PostAsync("", content);

    //        return;
    //    }

    //    public IEnumerable<T> Items()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

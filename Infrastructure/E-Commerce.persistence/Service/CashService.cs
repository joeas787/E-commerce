using E_Commerce.ServiceAbstraction;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Service;

public class CashService (IConnectionMultiplexer multiplexer) : ICashService
{
    private readonly IDatabase database=multiplexer.GetDatabase();
    public async Task<string?> GetAsync(string key)
    {
        return await database.StringGetAsync(key);
    }

    public async Task SetAsync(string key, object value, TimeSpan TTL)
    {
        var option = new JsonSerializerOptions
        {

            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

        };
        var json = JsonSerializer.Serialize(value,option);

           await  database.StringSetAsync(key, json, TTL);
    }
}

using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class RedisCartRepository : ICartRepository
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        //ConnectionMultiplexer ,it multiply connection its redis
        public RedisCartRepository(ConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = _redis.GetDatabase();// GetDatabase it gives us location to store data
        }

        public async Task<bool> DeleteCartAsync(string id)
        {
            // Id here id BuyerId
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<Cart> GetCartAsync(string cartId)
        {
            var data = await _database.StringGetAsync(cartId);
            if (data.IsNullOrEmpty)
            {
                return null;
            }
            //to get we use deserialize
            //if cart find data then  deserilize it and into cart type and return data back
            return JsonConvert.DeserializeObject<Cart>(data);
        }
        public IEnumerable<string> GetUsers()
        {
            var server = GetServer();
            var data = server.Keys();// keys here represent BuyerId
            //  data?= its real data ,quick null check , if data is not null then select value,
            //  otherwise if data is null then return 
            return data?.Select(k => k.ToString());
        }
        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }
        public async Task<Cart> UpdateCartAsync(Cart basket)
        {
            // to wrrite something we use serialize
           var created = await _database.StringSetAsync(basket.BuyerId,
                JsonConvert.SerializeObject(basket));  

            if(!created)
            {
                return null;
            }

            return await GetCartAsync(basket.BuyerId);
        }
    }
}

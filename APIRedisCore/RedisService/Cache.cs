using APIRedisCore.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRedisCore.RedisService
{
    public class Cache : ICache
    {
        readonly RedisConnection redis = new RedisConnection();

        public void CountVisitas(long idProduto, string loja)
        {
            var data = DateTime.Now.Date;
            IDatabase db = redis.Connection.GetDatabase();

            var chave = $"{loja}_{data.ToShortDateString()}_{idProduto}";
            var valor = (int)db.StringGet(chave);

            valor = valor + 1;
            db.StringSet(chave, valor);
            db.KeyPersist(chave);

        }

        public int TotalVisitasProduto(long idProduto, DateTime data, string loja)
        {
            IDatabase db = redis.Connection.GetDatabase();

            var chave = $"{loja}_{data.ToShortDateString()}_{idProduto}";
            return (int)db.StringGet(chave);
        }
    }
}

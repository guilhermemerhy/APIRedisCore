using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRedisCore.RedisService
{
    public interface ICache
    {
        void CountVisitas(long idProduto, string loja);
        int TotalVisitasProduto(long idProduto, DateTime data, string loja);
    }
}

﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRedisCore.Redis
{
    public class RedisConnection
    {

        static RedisConnection()
        {
            RedisConnection.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}

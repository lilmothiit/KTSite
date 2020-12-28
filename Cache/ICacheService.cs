﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTSite.Cache
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync(string key);

        Task SetCacheValueAsync(string key, string value);
    }
}

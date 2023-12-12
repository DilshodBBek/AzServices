using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ServiceCatalog.Application.Inrefaces.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Services
{
	public class CacheService : ICacheService
	{
		private readonly IDistributedCache _distributedCache;

		public CacheService(IDistributedCache distributedCache)
		{
			_distributedCache = distributedCache;
		}

		public bool Add(string key, int expiration)
		{
			try
			{
				var options = new DistributedCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expiration)
				};

				var serializedValue = "true";
				_distributedCache.SetString(key, serializedValue, options);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Get(string key)
		{
			string? cachedValue = _distributedCache.GetString(key);

			if (cachedValue != null)
			{
				return true;
			}

			return false;
		}

		public bool Remove(string key)
		{
			try
			{
				_distributedCache.Remove(key);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}

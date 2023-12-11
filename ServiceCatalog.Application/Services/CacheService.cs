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

		public bool Add(string key, object value, TimeSpan expiration)
		{
			try
			{
				var options = new DistributedCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = expiration
				};

				var serializedValue = JsonConvert.SerializeObject(value);
				_distributedCache.SetString(key, serializedValue, options);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public T Get<T>(string key)
		{
			var cachedValue = _distributedCache.GetString(key);

			if (cachedValue != null)
			{
				return JsonConvert.DeserializeObject<T>(cachedValue);
			}

			return default;
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

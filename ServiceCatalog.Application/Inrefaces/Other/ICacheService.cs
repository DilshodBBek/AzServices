using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Other
{
	public interface ICacheService
	{
		bool Add(string key, int minutes);
		bool Get(string key);
		bool Remove(string key);
	}
}

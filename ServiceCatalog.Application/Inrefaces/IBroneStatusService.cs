using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces
{
	public interface IBroneStatusService<T>
	{
		T GetStatus(int CabinaId);
	}
}

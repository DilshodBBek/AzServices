using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Aplication.Service
{
	public  interface IUserTransoction
	{
		Task Create(IUserTransoction transoction, IUserAccount account);
	}
}

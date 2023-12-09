using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Model.Type
{
	public static  class Guard
	{
		public static void ArgumentNotNull(string argumentName, object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(argumentName);
			}
		}

		public static void ArgumentNotNullOrEmpty(string argumentName, string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(argumentName);
			}

			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Value cannot be an empty string.", argumentName);
			}
		}
	}
}

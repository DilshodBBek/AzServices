using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.Exceptions
{
    public class RegionCreationException : Exception
    {
        public RegionCreationException(string message) : base(message)
        {
        }
    }
}

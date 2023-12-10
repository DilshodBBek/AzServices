using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Other
{
    public interface IPagination <T>
    {
        public IEnumerable<T> GetAll();
    }
}

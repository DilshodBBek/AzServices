using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Base
{
    public interface IGetByIdService<T>
    {
        public Task<T> GetById(int Id);
    }
}

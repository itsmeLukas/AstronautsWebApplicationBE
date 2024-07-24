using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronautsWebApplication.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAstronautRepository Astronaut { get; }
        void Save();
    }
}

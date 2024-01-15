using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IUnitOfWork
    {
        ILeaveRepository Leave { get; }

        void Save();
    }
}

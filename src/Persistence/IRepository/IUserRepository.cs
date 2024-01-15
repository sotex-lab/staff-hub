using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
    }
}

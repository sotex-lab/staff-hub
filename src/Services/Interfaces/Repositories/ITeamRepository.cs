using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services.Interfaces.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Update(Team obj);
    }
}

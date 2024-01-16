﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ITeamRepository Team { get; }
        IUserRepository User { get; }

        void Save();
    }
}

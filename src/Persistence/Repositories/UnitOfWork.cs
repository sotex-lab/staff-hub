using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contexts;
using Services.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITeamRepository Team { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Team = new TeamRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

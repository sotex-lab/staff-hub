using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using Persistence.Contexts;
using Persistence.IRepository;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ILeaveRepository Leave{  get; set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Leave = new LeaveRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

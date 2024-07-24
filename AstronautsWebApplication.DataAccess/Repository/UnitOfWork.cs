using AstronautsWebApplication.Data;
using AstronautsWebApplication.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronautsWebApplication.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IAstronautRepository Astronaut { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Astronaut = new AstronautRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

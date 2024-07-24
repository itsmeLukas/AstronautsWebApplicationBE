using AstronautsWebApplication.Data;
using AstronautsWebApplication.DataAccess.Repository.IRepository;
using AstronautsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronautsWebApplication.DataAccess.Repository
{
    internal class AstronautRepository : Repository<Astronaut>, IAstronautRepository
    {
        private readonly ApplicationDbContext _db;
        public AstronautRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Astronaut obj)
        {
            _db.Astronauts.Update(obj);
        }
    }
}

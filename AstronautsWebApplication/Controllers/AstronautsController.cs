using AstronautsWebApplication.Data;
using AstronautsWebApplication.DataAccess.Repository.IRepository;
using AstronautsWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstronautsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AstronautsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Astronaut> GetAstronauts()
        {
            var astronauts = _unitOfWork.Astronaut.GetAll().ToList();

            return astronauts;
        }

        // GET: api/Astronauts/5
        [HttpGet("{id}")]
        public ActionResult<Astronaut> GetAstronaut(Guid id)
        {
            var astronaut = _unitOfWork.Astronaut.Get(x => x.Id == id);

            if (astronaut == null)
            {
                return NotFound();
            }

            return astronaut;
        }

        [HttpPost]
        public ActionResult<Astronaut> PostAstronaut(Astronaut astronaut)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Astronaut.Add(astronaut);
                _unitOfWork.Save();
                return CreatedAtAction("GetAstronaut", new { id = astronaut.Id }, astronaut);
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAstronaut(Guid id)
        {
            var astronaut = _unitOfWork.Astronaut.Get(x => x.Id == id);
            if (astronaut == null)
            {
                return NotFound();
            }

            _unitOfWork.Astronaut.Remove(astronaut);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult PutAstronaut(Guid id, Astronaut astronaut)
        {
            //var astronautDB = _unitOfWork.Astronaut.Get(x => x.Id == id);
            //if (astronaut == null)
            //{
            //    return NotFound();
            //}

            _unitOfWork.Astronaut.Update(astronaut);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}

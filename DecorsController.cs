using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecorsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public DecorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<cakeDecoration> GetAll()
        {
            return unitOfWork.DecorRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeDecoration> GetById(int id)
        {
            var decor = unitOfWork.DecorRepo.GetById(id);
            if (decor == null) return NotFound();

            return decor;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeDecoration> Create(cakeDecoration decor)
        {
            unitOfWork.DecorRepo.Insert(decor);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = decor.id }, decor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeDecoration> Update(cakeDecoration decor)
        {
            unitOfWork.DecorRepo.Update(decor);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = decor.id }, decor);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var decor = unitOfWork.DecorRepo.GetById(id);

            if (decor == null)
            {
                return NotFound();
            }

            unitOfWork.DecorRepo.Delete(decor);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

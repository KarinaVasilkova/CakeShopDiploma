using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public MeasureController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Measure> GetAll()
        {
            return unitOfWork.MeasureRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Measure> GetById(int id)
        {
            var measure = unitOfWork.MeasureRepo.GetById(id);
            if (measure == null) return NotFound();

            return measure;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Measure> Create(Measure measure)
        {
            unitOfWork.MeasureRepo.Insert(measure);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = measure.Id }, measure);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Measure> Update(Measure measure)
        {
            unitOfWork.MeasureRepo.Update(measure);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = measure.Id }, measure);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var measure = unitOfWork.MeasureRepo.GetById(id);

            if (measure == null)
            {
                return NotFound();
            }

            unitOfWork.MeasureRepo.Delete(measure);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

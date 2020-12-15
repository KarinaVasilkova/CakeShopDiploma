using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreamsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public CreamsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<cakeCream> GetAll()
        {
            return unitOfWork.CreamRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeCream> GetById(int id)
        {
            var cream = unitOfWork.CreamRepo.GetById(id);
            if (cream == null) return NotFound();

            return cream;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeCream> Create(cakeCream cream)
        {
            unitOfWork.CreamRepo.Insert(cream);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = cream.id }, cream);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeCream> Update(cakeCream cream)
        {
            unitOfWork.CreamRepo.Update(cream);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = cream.id }, cream);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var cream = unitOfWork.CreamRepo.GetById(id);

            if (cream == null)
            {
                return NotFound();
            }

            unitOfWork.CreamRepo.Delete(cream);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public FruitsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<cakeFilling> GetAll()
        {
            return unitOfWork.FruitRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeFilling> GetById(int id)
        {
            var fruit = unitOfWork.FruitRepo.GetById(id);
            if (fruit == null) return NotFound();

            return fruit;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeFilling> Create(cakeFilling fruit)
        {
            unitOfWork.FruitRepo.Insert(fruit);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = fruit.id }, fruit);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeFilling> Update(cakeFilling fruit)
        {
            unitOfWork.FruitRepo.Update(fruit);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = fruit.id }, fruit);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var fruit = unitOfWork.FruitRepo.GetById(id);

            if (fruit == null)
            {
                return NotFound();
            }

            unitOfWork.FruitRepo.Delete(fruit);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

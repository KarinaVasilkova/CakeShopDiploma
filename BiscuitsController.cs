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
    public class BiscuitsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public BiscuitsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<cakeBase> GetAll()
        {
            return unitOfWork.BiscuitRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeBase> GetById(int id)
        {
            var biscuit = unitOfWork.BiscuitRepo.GetById(id);
            if (biscuit == null) return NotFound();

            return biscuit;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeBase> Create(cakeBase biscuit)
        {
            unitOfWork.BiscuitRepo.Insert(biscuit);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = biscuit.id }, biscuit);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<cakeBase> Update(cakeBase biscuit)
        {
            unitOfWork.BiscuitRepo.Update(biscuit);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = biscuit.id }, biscuit);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var buscuit = unitOfWork.BiscuitRepo.GetById(id);

            if (buscuit == null)
            {
                return NotFound();
            }

            unitOfWork.BiscuitRepo.Delete(buscuit);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

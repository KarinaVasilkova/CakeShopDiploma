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
    public class DeliveriesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public DeliveriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Delivery> GetAll()
        {
            return unitOfWork.DeliveryRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Delivery> GetById(int id)
        {
            var delivery = unitOfWork.DeliveryRepo.GetById(id);
            if (delivery == null) return NotFound();

            return delivery;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Delivery> Create(Delivery delivery)
        {
            unitOfWork.DeliveryRepo.Insert(delivery);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = delivery.Id }, delivery);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Delivery> Update(Delivery delivery)
        {
            unitOfWork.DeliveryRepo.Update(delivery);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = delivery.Id }, delivery);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var delivery = unitOfWork.DeliveryRepo.GetById(id);

            if (delivery == null)
            {
                return NotFound();
            }

            unitOfWork.DeliveryRepo.Delete(delivery);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

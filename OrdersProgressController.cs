using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersProgressController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public OrdersProgressController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<OrderProgress> GetAll()
        {
            return unitOfWork.OrderProgressRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderProgress> GetById(int id)
        {
            var orderProgress = unitOfWork.OrderProgressRepo.GetById(id);
            if (orderProgress == null) return NotFound();

            return orderProgress;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderProgress> Create(OrderProgress orderProgress)
        {
            unitOfWork.OrderProgressRepo.Insert(orderProgress);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = orderProgress.Id }, orderProgress);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderProgress> Update(OrderProgress orderProgress)
        {
            unitOfWork.OrderProgressRepo.Update(orderProgress);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = orderProgress.Id }, orderProgress);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var orderProgress = unitOfWork.OrderProgressRepo.GetById(id);

            if (orderProgress == null)
            {
                return NotFound();
            }

            unitOfWork.OrderProgressRepo.Delete(orderProgress);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

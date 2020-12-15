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
    public class OrderBodiesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public OrderBodiesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<OrderBody> GetAll()
        {
            return unitOfWork.OrderBodyRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderBody> GetById(int id)
        {
            var orderBody = unitOfWork.OrderBodyRepo.GetById(id);
            if (orderBody == null) return NotFound();

            return orderBody;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderBody> Create(OrderBody orderBody)
        {
            unitOfWork.OrderBodyRepo.Insert(orderBody);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = orderBody.Id }, orderBody);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderBody> Update(OrderBody orderBody)
        {
            unitOfWork.OrderBodyRepo.Update(orderBody);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = orderBody.Id }, orderBody);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var orderBody = unitOfWork.OrderBodyRepo.GetById(id);

            if (orderBody == null)
            {
                return NotFound();
            }

            unitOfWork.OrderBodyRepo.Delete(orderBody);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

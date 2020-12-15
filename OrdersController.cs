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
    public class OrdersController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Order> GetAll()
        {
            return unitOfWork.OrderRepo.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> GetById(int id)
        {
            var order = unitOfWork.OrderRepo.GetById(id);
            if (order == null) return NotFound();

            return order;
        }

        [HttpGet("Between two dates")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Order> GetOrdersByDates(DateTime dateTimeFrom, DateTime datetimeTo)
        {
            datetimeTo = datetimeTo.AddDays(1);
            var orders = unitOfWork.OrderRepo.Get().ToList().Where(d=>d.Dateofdelivery >= dateTimeFrom && d.Dateofdelivery < datetimeTo).OrderBy(d=>d.Dateofdelivery).ToList();
            
            return orders;
        }


        [HttpGet("Income")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int GetIncome()
        {
            int sum = 0;
            int discount = 0;
            var orders = unitOfWork.OrderRepo.Get().OrderByDescending(x => x.Dateofdelivery).Take(10).Distinct().ToList();
            foreach (var order in orders)
            {
                sum += order.Sum;
                discount += order.Discount;
            }

            return discount != 0 ? sum * discount : sum;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> Create(Order order)
        {
            unitOfWork.OrderRepo.Insert(order);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> Update(Order order)
        {
            unitOfWork.OrderRepo.Update(order);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var order = unitOfWork.OrderRepo.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            unitOfWork.OrderRepo.Delete(order);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

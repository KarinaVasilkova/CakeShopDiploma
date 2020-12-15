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
    public class ClientsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Client> GetAll()
        {
            return unitOfWork.ClientRepo.GetAll();
        }


        [HttpGet("LastTenClients")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Client> GetLastTenClients()
        {
            var orders = unitOfWork.OrderRepo.Get().OrderByDescending(x => x.Dateofdelivery).Take(10).Distinct().ToList();
            var lastTenClients = new List<Client>();
            foreach(var order in orders)
            {
                var client = unitOfWork.ClientRepo.GetById(order.ClientID);
                client.Orders = null;
                //client.Orders.Add(order);
                lastTenClients.Add(client);
            }

            return lastTenClients.GroupBy(p=>p.Id).Select(grp => grp.FirstOrDefault());
        }


        [HttpGet("ClientsWithDebt")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Client> GetClientsWithDebt()
        {
            var orders = unitOfWork.OrderRepo.GetAll().ToList();
            var clientsWithDebt = new List<Client>();
            foreach (var order in orders)
            {
                int debt = order.Discount != 0 ? (order.Prepayment - order.Sum) * order.Discount : order.Prepayment - order.Sum;
                if (debt < 0)
                {
                    var client = unitOfWork.ClientRepo.GetById(order.ClientID);
                    client.Orders = null;
                    //client.Orders.Add(order);
                    clientsWithDebt.Add(new Client
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Phone = client.Phone,
                        Address = client.Address,
                        Prepayment = client.Prepayment,
                        Email = client.Email,
                        Login = client.Login,
                        Password = client.Password
                    });
                }
            }

            return clientsWithDebt;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> GetById(int id)
        {
            var client = unitOfWork.ClientRepo.GetById(id);
            if (client == null) return NotFound();

            return client;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> Create(Client client)
        {
            unitOfWork.ClientRepo.Insert(client);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> Update(Client client)
        {
            unitOfWork.ClientRepo.Update(client);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var client = unitOfWork.ClientRepo.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            unitOfWork.ClientRepo.Delete(client);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

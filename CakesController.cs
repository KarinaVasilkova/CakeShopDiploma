using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public CakesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Cake> GetAll()
        {
            return unitOfWork.CakeRepo.GetAll().Where(t => t.status == "стандартний").ToList();
        }



        [HttpGet("PopularCakes")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Cake> GetPopularCakes()
        {
            var ordersBody = unitOfWork.OrderBodyRepo.Get(null, null, "Cake").ToList();
            var popularCakeIds = ordersBody.GroupBy(t => t.Cake).OrderByDescending(d => d.Count()).Select(g => new Cake
            {
                idCake = g.Key.idCake,
                nameCake = g.Key.nameCake,
                aboutCake = g.Key.aboutCake,
                weightCake = g.Key.weightCake,
                priceCake = g.Key.priceCake,
                imgURL = g.Key.imgURL
            }).Where(t => t.status == "стандартний").ToList();
                    
            return popularCakeIds;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cake> GetById(int id)
        {
            var cake = unitOfWork.CakeRepo.GetById(id);
            if (cake == null) return NotFound();

            return cake;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cake> Create(Cake cake)
        {
            unitOfWork.CakeRepo.Insert(cake);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = cake.idCake }, cake);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cake> Update(Cake cake)
        {
            unitOfWork.CakeRepo.Update(cake);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = cake.idCake }, cake);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var cake = unitOfWork.CakeRepo.GetById(id);

            if (cake == null)
            {
                return NotFound();
            }

            unitOfWork.CakeRepo.Delete(cake);
            unitOfWork.Save();

            return NoContent();
        }
    }
}

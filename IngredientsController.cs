using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.Model.Entities;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public IngredientsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/ingredients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Ingredient> GetAll()
        {
            return unitOfWork.IngredientRepo.GetAll();
        }

        // GET api/ingredients/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Ingredient> GetById(int id)
        {
            var ingredient =  unitOfWork.IngredientRepo.GetById(id);
            if (ingredient == null) return NotFound();

            return ingredient;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Ingredient> Create(Ingredient ingredient)
        {
            unitOfWork.IngredientRepo.Insert(ingredient);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Ingredient> Update(Ingredient ingredient)
        {
            unitOfWork.IngredientRepo.Update(ingredient);
            unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = ingredient.Id }, ingredient);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var ingridient = unitOfWork.IngredientRepo.GetById(id);

            if (ingridient == null)
            {
                return NotFound();
            }

            unitOfWork.IngredientRepo.Delete(ingridient);
            unitOfWork.Save();

            return NoContent();
        }

    }
}

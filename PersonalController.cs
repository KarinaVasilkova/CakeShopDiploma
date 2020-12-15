using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using ShopWebApp.DataAccessLayer.Interface;
using ShopWebApp.ViewModels;

namespace ShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public PersonalController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCakesComponents")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public PersonalViewModel GetAllCakesComponents()
        {
            var creams = unitOfWork.CreamRepo.GetAll();
            var bases = unitOfWork.BiscuitRepo.GetAll();
            var decors = unitOfWork.DecorRepo.GetAll();
            var fillings = unitOfWork.FruitRepo.GetAll();
            var coatings = unitOfWork.CoatingsRepo.GetAll();

            return new PersonalViewModel { cakeBase = bases, cakeCoating = coatings, cakeCream = creams, cakeDecoration = decors, cakeFilling = fillings };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Create(PersonalCake personalCake)
        {
            unitOfWork.CakeRepo.Insert(personalCake.Cake);
            unitOfWork.Save();

            foreach (var cakeCream in personalCake.cakeCream)
            {
                personalCake.Cake.Cream.Add(new CreamCake { Cake = personalCake.Cake, CakeCream = cakeCream });
            }

            foreach (var cakeBase in personalCake.cakeBase)
            {
                personalCake.Cake.CakeBase.Add(new CakeCakeBase { Cake = personalCake.Cake, CakeBase = cakeBase });
            }

            foreach (var cakeCoating in personalCake.cakeCoating)
            {
                personalCake.Cake.Coating.Add(new CoatingCake { Cake = personalCake.Cake, CakeCoating = cakeCoating });
            }

            foreach (var cakeDecoration in personalCake.cakeDecoration)
            {
                personalCake.Cake.Decor.Add(new DecorCake { Cake = personalCake.Cake, CakeDecoration = cakeDecoration });
            }

            foreach (var cakeFilling in personalCake.cakeFilling)
            {
                personalCake.Cake.Fruit.Add(new FillingCake { Cake = personalCake.Cake, CakeFilling = cakeFilling });
            }

            unitOfWork.CakeRepo.Update(personalCake.Cake);
            unitOfWork.Save();

        }
    }
}

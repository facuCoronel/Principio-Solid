using Microsoft.AspNetCore.Mvc;
using Solid_S.Models.ViewModels;
using Solid_S.Service;

namespace Solid_S.Controller
{
    public class BeerController : ControllerBase // aca va controller solamente
    {
        
        public IActionResult Index(BeerViewModel beer)
        {
            //aca view va como metodo vacio
            return View(beer);
            return Ok();
        }

        //Esto no va, pero lo hago para seguir igual que el tutorial
        private IActionResult View(BeerViewModel beer)
        {
            throw new NotImplementedException();
        }

        //Esto si va
        public IActionResult Add(BeerViewModel beer)
        {
            if (!ModelState.IsValid)
            {
                return View(beer);
            }
            var beerService = new BeerService();
            beerService.Create(beer);


            return Ok();
        }
    }
}

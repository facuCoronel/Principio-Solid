using Solid_S.Models.Db;
using Solid_S.Models.ViewModels;
using Solid_S.Service.Utils;

namespace Solid_S.Service
{
    public class BeerService
    {
        public void Create(BeerViewModel beer)
        {
            var beerDB = new BeerDb();
            var log = new Log();

            beerDB.Save(beer);
            log.Save("Se guardo una cerveza" + beer.GetInfo());
        }
    }
}

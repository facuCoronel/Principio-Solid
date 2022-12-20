using Solid_S.Models.ViewModels;

namespace Solid_S.Models.Db
{
    public class BeerDb
    {
        // Aca se guarda en la BD, con dapper o con lo que sea.
        public void Save(BeerViewModel beer)
        {
            Console.WriteLine("Guardar en BD" + beer.Name);  
        }
    }
}

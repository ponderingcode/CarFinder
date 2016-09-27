using CarFinder.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarFinder.Controllers
{
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("Years")]
        public async Task<List<string>> GetAllYears()
        {
            return await db.GetAllYears();
        }

        [Route("Makes")]
        public async Task<List<string>> GetAllMakes(string _year)
        {
            return await db.GetAllMakes(_year);
        }

        [Route("Models")]
        public async Task<List<string>> GetAllModels(string _year, string _make)
        {
            return await db.GetAllModels(_year, _make);
        }

        [Route("Trims")]
        public async Task<List<string>> GetAllTrims(string _year, string _make, string _modelName)
        {
            return await db.GetAllTrims(_year, _make, _modelName);
        }

        [Route("Car")]
        public async Task<List<string>> GetCar(string _year, string _make, string _modelName, string _modelTrim)
        {
            return await db.GetCar(_year, _make, _modelName, _modelTrim);
        }
    }
}
